using MusicThingy.src;
using System;
using System.Threading;

namespace MusicThingy
{
    class Program
    {
        static void Main(string[] args)
        {
            Scale scale = new Scale("a", Scale.ScaleType.MINOR);
            SoundPlayer.currentScale = scale;
            SoundPlayer.bpm = 100;

        }

    }
}
