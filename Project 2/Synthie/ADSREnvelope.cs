using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    class ADSREnvelope
    {
        private double attack;
        private double decay;
        private double release;
        private double sustain;
        private double totalDuration;

        public ADSREnvelope(double duration, double a, double d, double s, double r)
        {
            totalDuration = duration;

            attack = a;
            decay = d;
            sustain = s;
            release = r;
            
        }

        public double GetAmplitude(double currTime)
        {
            double amp = 0;
            if (currTime < attack)
            {
                amp = currTime / attack;
            }
            else if (currTime < attack + decay)
            {
                amp = 1 - ((currTime - attack) / decay) * (1 - sustain) ;
            }
            else if (currTime < totalDuration - release)
            {
                amp = sustain;
            }
            else
            {
                amp =  ((totalDuration - currTime) / release);
            }

            return amp;
        }
    }

}
