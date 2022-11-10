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
        /*
        private double[] prev = { -1, -1 };
        private double x;
        private double y;*/

        public double Frequency { get => sinewave.Frequency; set => sinewave.Frequency = value; }
        public double Vibrato { get => sinewave.Vibrato; set => sinewave.Vibrato = value; }
        public double Duration { get => duration; }
        public double Time { get => time; }
        public AdditiveInstrument()
        {
            duration = 0.1;
        }
        public override void SetNote(Note note, double secperbeat)
        {
            duration = note.Count * secperbeat;
            Frequency = Notes.NoteToFrequency(note.Pitch);
            Vibrato = note.Vibrato;
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
            /*
            x = frame[0];
            y = frame[1];
            
            if (prev[0]!=-1)
            {
                double pct = time / duration;
                x = (1 - pct) * frame[0] + pct * prev[0];
                y = (1 - pct) * frame[1] + pct * prev[1];
            }

            prev[0] = frame[0];
            prev[1] = frame[1];

            frame[0] = x;
            frame[1] = y;*/

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
