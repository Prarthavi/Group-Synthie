using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Synthie
{
    public class SongScore
    {
        private int channels;
        private int sampleRate;
        private double samplePeriod;
        private double bpm;                   // Beats per minute
        private int beatspermeasure;  // Beats per measure
        private double secperbeat;        // Seconds per beat
        private int currentNote;          // The current note we are playing
        private int measure;              // The current measure
        private double beat;              // The current beat within the measure

        private List<Note> notes = new List<Note>();
        public int Channels { get => channels; set => channels = value; }
        public int SampleRate { get => sampleRate; set => sampleRate = value; }
        public double SamplePeriod { get => samplePeriod; set => samplePeriod = value; }

        private double time;

        private List<Instrument> instruments = new List<Instrument>();

        /// <summary>
        ///  Get the time since we started generating audio
        /// </summary>
        public double Time { get => time; }


        public SongScore()
        {
            channels = 2;
            sampleRate = 44100;
            samplePeriod = 1.0 / sampleRate;

            time = 0;

            bpm = 120;
            secperbeat = 0.5;
            beatspermeasure = 4;
        }

        /// <summary>
        /// Ready the generation
        /// </summary>
        public void Start()
        {
            instruments.Clear();
            currentNote = 0;
            measure = 0;
            beat = 0;
            time = 0;
        }

        /// <summary>
        /// Makes a single sound sample. The frame length should be the same as the number of channels.
        /// </summary>
        /// <param name="frame">The sample</param>
        /// <returns>true if there is any more samples to generate.</returns>
        public bool Generate(double[] frame)
        {

            while (currentNote < notes.Count)
            {
                // Get the current note
                Note note = notes[currentNote];

                // If the measure is in the future we can't play
                // this note just yet.
                if (note.Measure > measure)
                    break;

                // If this is the current measure, but the
                // beat has not been reached, we can't play
                // this note.
                if (note.Measure == measure && note.Beat > beat)
                    break;

                //
                // Play the note!
                //

                // Create the instrument object
                Instrument instrument = null;
                if (note.Instrument == "ToneInstrument")
                {
                    instrument = new ToneInstrument();
                }
<<<<<<< HEAD
                else if (note.Instrument.Substring(0,4) == "Drum")
                {
                    instrument = new DrumInstrument(note.Instrument);
                }
=======
                else if (note.Instrument == "Piano")
                {
                    instrument = new Piano();
                }
                else if (note.Instrument == "AdditiveInstrument")
                {
                    instrument = new AdditiveInstrument();
                }
                 else if (note.Instrument == "SubtractiveInstrument")
                {
                    instrument = new SubtractiveInstrument();
                }

                /*
                else if (note.Instrument == "AdditiveCrossfadingInstrument")
                {
                    instrument = new AdditiveCrossfadingInstrument();
                }*/
>>>>>>> main

                // Configure the instrument object
                if (instrument != null)
                {
                    instrument.SampleRate = SampleRate;
                    instrument.SetNote(note,secperbeat);
                    instrument.Start();

                    instruments.Add(instrument);
                }
                
                //EFFECTS PROCESSING HERE
                if (note.Effect != "") //If effect then process effect
                {
                    //create a new note for the effect
                    Note newNote = new Note();
                    newNote = note;
                    switch (note.Effect)
                    {
                        case "Chorus":
                            newNote.Effect = "";
                            newNote.Amplitude /= 5;
                            for (int i = 0; i < 10; i ++)
                            {
                                Note newNote3 = new Note();
                                newNote3 = note;
                                newNote3.Beat = note.Beat + i * 5 * SamplePeriod;
                                newNote3.Freq = note.Freq + i;
                                notes.Add(newNote3);
                            }
                            break;
                        case "Reverb":
                            //newNote.Effect = "";
                            //newNote.Amplitude /= 5;
                            while ((newNote.Amplitude ) > 0.01)
                            {
                                newNote.Amplitude *= 0.95;
                                newNote.Beat += newNote.Count * 0.2;
                                Note newNote3 = new Note();
                                newNote3 = newNote;
                                notes.Add(newNote3);
                            }
                            break;
                        case "Flanging":
                            newNote = note;
                            Note newNote2 = new Note();
                            newNote2 = note;
                            note.Effect = "";
                            newNote.Beat += 2 * SamplePeriod;
                            newNote2.Beat += 50 * SamplePeriod;
                            newNote.Count -= 2 * SamplePeriod;
                            newNote2.Count -= 50 * SamplePeriod;


                            notes.Add(newNote);
                            notes.Add(newNote2);
                            break;
                        case "ZeroFilter":
                            note.Effect = "";
                            newNote = note;
                            newNote.Freq += 1;
                            notes.Add(newNote);
                            break;
                        default:
                            break;
                    }

                }

                currentNote++;
            }

            //
            // Phase 2: Clear all channels to silence 
            //

            for (int c = 0; c < Channels; c++)
            {
                frame[c] = 0;
            }

            //
            // Phase 3: Play an active instruments
            //

            //
            // We have a list of active (playing) instruments.  We iterate over 
            // that list.  For each instrument we call generate, then add the
            // output to our output frame.  If an instrument is done (Generate()
            // returns false), we remove it from the list.
            //

            List<Instrument> toRemove = new List<Instrument>();
            foreach (Instrument instrument in instruments)
            {

                // Call the generate function
                if (instrument.Generate())
                {
                    // If we returned true, we have a valid sample.  Add it 
                    // to the frame.
                    for (int c = 0; c < Channels; c++)
                    {
                        frame[c] += instrument.Frame(c);
                    }
                }
                else
                {
                    // If we returned false, the instrument is done.  mark it for removal
                    toRemove.Add(instrument);
                }
            }

            foreach (Instrument i in toRemove)
                instruments.Remove(i);

            //
            // Phase 4: Advance the time and beats
            //

            // Time advances by the sample period
            time += SamplePeriod;

            // Beat advances by the sample period divided by the 
            // number of seconds per beat.  The inverse of seconds
            // per beat is beats per second.
            beat += SamplePeriod / secperbeat;

            // When the measure is complete, we move to
            // a new measure.  We might be a fraction into
            // the new measure, so we subtract out rather 
            // than just setting to zero.
            if (beat > beatspermeasure)
            {
                beat -= beatspermeasure;
                measure++;
            }

            //
            // Phase 5: Determine when we are done
            //

            // We are done when there is nothing to play. 
            return instruments.Count > 0 || currentNote < notes.Count;
        }

        public void Clear()
        {
            notes.Clear();
            instruments.Clear();
        }

        public void OpenScore(string filename)
        {
            Clear();

            //
            // Open an XML document
            //
            XmlDocument reader = new XmlDocument();
            reader.Load(filename);

            //
            // Traverse the XML document in memory!!!!
            // Top level tag is 
            //
            //Display the contents of the child nodes.
            foreach (XmlNode node in reader.ChildNodes)
            {
                if (node.Name == "score")
                {
                    XmlLoadScore(node);
                }
            }
            notes.Sort();
        }

        private void XmlLoadScore(XmlNode xml)
        {
            // Get a list of all attribute nodes and the
            // length of that list
            foreach (XmlAttribute attr in xml.Attributes)
            {
                if (attr.Name == "bpm")
                {
                    bpm = Convert.ToDouble(attr.Value);
                    secperbeat = 1 / (bpm / 60);
                }
                else if (attr.Name == "beatspermeasure")
                {
                    beatspermeasure = Convert.ToInt32(attr.Value);
                }
            }

            foreach (XmlNode node in xml.ChildNodes)
            {
                if (node.Name == "instrument")
                {
                    XmlLoadInstrument(node);
                }
            }
        }

        private void XmlLoadInstrument(XmlNode xml)
        {
            string instrument = "";


            // Get a list of all attribute nodes and the
            // length of that list
            foreach (XmlAttribute attr in xml.Attributes)
            {
                if (attr.Name == "instrument")
                {
                    instrument = attr.Value;
                }
            }

            foreach (XmlNode node in xml.ChildNodes)
            {
                if (node.Name == "note")
                {
                    XmlLoadNote(node, instrument);
                }
            }
        }

        private void XmlLoadNote(XmlNode xml, string instrument)
        {
            Note newNote = new Note();
           
            notes.Add(newNote);
            newNote.XmlLoad(xml, instrument);
        }
    }
}
