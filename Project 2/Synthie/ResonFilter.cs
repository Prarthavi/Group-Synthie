using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public class ResonFilter : AudioNode
    {
        private double amp = 0;
        private int count = 0;
        private float prev = 0;
        private float prev2 = 0;
        private float r = 0.7f;
        private float cosFilter = 0f;
        private double x1, y1, x2, y2 = 0;
        private List<double> table;
        private float freq;
        private float filterFreq;
        public  float Frequency{get => freq; set => freq = value;}
        public float R { get => r; set => r = value; }
        public float FilterFreq  {get => filterFreq; set => filterFreq = value; }
        private int index = 0;
        private int cnt = 0;
        public ResonFilter()
        {
          
        }

        public override bool Generate()
        {
            if (index >= cnt)
                index = index % cnt;
            frame[0] = table[index];
            index++;
            return true;
        }

        public double getAmplitude(float fr)
        {
           
            double tempX = Math.Cos(2 * Math.PI * fr * freq);
            double tempY = Math.Sin(2 * Math.PI * fr * freq);
            double dist1 = 1 / Math.Sqrt(Math.Pow(x1 - tempX, 2) + Math.Pow(y1 - tempY, 2));
            double dist2 = 1 / Math.Sqrt(Math.Pow(x2 - tempX, 2) + Math.Pow(y2 - tempY, 2));
            double response = dist1 * dist2;
            return response;
            //float result =amp;
            //count++;
            //if (count == 1)
            //    prev2 = amp;
            //else if (count == 2)
            //    prev = amp;
            //else
            //{
            //    result = amp + (R * cosFilter * prev) + (R * R * prev2);
            //    prev2 = prev;
            //    prev = result;
            //}
            //return result;

        }
        
        public override void Start()
        {
            float theta = (float)(2 * Math.PI * filterFreq);
            cosFilter = (float)Math.Cos(theta);
            double b = R * cosFilter;
            double a = 1;
            double c = R * R;
            table = new List<double>();
            double d = (b * b) - (4 * a * c);
            if (d > 0)
            {
                x1 = -b + (Math.Sqrt(d) / 2 * a);
                x2 = -b - (Math.Sqrt(d) / 2 * a);
            }
            if (d < 0)
            {
                x1 = -b / (2 * a);
                y1 = Math.Sqrt(-1 * d) / (2 * a);
                x2 = -b / (2 * a);
                y2 = -y1;
            }
            else
            {
                x1 = -b + (Math.Sqrt(d) / 2 * a);
            }

            for (double i = 0; i < 1/ freq; i+= samplePeriod)
            {
                table.Add(getAmplitude((float)i));
            }
            cnt = table.Count;
        }
    }
}
