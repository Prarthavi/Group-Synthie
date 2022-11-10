using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class TriangleWaves : Waves
    {

        public TriangleWaves()
        {

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
                    for (int j = 0; (2 * j) + 1 < 1 / (2 * samplePeriod); j++)
                    {
                        int n = (2 * j) + 1;
                        val2 += (float)(Math.Pow(-1, j) * (amp / (float)(n * n)) * Math.Sin(2 * Math.PI * n * i * freq2));

                    }
                    if (val <= 1 && val >= -1)
                    {
                        waves.Add(val);
                    }
                    if (val2 <= 1 && val >= -1)
                    {
                        waves2.Add(val2);
                    }
                
                }

            cnt = waves.Count;
                cnt2 = waves.Count;
        
     
        }

      
    }
}
