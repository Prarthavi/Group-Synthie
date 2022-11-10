using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class SawToothWaves : Waves
    {

        public SawToothWaves()
        {

        }

    


        public override void Start()
        {
            amp = 1;
            for (double i = 0; i < 1 /( freq); i += samplePeriod)
            {
                float val = 0;
                for (int j =   1; j < sampleRate / (2 *freq); j++)
                {

                    val += (float)( Math.Sin(2 * Math.PI * j * i * freq) / j);

                }


                float val2 = 0;
                for (int j = 1; j < sampleRate / (2 * freq); j++)
                {

                    val2 += (float)( Math.Sin(2 * Math.PI * j * i * freq2) / j);

                }
                if(val <= 1 && val >= -1)
                {
                    waves.Add(val);
                }
                if(val2 <= 1 && val >= -1)
                {
                    waves2.Add(val2);
                }
                

            }
            cnt = waves.Count;
            cnt2 = waves2.Count;

        }
    }

       
    
}
