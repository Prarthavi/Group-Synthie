using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Synthie
{
    public class Subtractive : AudioNode
    {
        private double amp;
        private double freq;
        private double phase;
        private List<double> squareWaveTable;
        private List<double> triangleWaveTable;
        private List<double> sawToothWaveTable;
        private float index = 0f;

        public double Frequency { get => freq; set => freq = value; }
      

        public Subtractive(float sample)
        {
            phase = 0;
            amp = 1;
            freq = 440;
           // size = count;
            squareWaveTable = new List<double>();
            triangleWaveTable = new List<double>();
            sawToothWaveTable = new List<double>();
            samplePeriod = sample;
            //calculate the increase value using the number of samples and sample rate
            // increase = ((float)(freq * size / sampleRate));


            //generate wavetable for the waveforms
            for (double i = 0; i < 1/freq; i += samplePeriod)
            {
                float val = 0;
                for (int j = 1; j < freq / 2; j++)
                {
                    if (j % 2 != 0)
                    {
                        val += (float)(amp / (float)j * Math.Sin(2 * Math.PI * j * i * freq));
                    }
                }
                float val2 = 0.0f;


                //generate the triangle waveform value
                for (int j = 1; (2 * j) + 1 < freq / 2; j++)
                {

                    int n = (2 * j) + 1;


                    val2 += (float)(Math.Pow(-1, j) * (amp / (float)(n * n)) * Math.Sin(2 * Math.PI * n * i * freq));

                }
                float val3 = 0;

                //generate the sawtooth waveform value
                for (int j = 1; j < freq / 2; j++)
                {
                    val3 += (float)(amp / j * Math.Sin(2 * Math.PI * i * j * freq));
                }
                squareWaveTable.Add(val);
                triangleWaveTable.Add(val2);
                sawToothWaveTable.Add(val3);

            }
        }

        public override bool Generate()
        {

            int cnt = triangleWaveTable.Count;
            //int floor = (int)Math.Floor(index + samplePeriod);
           if (index >= cnt)
                index = index % cnt;
            //if (floor >= frameCount)
            //    floor = floor % frameCount;
            //int ceil = floor + 1;
            //if (ceil >= frameCount)
            //    ceil = ceil % frameCount;
            //frame[0] = ((index - floor) * squareWaveTable[ceil]) + ((ceil - index) * squareWaveTable[floor]);
            frame[0] = triangleWaveTable[(int)index];
            index++;
           // index = (float)(index + samplePeriod);
            //if (index >= frameCount)
            //    index = index % frameCount;
            //index = index + (int)Math.Floor(freq * size / (float)SampleRate);
            return true;
        }

        public override void Start()
        {
            throw new NotImplementedException();
        }

        internal float Generated()
        {
            return (float)frame[0];
        }
    }
}
