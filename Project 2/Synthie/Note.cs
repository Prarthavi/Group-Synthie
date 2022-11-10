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
        private double pedalSus;
        private double speed; 

        //private string pitch2;
        private double vibrato;
        private string waveType;
          private Boolean filterEnvelope;
          private double r;
        private double resonFreq;
        public double Beat { get => beat; }
        public double Count { get => count; }
        public string Instrument { get => instrument; }
        public int Measure { get => measure; }
        public string Pitch { get => pitch; }
        public double PedalSus { get => pedalSus; }

        public double Speed { get => speed; }
        //public string Pitch2 { get => pitch2; }
        public double Vibrato { get => vibrato; }
        public double R { get => r; }
        public double ResonFreq { get => r; }
        public Boolean FilterEnvelope { get => filterEnvelope;}
         public string WaveType { get => waveType; }
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
                }

                if (attr.Name == "sustain")
                {
                    pedalSus = Convert.ToDouble(attr.Value);
                }

                if (attr.Name == "speed")
                {
                    speed = Convert.ToDouble(attr.Value);
                }
                if(attr.Name == "vibrato")
                {
                    vibrato = Convert.ToDouble(attr.Value);
                }

                /*
                if(attr.Name == "note2")
                {
                    pitch2 = attr.Value;
                }*/
                if((attr.Name == "ResonFreq")
                {
                    resonFreq = Convert.ToDouble(attr.Value);
                }
                if((attr.Name == "waveType")
                {
                   waveType = attr.Value;
                }
                 if (attr.Name == "Radius")
                {
                    r = Convert.ToDouble(attr.Value);
                }
                if(attr.Name == "filterEnvelope")
                {
                    filterEnvelope = attr.Value == "true" ? true : false;
                }
            }
        }
    }
}
