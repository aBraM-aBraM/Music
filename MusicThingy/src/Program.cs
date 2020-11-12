using MusicThingy.src;
using System;
using System.Threading;

namespace MusicThingy
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = SoundManager.GetChordFreq("am7", 7);
            var b = SoundManager.AutumnLeaves;
            SoundPlayer.LoopTrack(b, 120, false);
            //Console.Beep(a,100);
            //Console.Beep(300, 100);

        }

    }
}
