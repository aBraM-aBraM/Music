using System;
using System.Threading;

namespace MusicThingy.src
{
    static class SoundPlayer
    {

        public static Thread backtrack = new Thread(() => LoopTrack(SoundManager.SimpleCMaj));

        /// <summary>Current scale</summary>
        public static Scale currentScale;
        /// <summary>Current octave, natural number </summary> 
        public static int currentOctave = SoundManager.defaultOctave;
        /// <summary>Beats per minute</summary>
        public static int bpm = 90;
        /// <summary>Current State of the player, default = true</summary>
        public static bool IsPlaying = true;
        /// <summary>
        /// The intervals in milliseconds between every occurence of sound 
        /// </summary>
        static int difference
        {
            get
            {
                return (int)(1000 * 60 / (float)bpm);
            }
        }
        static Random rnd = new Random();


        /// <summary>
        /// Improvising on the current scale and octave
        /// </summary>
        public static void Play()
        {
            DateTime future = DateTime.Now.AddMilliseconds(difference);

            while (IsPlaying)
            {
                if (DateTime.Now >= future)
                {
                    future = DateTime.Now.AddMilliseconds(difference);

                    // calculate improv note
                    string currentNote = currentScale.notes[rnd.Next(0, currentScale.notes.Length)];
                    int currentNoteFreq = SoundManager.GetNoteFreq(currentNote, currentOctave);

                    // UI Display of note
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine("  ");
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine(currentNote);

                    // play a sound
                    Console.Beep(currentNoteFreq, 100);
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

        public static void LoopTrack(string[] chords, int barLen = 4)
        {

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
    }
}
