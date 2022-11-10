using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    internal class AdditiveInstrument : Instrument
    {
        private double duration;
        private SineWave sinewave = new SineWave();
        private double time;
        private AR ar = new AR();
        public double Frequency { get => sinewave.Frequency; set => sinewave.Frequency = value; }

        public double Duration { get => duration; }
        public AdditiveInstrument()
        {
            duration = 0.1;
        }
        public override void SetNote(Note note, double secperbeat)
        {
            duration = note.Count;
            this.SecsPerBeat = secperbeat;
            Frequency = Notes.NoteToFrequency(note.Pitch);
        }
        public override bool Generate()
        {
            // Tell the component to generate an audio sample
            sinewave.Generate();
            frame = sinewave.Frame();

            ar.Generate();

            frame[0] = ar.Frame(0);      //pull the adjusted sample
            frame[1] = ar.Frame(1);

            // Read the component's sample and make it our resulting frame.

            // Update time
            time += samplePeriod;

            // We return true until the time reaches the duration.
            return time < duration * this.SecsPerBeat;
        }

        public override void Start()
        {
            sinewave.SampleRate = SampleRate;
            sinewave.Start();
            time = 0;

            // Tell the AR object where it gets its samples from 
            // the sine wave object.
            ar.Source = this;
            ar.SampleRate = SampleRate;
            ar.Duration = duration;
            ar.SamplePeriod = samplePeriod;
            ar.Start();
        }
    }
}
