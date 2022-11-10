using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Synthie
{
    public class Note : IComparable<Note>
    {
        private string instrument;
        private int measure;
        private double beat;
        private double count;
        private string pitch;
        private double freq;
        private double amplitude;
        private string effect;


        public double Beat { get => beat; set => beat = value; }
        public double Count { get => count; set => count = value; }
        public string Instrument { get => instrument; set => instrument = value; }
        public int Measure { get => measure; set => measure = value; }
        public string Pitch { get => pitch; set => pitch = value; }
        public double Freq { get => freq; set => freq = value; }
        public double Amplitude { get => amplitude; set => amplitude = value; }
        public string Effect { get => effect; set => effect = value; }

        public Note()
        {

        }
        public int CompareTo(Note b)
        {
            if (measure < b.Measure)
                return -1;
            if (measure > b.Measure)
                return 1;
            if (beat < b.Beat)
                return -1;

            return 1;
        }
        public void XmlLoad(XmlNode xml, string instrument)
        {
            this.instrument = instrument;


            // Get a list of all attribute nodes and the
            // length of that list
            foreach (XmlAttribute attr in xml.Attributes)
            {
                if (attr.Name == "measure")
                {
                    measure = Convert.ToInt32(attr.Value) - 1;
                }

                if (attr.Name == "beat")
                {
                    beat = Convert.ToDouble(attr.Value) - 1;
                }

                if (attr.Name == "count")
                {
                    count = Convert.ToDouble(attr.Value);
                }

                if (attr.Name == "note")
                {
                    pitch = attr.Value; 
                    freq = Notes.NoteToFrequency(pitch);
                }

                if (attr.Name == "amplitude")
                {
                    amplitude = Convert.ToDouble(attr.Value);
                }

                if (attr.Name == "effect")
                {
                    effect = attr.Value;
                }
            }
        }
    }
}
