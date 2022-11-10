using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;

namespace Synthie
{
    internal class DrumInstrument: Instrument
    {
        private double duration;
        private const double atk = 0.05;
        private const double del = 0.2;
        private const double sus = 0.4;
        private const double rel = 0.05;
        private string type;
        private float[] tmp = new float[2];
        private SineWave sinewave = new SineWave();
        private SoundStream soundFile;
        private double time;
        private ADSR adsr = new ADSR(atk, del, sus, rel);
        public double Frequency { get => sinewave.Frequency; set => sinewave.Frequency = value; }

        public double Duration { get => duration; }
        public DrumInstrument(string name)
        {
            type = name;
        }
        public override void SetNote(Note note, double secperbeat) //Example
        {
            duration = note.Count;
            this.SecsPerBeat = secperbeat;
            Frequency = Notes.NoteToFrequency(note.Pitch);
        }
        public override bool Generate() //Example
        {
            // Tell the component to generate an audio sample
            //soundFile.Play();
            tmp = soundFile.ReadNextFrame();
            if (tmp != null)
            {
                frame[0] = (double)tmp[0];
                frame[1] = frame[0];
            }
            else
            {
                //soundFile.Seek(0);
            }

            adsr.Generate();

            frame[0] = adsr.Frame(0);      //pull the adjusted sample
            frame[1] = adsr.Frame(1);

            // Read the component's sample and make it our resulting frame.

            // Update time
            time += samplePeriod;

            // We return true until the time reaches the duration.
            return time < duration * this.SecsPerBeat;
        }

        public override void Start() //Example
        {
            setupSoundFile();
            time = 0;

            // Tell the AR object where it gets its samples from 
            // the sine wave object.
            adsr.Source = this;
            adsr.SampleRate = SampleRate;
            adsr.Duration = duration;
            adsr.SamplePeriod = samplePeriod;
            adsr.Start();
        }

        public void setupSoundFile()
        {
            if (type == "DrumBase")
                soundFile = new SoundStream("../../res/Drums/Bass-Drum-2.wav");
            else if (type == "DrumHiHatClose")
                soundFile = new SoundStream("../../res/Drums/Ensoniq-SQ-1-Closed-Hi-Hat.wav");
            else if (type == "DrumHiHatOpen")
                soundFile = new SoundStream("../../res/Drums/Ensoniq-SQ-1-Open-Hi-Hat.wav");
            else if (type == "DrumTom1")
                soundFile = new SoundStream("../../res/Drums/Floor-Tom-1.wav");
            else if (type == "DrumTom2")
                soundFile = new SoundStream("../../res/Drums/Floor-Tom-2.wav");
            else if (type == "DrumSnare")
                soundFile = new SoundStream("../../res/Drums/Hip-Hop-Snare-1.wav");
            else
                soundFile = new SoundStream("");
        }
    }
}
