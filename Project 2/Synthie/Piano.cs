using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class Piano : Instrument
    {
        private double duration;
        private string soundPath;
        private double time;
        private int curFrame;
        private SoundStream soundVar;
        private PianoAR ar = new PianoAR();

        public double Duration { get => duration; }
        //public double Frequency { get => pwave.Frequency; set => pwave.Frequency = value; }

        public Piano() 
        {
            duration = 0.1;
        }

        public override bool Generate()
        {
            float[] tmp = (float[])soundVar.GetFrame(curFrame);
            
            if (tmp != null) 
            { 
                frame[0] = (double)tmp[0];
                frame[1] = frame[0];
            }
            else 
            { 
                frame[0] = 0; 
                frame[1] = 0; 
            }

            ar.Generate();

            frame[0] = ar.Frame(0);
            frame[1] = ar.Frame(1);

            time += samplePeriod;
            curFrame++;

            return time < duration * this.SecsPerBeat;
        }

        public override void Start() 
        {
            soundVar = new SoundStream(soundPath);
            
            time = 0;
            curFrame = 0;

            // Tell the AR obj where it gets its sample from
            // the soundVar obj.
            ar.Source = this;
            ar.SampleRate = SampleRate;
            ar.Duration = duration;
            ar.SamplePeriod = samplePeriod;
            ar.Start();
        }

        public override void SetNote(Note note, double secperbeat)
        {
            duration = note.Count;
            this.SecsPerBeat = secperbeat;
            soundPath = PianoNotes.NoteToFile(note.Pitch);
        }
    }
}
