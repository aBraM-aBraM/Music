using MusicThingy.src;
using System;

namespace MusicThingy
{
    class Program
    {
        static void Main(string[] args)
        {
            Scale scale = new Scale("e", Scale.ScaleType.PENTATONIC_MINOR);
            SoundPlayer.currentScale = scale;
            SoundPlayer.bpm = 100;
            //SoundPlayer.Play();

            SoundPlayer.LoopTrack(SoundManager.Blues);


            //Console.Beep(SoundManager.GetNoteFreq(aMinor.notes[0]), 10000);
        }

    }
}
