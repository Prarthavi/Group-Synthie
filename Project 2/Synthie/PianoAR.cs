using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    internal class PianoAR : AudioNode
    {

        private double attack;
        private double release;
        private double sustain;
        private AudioNode source;
        double gain;
        double time;
        double duration;
        public AudioNode Source { get => source; set => source = value; }
        public double Duration { set => duration = value; }
        public double Sustain { set => sustain = value; }
        public override bool Generate()
        {

            if (time < attack)
            {
                gain = time / attack;
            }
            else if (duration - time < release)
                gain = 1 + (duration - time - release) / (release);
            else
                gain = 1;
            this.Frame()[0] = source.Frame()[0] * gain;
            this.Frame()[1] = source.Frame()[1] * gain;
            time += SamplePeriod;
            return true;
        }

        public override void Start()
        {
            time = 0;
            attack = 0.25;
            release = 0.5;
            sustain = 0;
            duration *= source.SecsPerBeat;
        }
    }
}
