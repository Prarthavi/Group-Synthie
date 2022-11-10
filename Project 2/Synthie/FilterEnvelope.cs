using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synthie
{
    public class FilterEnvelope : AudioNode
    {
        private double totalDuration;
        private double quad;
        private double tempDuration;
        private double attack;
        private double release;
        private AudioNode source;
        double gain;
        double time;
        double duration;
        public AudioNode Source { get => source; set => source = value; }
        public double Duration { set => duration = value; }
        public override bool Generate()
        {

            if (time <= attack)
            {
                gain = time / attack;
            }
            else 
                gain =  (duration - time) / (release);

            this.Frame()[0] =  gain;
            this.Frame()[1] =  gain;
            time += SamplePeriod;
            return true;
        }

        public override void Start()
        {
            time = 0;
            

            duration = source.SecsPerBeat;
            attack = 0.85 * duration;
            release = duration - attack;
            
        }

 
    }
}
