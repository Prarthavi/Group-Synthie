/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Synthie
{
    internal class AdditiveCrossfadingInstrument : Instrument
    {
        private double duration;
        private SineWave sinewave = new SineWave();
        private SineWave sinewave2 = new SineWave();
        private double time;
        private double attack = 0.05;
        private double decay = 0.05;
        private double sustain = 0.8;
        private double release = 0.05;
        private double[] prev = { -1, -1 };
        private double x;
        private double y;

        public double Frequency { get => sinewave.Frequency; set => sinewave.Frequency = value; }
        public double Frequency2 { get => sinewave2.Frequency; set => sinewave2.Frequency = value; }
        public double Duration { get => duration; }
        public double Time { get => time; }
        public AdditiveCrossfadingInstrument()
        {
            duration = 0.1;
        }
        public void SetNote(Note note, Note note2, double secperbeat)
        {
            duration = note.Count * secperbeat;
            Frequency = Notes.NoteToFrequency(note.Pitch);
            Frequency2 = Notes.NoteToFrequency(note2.Pitch2);
        }
        public override bool Generate()
        {
            // Tell the component to generate an audio sample
            sinewave.Generate();
            frame = sinewave.Frame();

            sinewave2.Generate();
            frame = sinewave2.Frame();

            double gain;

            if (time < attack)
                gain = time / attack;
            else if (time < attack + decay)
                gain = 1 - ((time - attack) / decay) * (1 - sustain);
            else if (time < duration - release)
                gain = sustain;
            else
                gain = sustain * (duration - time) / release;


            frame[0] = sinewave.Frame(0) * gain;      //pull the adjusted sample
            frame[1] = sinewave.Frame(1) * gain;
            /*
            x = frame[0];
            y = frame[1];
            
            if (prev[0]!=-1)
            {
                double pct = time / duration;
                x = (1 - pct) * frame[0] + pct * prev[0];
                y = (1 - pct) * frame[1] + pct * prev[1];
            }

            prev[0] = frame[0];
            prev[1] = frame[1];

            frame[0] = x;
            frame[1] = y;

            // Read the component's sample and make it our resulting frame.

            // Update time
            time += samplePeriod;

            // We return true until the time reaches the duration.
            return time < duration;
        }

        public override void Start()
        {
            sinewave.SampleRate = SampleRate;
            sinewave.Start();
            time = 0;
        }

        public override void SetNote(Note note, double secperbeat)
        {
            throw new NotImplementedException();
        }
        /*
List<AdditiveInstrument> additiveInstruments = new List<AdditiveInstrument> ();
List<Note> note = new List<Note> ();

private SineWave sinewave = new SineWave();

public double Frequency { get => sinewave.Frequency; set => sinewave.Frequency = value; }

public AdditiveCrossfadingInstrument()
{
   additiveInstruments.Add(new AdditiveInstrument());
   additiveInstruments.Add(new AdditiveInstrument());
   //additiveInstruments[0].SetNote(n1, SecsPerBeat);
   //additiveInstruments[1].SetNote(n2, SecsPerBeat);    
}
public override void SetNote(Note note, double secperbeat)
{
   foreach (AdditiveInstrument additiveInstr in additiveInstruments)
       additiveInstr.SetNote(note, secperbeat);
}
public override bool Generate()
{            
   if (additiveInstruments[0].Generate() && additiveInstruments[1].Generate())
   {
       double pct = additiveInstruments[0].Time / additiveInstruments[0].Duration;
       frame[0] = (1 - pct) * additiveInstruments[0].Frame(0) + pct * additiveInstruments[1].Frame(0);
       frame[1] = (1 - pct) * additiveInstruments[0].Frame(1) + pct * additiveInstruments[1].Frame(1);
       return true;
   }
   return false;
}

public override void Start()
{
   foreach (AdditiveInstrument additiveInstr in additiveInstruments)
       additiveInstr.Start();
}

    }
}
*/