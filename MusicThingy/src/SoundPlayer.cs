using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace MusicThingy.src
{
    static class SoundPlayer
    {

        /// <summary>Current octave, natural number </summary> 
        public static int currentOctave = SoundManager.defaultOctave;
        /// <summary>Current State of the player, default = true</summary>
        public static bool IsPlaying = true;
        /// <summary>
        /// The intervals in milliseconds between every occurence of sound 
        /// </summary>
        static Random rnd = new Random();


        /// <summary>
        /// Improvising on the current scale and octave
        /// </summary>
        public static void Improv(int[] scaleNoteFreqs, int bpm)
        {
            int difference = Difference(bpm);
            DateTime future = DateTime.Now.AddMilliseconds(difference);

            while (IsPlaying)
            {
                if (DateTime.Now >= future)
                {
                    future = DateTime.Now.AddMilliseconds(difference);

                    // generate improv note
                    int currentNote = scaleNoteFreqs[rnd.Next(0, scaleNoteFreqs.Length)];

                    // UI Display of note
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine("  ");
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine(currentNote);

                    // play a sound
                    Console.Beep(currentNote, 100);
                }
            }
        }
        public static void PlayNotes(int[] notes)
        {
            foreach (int note in notes)
            {
                Console.Beep(note, 200);
            }
        }
        public static void LoopTrack(string[] chords, int bpm, int barLen = 4)
        {
            int difference = Difference(bpm);
            int index = 0;
            int counter = barLen;
            DateTime future = DateTime.Now.AddMilliseconds(difference);

            while (IsPlaying)
            {
                if (DateTime.Now >= future)
                {
                    future = DateTime.Now.AddMilliseconds(difference);

                    // UI Display of note
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine("         ");
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine(chords[index]);


                    if (counter == 0)
                    {
                        index++;
                        if (index == chords.Length) index = 0;
                        counter = barLen;
                    }
                    // calculate improv note
                    int currentNoteFreq = SoundManager.GetChordFreq(chords[index]);
                   
                    counter--;


                    // play a sound
                    Console.Beep(currentNoteFreq, 500);
                }
            }
        }

        // Utility Methods

        /// <summary>
        /// Returns the difference in seconds between every beat from bpm
        /// </summary>
        /// <returns></returns>
        private static int Difference(int bpm) => (int)(1000 * 60 / (float)bpm);
    }
}
