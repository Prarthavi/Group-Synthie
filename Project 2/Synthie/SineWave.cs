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

        public double Frequency { get => freq; set => freq = value; }

        public SineWave()
        {
            phase = 0;
            amp = 0.1;
            freq = 440;
        }

        public override bool Generate()
        {
            frame[0] = amp * (Math.Sin(phase * 2 * Math.PI) + Math.Sin(2 * phase * 2 * Math.PI) / 2 + Math.Sin(3 * phase * 2 * Math.PI) / 3 + Math.Sin(4 * phase * 2 * Math.PI) / 4 + Math.Sin(5 * phase * 2 * Math.PI) / 5 + Math.Sin(6 * phase * 2 * Math.PI) / 6 + Math.Sin(7 * phase * 2 * Math.PI) / 7 + Math.Sin(8 * phase * 2 * Math.PI) / 8 + Math.Sin(9 * phase * 2 * Math.PI) / 9);
            frame[1] = frame[0];

            phase += freq * samplePeriod;

            return true;
        }

        public override void Start()
        {
            phase = 0;
        }
    }
}
