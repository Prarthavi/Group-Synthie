using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class SawToothWaves : AudioNode
    {
        private double amp;
        private double freq;
        private double freq2;
        private List<double> sawToothWaveTable;
        private List<double> sawToothWaveTable2;
        private float index = 0f;
        private float index2 = 0f;
        private int cnt = 0;
        private int cnt2 = 0;
        public double Frequency { get => freq; set => freq = value; }
        public double Frequency2 { get => freq2; set => freq2 = value; }
        public double Amp { get => amp; set => amp = value; }
        public SawToothWaves()
        {
            amp = 1;
            freq = 440;
            sawToothWaveTable = new List<double>();
            samplePeriod = 1/44100f;


            //generate wavetable for the waveforms
            for (double i = 0; i < 1 / freq; i += samplePeriod)
            {
                float val = 0;
            
                for (int j = 1; j < freq / 2; j++)
                {

                     val += (float)(amp / (float)j * Math.Sin(2 * Math.PI * j * i * freq));
                    
                }

                sawToothWaveTable.Add(val);
                cnt = sawToothWaveTable.Count;

            }

        }

        public override bool Generate()
        {

            
                float increment1 = (float)(freq * cnt / (float)sampleRate);
                 float increment2 = (float)(freq2 * cnt2 / (float)sampleRate);

            if (index > cnt)
                index = index % cnt;

            if (index2 > cnt)
                index2 = index2 % cnt;
            frame[0] = amp * sawToothWaveTable[(int)index];
            frame[1] = amp * sawToothWaveTable2[(int)index2];

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
                for (int j = 1; j < 1 / (2 * samplePeriod); j++)
                {

                    val += (float)(amp / (float)j * Math.Sin(2 * Math.PI * j * i * freq));

                }

                float val2 = 0;
                for (int j = 1; j < 1 / (2 * samplePeriod); j++)
                {

                    val2 += (float)(amp / (float)j * Math.Sin(2 * Math.PI * j * i * freq2));

                }

                sawToothWaveTable.Add(val);
                sawToothWaveTable2.Add(val2);

            }
            cnt = sawToothWaveTable.Count;
            cnt2 = sawToothWaveTable2.Count;

        }
    }

       
    
}
