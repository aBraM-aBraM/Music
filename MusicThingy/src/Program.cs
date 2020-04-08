using MusicThingy.src;

namespace MusicThingy
{
    class Program
    {
        static void Main(string[] args)
        {
            Scale scale = new Scale("c", Scale.Type.PENTATONIC_MAJOR);
            SoundPlayer.currentScale = scale;
            SoundPlayer.Play();
            
            //Console.Beep(SoundManager.GetNoteFreq(aMinor.notes[0]), 10000);
        }

    }
}
