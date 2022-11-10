using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public abstract class Waves : AudioNode
    {
        protected double amp;
        protected double freq;
        protected double freq2;
        protected List<double> waves;
        protected List<double> waves2;
        protected float index = 0f;
        protected float index2 = 0f;
        protected int cnt = 0;
        protected int cnt2 = 0;
        public double Frequency { get => freq; set => freq = value; }
        public double Frequency2 { get => freq2; set => freq2 = value; }
        public double Amp { get => amp; set => amp = value; }

        public Waves()
        {
            amp = 1;
            freq = 220;
            freq2 = 220;
            waves = new List<double>();
            waves2 = new List<double>();
            samplePeriod = 1 / 22000;
        }

        public override bool Generate()
        {


            float increment1 = (float)(freq * cnt / (float)sampleRate);
            float increment2 = (float)(freq2 * cnt2 / (float)sampleRate);

            if (index >= cnt)
                index = index % cnt;

            if (index2 >= cnt)
                index2 = index2 % cnt;
            frame[0] = amp * waves[(int)index];
            frame[1] = amp * waves2[(int)index2];
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
            //frame[0] = amp *( (ceil - index) * waves[floor1]) + ((index - floor1) *waves[floor1]);
            //frame[1] = amp * ((ceil2 - index2) * waves2[floor2]) + ((index2 - floor2) * waves2[floor2]);
            index += increment1;
            index2 += increment2;
            return true;
        }

        public override void Start()
        {
          

        }
    }
}
