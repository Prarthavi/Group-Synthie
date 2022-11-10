using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class SquareWaves : Waves
    {

        public SquareWaves()
        {

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
                        val = (float)(val - ((float)(amp / (float)j * Math.Sin(2 * Math.PI * j * i * freq))));
                    }
                }
                float val2 = 0;
                for (int j = 1; j < 1 / (2 * samplePeriod); j++)
                {

                    if (j % 2 != 0)
                    {
                        val2 = (float)(val2 - ((float)(amp / (float)j * Math.Sin(2 * Math.PI * j * i * freq2))));
                    }
                }
                waves.Add(val);
                waves2.Add(val2);
            }

            cnt = waves.Count;
            cnt2 = waves2.Count;
        }

    }
}
