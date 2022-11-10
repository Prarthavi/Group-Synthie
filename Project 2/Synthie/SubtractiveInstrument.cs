using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Synthie
{
    internal class SubtractiveInstrument : Instrument
    {
        private double duration;
        private Waves wave;
        
        private ResonFilter filter = new ResonFilter();
        
        private FilterEnvelope envelope = new FilterEnvelope();
        private float time = 0;
        private Boolean applyEnvelope = false;

        private float attack = 0.05f;
        private float decay = 0.05f;
        private float sustain = 0.7f;
        private float release = 0.2f;

        public SubtractiveInstrument()
        {
            duration = 0.1;
        }
        public override bool Generate()
        {
            float gain = 1;

            if (applyEnvelope)
            {
                envelope.Generate();
                wave.Amp = envelope.Frame()[0];
            }
            else
            {
                if (time < attack)
                    gain = time / attack;
                else if (time < attack + decay)
                    gain = 1 - ((time - attack) / decay) * (1 - sustain);
                else if (time < duration - release)
                    gain = sustain;
                else
                    gain = sustain * ((float)duration - time) / release;
            }


            wave.Generate();
            filter.Generate();


            if (wave.Frame()[0] >= 1)
                wave.Frame()[0] = 1;
            if(wave.Frame()[0] <= -1)
                wave.Frame()[0] = -1;
            frame[0] = gain * wave.Frame()[0] * filter.Frame()[0];
            frame[1] = gain * wave.Frame()[1] * filter.Frame()[0];

            time += (float)samplePeriod;
            
            return time < duration;
        }

        public override void SetNote(Note note, double secperbeat)
        {
            
            this.SecsPerBeat = secperbeat;
            duration = note.Count *secsperbeat;
            switch (note.WaveType)
            {
                case "Square":
                    wave = new SquareWaves();
                    break;
                case "Triangle":
                    wave = new TriangleWaves();
                    break;
                default:
                    wave = new TriangleWaves();
                    break;
            }
            wave.Frequency = Notes.NoteToFrequency(note.Pitch);
            filter.FilterFreq = (float)note.ResonFreq;
            filter.R = (float)note.R;

        }

        public override void Start()
        {
            wave.SamplePeriod = samplePeriod;
            wave.Frequency2 = wave.Frequency;
            wave.SampleRate = sampleRate;
            wave.Start();
            time = 0;
             
            filter.Frequency = (float)wave.Frequency;
            filter.Start();
            double temp = duration;

            //attack = (float)(0.10f * duration);
            //decay = (float)(0.10f * duration);
            //sustain = (float)(0.40f * duration);
            //release = (float)(0.40f * duration);


            envelope.Source = this;
            envelope.SampleRate = SampleRate;
            envelope.Duration = duration;
            envelope.SamplePeriod = samplePeriod;
            
            envelope.Start();
        }
    }
}
