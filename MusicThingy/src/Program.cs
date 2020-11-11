using MusicThingy.src;
using System;
using System.Threading;

namespace MusicThingy
{
    class Program
    {
        static void Main(string[] args)
        {
            var scale = SoundManager.GetScaleNotesFreq("c", SoundManager.ScaleType.MAJOR);
            SoundPlayer.PlayNotes(scale);
        }

    }
}
