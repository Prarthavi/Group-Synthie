using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    internal class AdditiveInstrument : Instrument
    {
        private double duration;
        private SineWave sinewave = new SineWave();
        private double time;
        private double attack = 0.05;
        private double decay = 0.05;
        private double sustain = 0.8;
        private double release = 0.05;


        public double Frequency { get => sinewave.Frequency; set => sinewave.Frequency = value; }

        public double Duration { get => duration; }
        public AdditiveInstrument()
        {
            duration = 0.1;
        }
        public override void SetNote(Note note, double secperbeat)
        {
            duration = note.Count * secperbeat;
            Frequency = Notes.NoteToFrequency(note.Pitch);
        }
        public override bool Generate()
        {
            // Tell the component to generate an audio sample
            sinewave.Generate();
            frame = sinewave.Frame();

            double gain;

            if (time < attack)
                gain = time / attack;
            else if (time < attack + decay)
                gain = 1 - ((time - attack) / decay) * (1 - sustain);
            else if (time < duration - release)
                gain = sustain;
            else
                gain = sustain * (duration - time) / release;


            frame[0] = sinewave.Frame(0) * gain;      //pull the adjusted sample
            frame[1] = sinewave.Frame(1) * gain;

            // Read the component's sample and make it our resulting frame.

            // Update time
            time += samplePeriod;

            // We return true until the time reaches the duration.
            return time < duration;
        }

        public override void Start()
        {
            sinewave.SampleRate = SampleRate;
            sinewave.Start();
            time = 0;
        }
    }
}
