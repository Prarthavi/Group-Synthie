using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class SquareWaves : AudioNode
    {
        private double amp;
        private double freq;
        private double phase;
        private List<double> squareWaveTable;

    
        public double Frequency { get => freq; set => freq = value; }
        public double Amp { get => amp; set => amp = value; }
        public SquareWaves()
        {
            amp = 1;
            phase = 1;
            freq = 440;
            squareWaveTable = new List<double>();
           
        }
        public override bool Generate()
        {
            float val = 0;
            for (int i = 1; i < freq / 2; i++)
            {
                if(i % 2 != 0)
                val  += (float)((amp / (float)i) * Math.Sin(phase * 2 * Math.PI * i * freq));
              
            }
            squareWaveTable.Add(val);
            frame[0] = val;
            phase += samplePeriod;
            return true;
        }

        public override void Start()
        {
           
        }
        public float Generated()
        {
            return (float)frame[0];
        }
    }
}
