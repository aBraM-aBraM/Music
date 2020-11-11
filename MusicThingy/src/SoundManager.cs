using MusicThingy.src;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MusicThingy
{
    static class SoundManager
    {
        public enum ChordType { Major, Minor, Seven, MajorSeven, MinorSeven, HalfDiminshed}
        public enum ScaleType { MAJOR, MINOR, PENTATONIC_MINOR, PENTATONIC_MAJOR }
        static Dictionary<ChordType, string> chordIntervals = new Dictionary<ChordType, string>()
        {
            {ChordType.Major, "0,4,7" },
            {ChordType.Minor, "0,3,7" },
            {ChordType.Seven , "0,4,7,10" },
            {ChordType.MajorSeven, "0,4,7,11" },
            {ChordType.MinorSeven, "0,3,7,10" },
            {ChordType.HalfDiminshed, "0,3,7,10" }
        };
        static Dictionary<ScaleType, string> scaleIntervals = new Dictionary<ScaleType, string>()
        {   { ScaleType.MAJOR , "0,2,4,5,7,9,11"},
            { ScaleType.MINOR, "0,2,3,5,7,8,10"},
            { ScaleType.PENTATONIC_MINOR, "0,3,5,7,10" },
            { ScaleType.PENTATONIC_MAJOR, "0,4,5,7,11" }
        };

        public static readonly string[] AutumnLeaves = { "am7","d7", "gmaj7","cmaj7","f#m7b5","b7","em","e7" };
        public static readonly string[] Blues = { "a7","a7", "a7","a7","d7","d7","a7","a7","e7","d7","a7","e7"};
        public static readonly string[] SimpleCMaj = { "c", "am", "f", "g" };

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
        public static int GetNoteFreq(string note, int octave = defaultOctave, int offset = 0)
        {
            if (note.Length > 2 || note.Length < 1) throw new SyntaxErrorException("Syntax Error: note = 'char' + (null/#)");

            // number of half steps forward from cMinimum
            int N = 0;

            if (Char.ToLower(note[0]) == 'c')
            {
                N = 0;
            }
            if (Char.ToLower(note[0]) == 'd')
            {
                N = 2;
            }
            if (Char.ToLower(note[0]) == 'e')
            {
                N = 4;
            }
            if (Char.ToLower(note[0]) == 'f')
            {
                N = 5;
            }
            if (Char.ToLower(note[0]) == 'g')
            {
                N = 7;
            }
            if (Char.ToLower(note[0]) == 'a')
            {
                N = 9;
            }
            if (Char.ToLower(note[0]) == 'b')
            {
                N = 11;
            }

            if (note.Length > 1 && note[1] == '#')
            {
                N++;
            }

            N += offset;

            return (int)(cMinimum * Math.Pow(2, (float)(12 * octave + N) / 12));
        }
        /// <summary>
        /// Return frequency using offset from any 'N' existing frequency
        /// </summary>
        /// <param name="freq"></param>
        /// <param name="octave"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int GetOffsetFreq(int freq, int octave, int offset) => (int)(freq * Math.Pow(2, (float)offset/12));
        /// <summary>
        /// Return frequency of chord using standard chord symbolizations
        /// </summary>
        /// <param name="chord"></param>
        /// <param name="octave"></param>
        /// <returns></returns>
        public static int GetChordFreq(string chord, int octave = defaultOctave)
        {
            if (chord.Length > 6 || chord.Length < 1) throw new SyntaxErrorException("chord = 'char' + (null/#) + (null/maj7,m7,m7b5,7,m)");

            int rootFreq = 0;
            if (chord.Length > 1 && chord[1] == '#')
            {
                rootFreq = GetNoteFreq(chord[0].ToString() + chord[1].ToString());
            }
            else
            {
                rootFreq = GetNoteFreq(chord[0].ToString());
            }

            if (chord.Contains("maj7")) return GetChordFreq(rootFreq, ChordType.MajorSeven);
            if (chord.Contains("m7b5")) return GetChordFreq(rootFreq, ChordType.HalfDiminshed);
            if (chord.Contains("m7")) return GetChordFreq(rootFreq, ChordType.MinorSeven);
            if (chord.Contains("7")) return GetChordFreq(rootFreq, ChordType.Seven);
            if (chord.Contains("m")) return GetChordFreq(rootFreq, ChordType.Minor);
            return GetChordFreq(rootFreq, ChordType.Major);
        }
       /// <summary>
       /// Returns frequency of the chord as one note (frequency differences of notes)
       /// </summary>
       /// <param name="root"></param>
       /// <param name="chordType"></param>
       /// <param name="octave"></param>
       /// <returns></returns>
        public static int GetChordFreq(int rootFreq, ChordType chordType, int octave = defaultOctave)
        {
            int chordFreq = 0;
            // array to store each of the chord's notes' intervals
            int[] intervals = chordIntervals[chordType].Split(",").Select(Int32.Parse).ToArray();
            Console.WriteLine(string.Join(",",intervals));
            chordFreq = rootFreq;
            for (int i = 1; i < intervals.Length; i++)
            {
                int tmp = GetOffsetFreq(rootFreq, octave, intervals[i]);
                chordFreq = Math.Abs(chordFreq - tmp);
            }
            return chordFreq;
        }
        /// <summary>
        /// Return an array of note frequencies of the chord's notes
        /// </summary>
        /// <param name="rootFreq"></param>
        /// <param name="chordType"></param>
        /// <param name="octave"></param>
        /// <returns></returns>
        public static int[] GetChordNotesFreq(int rootFreq, ChordType chordType, int octave = defaultOctave)
        {
            // array to store each of the chord's notes' intervals and override with note frequencies
            int[] intervals = chordIntervals[chordType].Split(",").Select(Int32.Parse).ToArray();
            intervals[0] = rootFreq;
            for (int i = 1; i < intervals.Length; i++)
            {
                intervals[i] = GetOffsetFreq(rootFreq, octave, intervals[i]);
            }
            return intervals;
        }
        /// <summary>
        /// Return an array of note frequencies of the scale's notes using note name
        /// utilizing GetScaleNotesFreq(int, ScaleType, int)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="scaleType"></param>
        /// <param name="octave"></param>
        /// <returns></returns>
        public static int[] GetScaleNotesFreq(string root, ScaleType scaleType, int octave = defaultOctave)
        {
           return GetScaleNotesFreq(GetNoteFreq(root), scaleType, defaultOctave);
        }
        /// <summary>
        /// Return an array of note frequencies of the scale's notes using frequencies
        /// </summary>
        /// <param name="rootFreq"></param>
        /// <param name="scaleType"></param>
        /// <param name="octave"></param>
        /// <returns></returns>
        public static int[] GetScaleNotesFreq(int rootFreq, ScaleType scaleType, int octave = defaultOctave)
        {
            // array to store each of the scale's notes' intervals and override with scale notes frequencies
            int[] intervals = scaleIntervals[scaleType].Split(",").Select(Int32.Parse).ToArray();
            intervals[0] = rootFreq;
            for (int i = 1; i < intervals.Length; i++)
            {
                intervals[i] = GetOffsetFreq(rootFreq, octave, intervals[i]);
            }
            return intervals;
        }
    }
}
