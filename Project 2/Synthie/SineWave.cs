using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Synthie
{
    public class SineWave : AudioNode
    {
        private double amp;
        private double freq;
        private double phase;
        private double vib;
        private int vHz;
        private double vPhase;
        private double dAmp;

        public double Frequency { get => freq; set => freq = value; }
        public double Vibrato { get => vib; set => vib = value; }

        public SineWave()
        {
            phase = 0;
            amp = 0.1;
            freq = 440;
            vHz = 0;
            vPhase = 0;
            dAmp = 8;
        }

        public override bool Generate()
        {
            frame[0] = amp * (Math.Sin(phase * 2 * Math.PI) + Math.Sin(2 * phase * 2 * Math.PI) / 2 + Math.Sin(3 * phase * 2 * Math.PI) / 3 + Math.Sin(4 * phase * 2 * Math.PI) / 4 + Math.Sin(5 * phase * 2 * Math.PI) / 5 + Math.Sin(6 * phase * 2 * Math.PI) / 6 + Math.Sin(7 * phase * 2 * Math.PI) / 7 + Math.Sin(8 * phase * 2 * Math.PI) / 8 + Math.Sin(9 * phase * 2 * Math.PI) / 9);
            frame[1] = frame[0];

            if(vib>vHz)
            {
                frame[0] += amp * Math.Sin(phase * 2 * Math.PI);
                frame[1] = frame[0];

                double diff = dAmp * Math.Sin(vPhase * 2 * Math.PI);
                phase += (freq + diff) * samplePeriod;
                vPhase += vib * samplePeriod;
            }
            else
                phase += freq * samplePeriod;

            return true;
        }

        public override void Start()
        {
            phase = 0;
        }
    }
}
