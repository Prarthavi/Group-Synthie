using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Synthie
{
    public class AR : AudioNode
    {
        private double attack;
        private double release;
        private AudioNode source;
        double gain;
        double time ;
        double duration;
        public AudioNode Source { get => source; set => source = value; }
        public double Duration { set => duration = value; }
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
            attack = 0.05;
            release = 0.05;
            duration *= source.SecsPerBeat;
        }
        
    }
}
