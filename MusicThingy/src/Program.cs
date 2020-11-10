using MusicThingy.src;

namespace MusicThingy
{
    class Program
    {
        static void Main(string[] args)
        {
            Scale scale = new Scale("e", Scale.ScaleType.PENTATONIC_MINOR);
            SoundPlayer.currentScale = scale;
            SoundPlayer.bpm = 180;
            //SoundPlayer.Play();
            SoundManager.GetChordFreq("a", SoundManager.ChordType.MinorSeven);
            //Console.Beep(SoundManager.GetNoteFreq(aMinor.notes[0]), 10000);
        }

    }
}
