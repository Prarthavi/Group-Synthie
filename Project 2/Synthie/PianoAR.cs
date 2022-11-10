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
        private double sustain;
        private AudioNode source;
        private double gain;
        private double time;
        private double duration;
        private double speed;
        public AudioNode Source { get => source; set => source = value; }
        public double Duration { set => duration = value; }
        public double Sustain { set => sustain = value; }
        public double Speed { set => speed = value; }
        public override bool Generate()
        {
            //Envelope Logic
            if (time < attack)
                gain = time / attack + speed;
            else if (time < attack + sustain)
                gain = 1 + speed / attack;
            else
                gain = 1 + speed - (time - attack - sustain) / (duration - attack - sustain);
            this.Frame()[0] = source.Frame()[0] * gain;
            this.Frame()[1] = source.Frame()[1] * gain;
            time += SamplePeriod;
            return true;
        }

        public override void Start()
        {
            time = 0;
            attack = 0.25;
            sustain = 0;
            duration *= source.SecsPerBeat;
        }
    }
}
