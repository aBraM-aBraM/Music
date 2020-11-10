using System;

namespace MusicThingy
{
    static class SoundManager
    {
        public enum ChordType { Major, Minor}
        // lowest note
        const float cMinimum = 65.41f;
        // default octave
        public const int defaultOctave = 3;
        // random for improvising
        static Random rnd = new Random();

        /// <summary>
        /// Return frequency of a given note
        /// </summary>
        /// <param name="index">Index of the note across the chromatic scale (1-12) </param>
        /// <param name="octave">Octave of choice</param>
        public static int GetNoteFreq(int index, int octave = defaultOctave)
        {
            return (int)(cMinimum * Math.Pow(2, (12 * (float)octave + index - 1) / 12));
        }
        /// <summary>
        /// Return frequency of a given note
        /// </summary>
        /// <param name="note">Musical Note: 'name' + (null/#) </param>
        /// <param name="octave">Octave of choice</param>
        public static int GetNoteFreq(string note, int octave = defaultOctave)
        {
            if (note.Length > 2 || note.Length < 1) throw new Exception("Syntax Error: note = 'char' + (null/#)");

            // number of half steps forward from cMinimum
            int N = 0;

            if (note[0] == 'c' || note[0] == 'C')
            {
                N = 0;
            }
            if (note[0] == 'd' || note[0] == 'D')
            {
                N = 2;
            }
            if (note[0] == 'e' || note[0] == 'E')
            {
                N = 4;
            }
            if (note[0] == 'f' || note[0] == 'F')
            {
                N = 5;
            }
            if (note[0] == 'g' || note[0] == 'G')
            {
                N = 7;
            }
            if (note[0] == 'a' || note[0] == 'A')
            {
                N = 9;
            }
            if (note[0] == 'b' || note[0] == 'B')
            {
                N = 11;
            }

            if (note.Length > 1 && note[1] == '#')
            {
                N++;
            }

            return (int)(cMinimum * Math.Pow(2, (float)(12 * octave + N) / 12));
        }
       
        public static int GetChordFreq(string root, ChordType chordType)
        {
            return 0;
        }
        /// <summary>
        /// Get the name of a note by it's relatives
        /// </summary>
        /// <param name="note">Musical Note: 'name' + (null/#) </param>
        /// <param name="interval">Interval (difference) from current note. Natural number</param>
        /// <returns></returns>
        public static string GetNoteName(string note, int interval)
        {
            if (note.Length > 2 || note.Length < 1) throw new Exception("Syntax Error: note = 'char' + (null/#)");

            // number of half steps forward from cMinimum
            int N = 0;

            if (note[0] == 'c' || note[0] == 'C')
            {
                N = 0;
            }
            if (note[0] == 'd' || note[0] == 'D')
            {
                N = 2;
            }
            if (note[0] == 'e' || note[0] == 'E')
            {
                N = 4;
            }
            if (note[0] == 'f' || note[0] == 'F')
            {
                N = 5;
            }
            if (note[0] == 'g' || note[0] == 'G')
            {
                N = 7;
            }
            if (note[0] == 'a' || note[0] == 'A')
            {
                N = 9;
            }
            if (note[0] == 'b' || note[0] == 'B')
            {
                N = 11;
            }
            if (note.Length > 1 && note[1] == '#')
            {
                N++;
            }
            N += interval;
            N -= (N / 12) * 12;

            return (NoteNameByLevel(N));

        }
        /// <summary>
        /// Returns note's name by it's level on the chromatic scale
        /// </summary>
        /// <param name="index">The index on the chromatic scale</param>
        public static string NoteNameByLevel(int index)
        {
            switch (index)
            {
                case 0:
                    return "c";
                case 1:
                    return "c#";
                case 2:
                    return "d";
                case 3:
                    return "d#";
                case 4:
                    return "e";
                case 5:
                    return "f";
                case 6:
                    return "f#";
                case 7:
                    return "g";
                case 8:
                    return "g#";
                case 9:
                    return "a";
                case 10:
                    return "a#";
                case 11:
                    return "b";
                default:
                    return "h";
            }
        }
    }
}
