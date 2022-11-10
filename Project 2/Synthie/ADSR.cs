using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    internal class ADSR : AudioNode
    {
        private double attack; //length of increase
        private double decay; //length of decay
        private double sustain = 1; //gain of sustain
        private double release; //length of release
        private AudioNode source;
        double gain;
        double time;
        double duration;
        public AudioNode Source { get => source; set => source = value; }
        public double Duration { set => duration = value; }

        public ADSR(double atk = 0.05, double dec = 0.1, double sus = 1, double rel = 0.05)
        {
            attack = atk;
            decay = dec;
            sustain = sus; 
            release = rel; 
        }
        public override bool Generate()
        {

            if (time < attack)
            {
                gain = time / attack;
            }
            else if (duration - time < release)
            {
                gain = 1 + (duration - time - release) / (release);
            }
            else if (time < decay)
            {
                //from 1 to sustain, from attack to decay (0 -> 1)
                gain = sustain + (1 - sustain) * (1 - (time - attack) / (decay - attack));
            }
            else
                gain = sustain;
            this.Frame()[0] = source.Frame()[0] * gain;
            this.Frame()[1] = source.Frame()[1] * gain;
            time += SamplePeriod;
            return true;
        }

        public override void Start()
        {
            time = 0;
            duration *= source.SecsPerBeat;     
        }
    }
}
