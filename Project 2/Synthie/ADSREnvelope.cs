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
        private double sustainAmp;

        private double startDecayTime;
        private double startSustainTime;
        private double startReleaseTime;
        private double totalDuration;

        public ADSREnvelope(double noteDurationSec, double attackSec, double decaySec, double releaseSec, double sustainLevel)
        {
            totalDuration = noteDurationSec;

            attack = attackSec;
            decay = decaySec;
            release = releaseSec;
            sustainAmp = sustainLevel;

            // Not strictly necessary, but nice for readability in gen function.
            startDecayTime = attackSec;
            startSustainTime = attackSec + decaySec;
            startReleaseTime = totalDuration - releaseSec;
        }

        public double GetAmplitudeAtTime(double currTime)
        {
            double amp;

            if (currTime < attack)
            {
                // Attack
                amp = currTime / attack;
            }
            else if (currTime < attack + decay)
            {
                // Decay
                amp = 1 - ((currTime - attack) / decay) * (1 - sustainAmp);
            }
            else if (currTime < totalDuration - release)
            {
                // Sustain
                amp = sustainAmp;
            }
            else
            {
                // Release
                amp = sustainAmp * ((totalDuration - currTime) / release);
            }

            return amp;
        }
    }

}
