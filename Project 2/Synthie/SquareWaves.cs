using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class SquareWaves : AudioNode
    {
        private double amp;
        private double freq;
        private List<double> squareWaveTable;
        private List<double> squareWaveTable2;
        private float index = 0;
        private int cnt = 0;
        private float index2 = 0;
        private int cnt2 = 0;
        public double Frequency { get => freq; set => freq = value; }
        public double Frequency2 { get => freq2; set => freq2 = value; }
        private double freq2;
        public double Amp { get => amp; set => amp = value; }
        public SquareWaves()
        {
            amp = 1;
            freq = 440;
            squareWaveTable = new List<double>();
            squareWaveTable2 = new List<double>();
            samplePeriod = 1/ 44100;
            freq2 = 440;
           
          
        }

        public override bool Generate()
        {
           
            float increment1 = (float)(freq * cnt /(float) sampleRate);
            float increment2 = (float)(freq2 * cnt2 / (float)sampleRate);
            //int floor1 = (int)Math.Floor(index);
            //int floor2 = (int)Math.Floor(index2);
            //int ceil = floor1 + 1;
            //int ceil2 = floor2 + 1;
            //if (ceil >= cnt)
            //    ceil = ceil % cnt;
            //if (ceil2 >= cnt)
            //    ceil2 = ceil2 % cnt;
            //if (ceil >= cnt)
            //    ceil = ceil % cnt;
            //if (floor1 >= cnt)
            //    floor1 = floor1 % cnt;
            //if (floor2 >= cnt)
            //    floor2 = floor2 % cnt;

            if (index > cnt)
                index = index % cnt;

            if (index2 > cnt)
                index2 = index2 % cnt;
            frame[0] = amp * squareWaveTable[(int)index];
            frame[1] = amp * squareWaveTable2[(int)index2];

            //frame[0] = amp *( (ceil - index) * squareWaveTable[floor1]) + ((index - floor1) *squareWaveTable[floor1]);
            //frame[1] = amp * ((ceil2 - index2) * squareWaveTable2[floor2]) + ((index2 - floor2) * squareWaveTable2[floor2]);
            index+=increment1;
            index2+=increment2;
            return true;
        }

        public override void Start()
        {
            //generate wavetable for the waveforms
            for (double i = 0; i < 1 / freq; i += samplePeriod)
            {
                float val = 0;
                for (int j = 1; j < 1 / (2 * samplePeriod); j++)
                {

                    if (j % 2 != 0)
                    {
                        val = (float)(val + ((float)(amp / (float)j * Math.Sin(2 * Math.PI * j * i * freq))));
                    }
                }
                float val2 = 0;
                for (int j = 1; j < 1 / (2 * samplePeriod); j++)
                {

                    if (j % 2 != 0)
                    {
                        val2 = (float)(val2 + ((float)(amp / (float)j * Math.Sin(2 * Math.PI * j * i * freq2))));
                    }
                }
                squareWaveTable.Add(val);
                squareWaveTable2.Add(val2);
                cnt = squareWaveTable.Count;
                cnt2 = squareWaveTable2.Count;
            }
        }

        internal float[] Generated()
        {
            float[] result = new float[2];
            result[0] = (float)frame[0];
            result[1] = (float)frame[1];
            return result;
        }
    }
}
