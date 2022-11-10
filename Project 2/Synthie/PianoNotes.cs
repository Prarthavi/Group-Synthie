using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Synthie
{
    public static class PianoNotes
    {
        static Dictionary<string, string> pNotes = new Dictionary<string, string>() {
            {"A0", "../../res/PianoSounds/A0l.wav"}, {"A#0", "../../res/PianoSounds/A0#l.wav"}, { "Bb0", "../../res/PianoSounds/A0#s.wav"}, { "B0", "../../res/PianoSounds/B0l.wav"},
            { "C1", "../../res/PianoSounds/C1l.wav"}, { "C#1", "../../res/PianoSound/C1#l.wav" }, { "Db1", "../../res/PianoSounds/C1#s.wav"}, { "D1", "../../res/PianoSounds/D1l.wav"}, { "D#1", "../../res/PianoSounds/D1#l.wav"},
            { "Eb1", "../../res/PianoSounds/D1#s.wav"}, { "E1", "../../res/PianoSounds/E1l.wav"}, { "F1", "../../res/Pianosounds/F1l.wav"}, { "F#1", "../../res/PianoSounds/F1#l.wav"}, { "Gb1", "../../res/PianoSounds/F1#s.wav"},
            { "G1", "../../res/PianoSounds/G1l.wav"}, { "G#1", "../../res/PianoSounds/G1#l.wav"}, { "Ab1", "../../res/PianoSounds/G1#s.wav"}, { "A1", "../../res/PianoSounds/A1l.wav"}, { "A#1", "../../res/PianoSounds/A1#l.wav"},
            { "Bb1", "../../res/PianoSounds/A1#s.wav"}, { "B1", "../../res/PianoSounds/B1l.wav"}, { "C2", "../../res/PianoSounds/C2l.wav"}, { "C#2", "../../res/PianoSounds/C2#l.wav"}, { "Db2", "../../res/PianoSounds/C2#s.wav"},
            { "D2", "../../res/PianoSounds/D2l.wav"}, { "D#2", "../../res/PianoSounds/D2#l.wav"}, { "Eb2", "../../res/PianoSounds/D2#s.wav"}, { "E2", "../../res/PianoSounds/E2l.wav"}, { "F2", "../../res/PianoSounds/F2l.wav"},
            { "F#2", "../../res/PianoSounds/F2#l.wav" }, { "Gb2", "../../res/PianoSounds/F2#s.wav"}, { "G2", "../../res/PianoSounds/G2l.wav"}, { "G#2", "../../res/PianoSounds/G2#l.wav"}, { "Ab2", "../../res/PianoSounds/G2#s.wav"},
            { "A2", "../../res/PianoSounds/A2l.wav" }, { "A#2", "../../res/PianoSounds/A2#l.wav"}, { "Bb2", "../../res/PianoSounds/A2#s.wav"}, { "B2", "../../res/PianoSounds/B2l.wav"}, { "C3", "../../res/PianoSounds/C3l.wav"},
            { "C#3", "../../res/PianoSounds/C3#l.wav"}, { "Db3", "../../res/PianoSounds/C3#s.wav"}, { "D3", "../../res/PianoSounds/D3l.wav"}, { "D#3", "../../res/PianoSounds/D3#l.wav"}, { "Eb3", "../../res/PianoSounds/D3#s.wav"},
            { "E3", "../../res/PianoSounds/E3l.wav"}, { "F3", "../../res/PianoSounds/F3l.wav"}, { "F#3", "../../res/PianoSounds/F3#l.wav"}, { "Gb3", "../../res/PianoSounds/F3#s.wav"}, { "G3", "../../res/PianoSounds/G3l.wav"},
            { "G#3", "../../res/PianoSounds/G3#l.wav"}, { "Ab3", "../../res/PianoSounds/G3#s.wav"}, { "A3", "../../res/PianoSounds/A3l.wav"}, { "A#3", "../../res/PianoSounds/A3#l.wav"}, { "Bb3", "../../res/PianoSounds/A3#s.wav"},
            { "B3", "../../res/PianoSounds/B3l.wav"}, { "C4", "../../res/PianoSounds/C4l.wav"}, { "C#4", "../../res/PianoSounds/C4#l.wav"}, { "Db4", "../../res/PianoSounds/C4#s.wav"}, { "D4", "../../res/PianoSounds/D4l.wav"},
            { "D#4", "../../res/PianoSounds/D4#l.wav"}, { "Eb4", "../../res/PianoSounds/D4#s.wav"}, { "E4", "../../res/PianoSounds/E4l.wav"}, { "F4", "../../res/PianoSounds/F4l.wav"}, { "F#4", "../../res/PianoSounds/F4#l.wav"},
            { "Gb4", "../../res/PianoSounds/F4#s.wav"}, { "G4", "../../res/PianoSounds/G4l.wav"}, { "G#4", "../../res/PianoSounds/G4#l.wav"}, { "Ab4", "../../res/PianoSounds/G4#s.wav"}, { "A4", "../../res/PianoSounds/A4l.wav"},
            { "A#4", "../../res/PianoSounds/A4#l.wav"}, { "Bb4", "../../res/PianoSounds/A4#swav"}, { "B4", "../../res/PianoSounds/B4l.wav"}, { "C5", "../../res/PianoSounds/C5l.wav"}, { "C#5", "../../res/PianoSounds/C#5l.wav"},
            { "Db5", "../../res/PianoSounds/C5#s.wav"}, { "D5", "../../res/PianoSounds/D5l.wav"}, { "D#5", "../../res/PianoSounds/D5#l.wav"}, { "Eb5", "../../res/PianoSounds/D5#s.wav"}, { "E5", "../../res/PianoSounds/E5l.wav"},
            { "F5", "../../res/PianoSounds/F5l.wav"}, { "F#5", "../../res/PianoSounds/F5#l.wav"}, { "Gb5", "../../res/PianoSounds/F5#s.wav"}, { "G5", "../../res/PianoSounds/G5l.wav"}, { "G#5", "../../res/PianoSounds/G5#l.wav"},
            { "Ab5", "../../res/PianoSounds/G5#s.wav"}, { "A5", "../../res/PianoSounds/A5l.wav"}, { "A#5", "../../res/PianoSounds/A5#l.wav"}, { "Bb5", "../../res/PianoSounds/A5#s.wav"}, { "B5", "../../res/PianoSounds/B5l.wav"},
            { "C6", "../../res/PianoSounds/C6l.wav"}, { "C#6", "../../res/PianoSounds/C6#l.wav"}, { "Db6", "../../res/PianoSounds/C6#s.wav"}, { "D6", "../../res/PianoSounds/D6l.wav"}, { "D#6", "../../res/PianoSounds/D6#l.wav"},
            { "Eb6", "../../res/PianoSounds/D6#l.wav"}, { "E6", "../../res/PianoSounds/E6l.wav"}, { "F6", "../../res/PianoSounds/F6l.wav"}, { "F#6", "../../res/PianoSounds/F6#l.wav"}, { "Gb6", "../../res/PianoSounds/F6#s.wav"},
            { "G6", "../../res/PianoSounds/G6l.wav"}, { "G#6", "../../res/PianoSounds/G6#l.wav"}, { "Ab6", "../../res/PianoSounds/G6#s.wav"}, { "A6", "../../res/PianoSounds/A6l.wav"}, { "A#6", "../../res/PianoSounds/A6#l.wav"},
            { "Bb6", "../../res/PianoSounds/A6#s.wav"}, { "B6", "../../res/PianoSounds/B6l.wav"}, { "C7", "../../res/PianoSounds/C7l.wav"}, { "C#7", "../../res/PianoSounds/C7#l.wav"}, { "Db7", "../../res/PianoSounds/C7#s.wav"},
            { "D7", "../../res/PianoSounds/D7l.wav"}, { "D#7", "../../res/PianoSounds/D7#l.wav"}, { "Eb7", "../../res/PianoSounds/D7#s.wav"}, { "E7", "../../res/PianoSounds/E7l.wav"}, { "F7", "../../res/PianoSounds/F7l.wav"},
            { "F#7", "../../res/PianoSounds/F7#l.wav"}, { "Gb7", "../../res/PianoSounds/F7#s.wav"}, { "G7", "../../res/PianoSounds/G7l.wav"}, { "G#7", "../../res/PianoSounds/G7#l.wav"}, { "Ab7", "../../res/PianoSounds/G7#s.wav"},
            { "A7", "../../res/PianoSounds/A7l.wav"}, { "A#7", "../../res/PianoSounds/A7#l.wav"}, { "Bb7", "../../res/PianoSounds/A7#l.wav"}, { "B7", "../../res/PianoSounds/B7l.wav"}, { "C8", "../../res/PianoSounds/C8l.wav"},
            { "Pedal", "../../res/PianoSounds/pedalu.wav" } };

        public static string NoteToFile(string name)
        {
            if (pNotes.ContainsKey(name))
                return pNotes[name];
            return null;
        }
    }
}
