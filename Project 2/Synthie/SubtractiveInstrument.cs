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
        private SquareWaves wave = new SquareWaves();
        
        private ResonFilter filter = new ResonFilter(0.4);
        public double Frequency { get => wave.Frequency;  set => wave.Frequency = value; }
        private FilterEnvelope envelope = new FilterEnvelope();
        private float time = 0;
        private double pitch;
        private ADSREnvelope adsr;
        private Boolean applyADSR = false;
        private Boolean applyEnvelope = false;
        public SubtractiveInstrument()
        {
            duration = 0.1;
        }
        public override bool Generate()
        {
           float amp = (float)adsr.GetAmplitude(time);
            if (applyEnvelope)
            {
                envelope.Generate();
                wave.Amp = envelope.Frame()[0];
            }
            wave.Generate();
            filter.Generate();
            float temp = (float)(wave.Frame()[0]);
            frame[0] = temp * amp;
            frame[1] = wave.Frame()[1] * amp;
            time += (float)samplePeriod;
            
            return time < duration * this.SecsPerBeat;
        }

        public override void SetNote(Note note, double secperbeat)
        {

            duration = note.Count;
            this.SecsPerBeat = secperbeat;
            Frequency = Notes.NoteToFrequency(note.Pitch);
           
        }

        public override void Start()
        {
            wave.SamplePeriod = samplePeriod;
            //Frequency = pitch;
            wave.Frequency2 = Frequency;
            wave.SampleRate = sampleRate;
            wave.Start();
            time = 0;
             adsr = new ADSREnvelope(duration, 0.12, 0.07 , 0.73 , 0.08);
            filter.Frequency = (float)Frequency;
            filter.Start();
            
            // Tell the AR object where it gets its samples from 
            // the sine wave object.
            envelope.Source = this;
            envelope.SampleRate = SampleRate;
            envelope.Duration = duration;
            envelope.SamplePeriod = samplePeriod;
            
            envelope.Start();
        }
    }
}
