using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class TriangleWaves : AudioNode
    {
        private double amp;
        private double freq;
        private double freq2;
        private List<double> triangleWaveTable;
        private List<double> triangleWaveTable2;
        private float index = 0f;
        private float index2 = 0f;
        private int cnt = 0;
        private int cnt2 = 0;
        public double Frequency { get => freq; set => freq = value; }
        public double Frequency2 { get => freq2; set => freq2 = value; }
        public double Amp { get => amp; set => amp = value; }
        public TriangleWaves()
        {
            amp = 1;
            freq = 440;
            triangleWaveTable = new List<double>();
            triangleWaveTable2 = new List<double>();
            samplePeriod = 1/44100;

        }

        public override bool Generate()
        {

            float increment1 = (float)(freq * cnt / (float)sampleRate);
            float increment2 = (float)(freq2 * cnt2 / (float)sampleRate);

            if (index > cnt)
                index = index % cnt;

            if (index2 > cnt)
                index2 = index2 % cnt;
            frame[0] = amp * triangleWaveTable[(int)index];
            frame[1] = amp * triangleWaveTable2[(int)index2];

            //frame[0] = amp *( (ceil - index) * squareWaveTable[floor1]) + ((index - floor1) *squareWaveTable[floor1]);
            //frame[1] = amp * ((ceil2 - index2) * squareWaveTable2[floor2]) + ((index2 - floor2) * squareWaveTable2[floor2]);
            index += increment1;
            index2 += increment2;
            return true;
        }

        public override void Start()
        {
            for (double i = 0; i < 1 / freq; i += samplePeriod)
            {
                float val = 0;
                for (int j = 0; (2 * j) + 1 < 1 / (2 * samplePeriod); j++)
                {
                    int n = (2 * j) + 1;
                    val += (float)(Math.Pow(-1, j) * (amp / (float)(n * n)) * Math.Sin(2 * Math.PI * n * i * freq));

                }
                float val2 = 0;
                for (int j = 0; (2 * j) + 1 < (2 * samplePeriod); j++)
                {
                    int n = (2 * j) + 1;
                    val2 += (float)(Math.Pow(-1, j) * (amp / (float)(n * n)) * Math.Sin(2 * Math.PI * n * i * freq2));

                }
                triangleWaveTable.Add(val);
                triangleWaveTable2.Add(val2);
                
            }
            cnt = triangleWaveTable.Count;
            cnt2 = triangleWaveTable2.Count;
           
        }

      
    }
}
