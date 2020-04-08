using System;
using System.Threading;
using System.Collections.Generic;

namespace MusicThingy
{
    class Program
    {
        static void Main(string[] args)
        {
            Scale scale = new Scale("c", Scale.Type.PENTATONIC_MAJOR);
            SoundManager.Improvise(scale, 95);
            
            //Console.Beep(SoundManager.GetNoteFreq(aMinor.notes[0]), 10000);
        }

    }
}
