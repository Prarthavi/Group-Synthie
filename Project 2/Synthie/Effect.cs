using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    internal class Effect
    {
        private string type;
        private float[] tmp = new float[2];
        private Queue<float[]> buffer;
        private double time;
        //public double Frequency { get => sinewave.Frequency; set => sinewave.Frequency = value; }

        //public double Duration { get => duration; }
        public Effect(string name)
        {
            type = name;
        }

        public float[] EffectNote(Note note)
        {
            float[] tmp = new float[2];
            //push note on queue
            buffer.Append(tmp);
            //process note
            //return
            return tmp;
        }

        public void setupEffect()
        {
        }
    }
}
