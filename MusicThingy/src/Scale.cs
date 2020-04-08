using System;
using System.Collections.Generic;

namespace MusicThingy
{
    class Scale
    {
        public enum Type { MAJOR, MINOR, PENTATONIC_MINOR, PENTATONIC_MAJOR }
        int rootMinimum;
        readonly int formula;

        List<string> _notes = new List<string>();
        public string[] notes
        {
            get
            {
                return _notes.ToArray();
            }
        }

        /// <summary>
        /// Scale Constructor
        /// </summary>
        /// <param name="root">Designated root note of the scale</param>
        /// <param name="formula">The scale's formula string of levels on the chromatic scale ; 1 = root (0-10) | MAJOR | 0,2,4,5,7,9,11 </param>
        public Scale(string root, string formula)
        {
            Initialize(root, formula);
        }

        /// <summary>
        /// Simple Constructor
        /// </summary>
        /// <param name="root">Designated root note of the scale</param>
        /// <param name="scaleType">Type of the scale from known types</param>
        public Scale(string root, Type scaleType = Type.MAJOR)
        {
            switch (scaleType)
            {
                case Type.MAJOR:
                    Initialize(root, "0,2,4,5,7,9,11");
                    return;
                case Type.MINOR:
                    Initialize(root, "0,2,3,5,7,8,10");
                    return;
                case Type.PENTATONIC_MINOR:
                    Initialize(root, "0,3,5,7,10");
                    return;
                case Type.PENTATONIC_MAJOR:
                    Initialize(root, "0,4,5,7,11");
                    return;
            }
        }

        /// <summary>
        /// Initializes the scale's notes and values
        /// </summary>
        /// <param name="root">Designated root note of the scale</param>
        /// <param name="formula">The scale's formula string of levels on the chromatic scale ; 1 = root (0-10) | MAJOR | 0,2,4,5,7,9,11 </param>
        private void Initialize(string root, string formula)
        {
            rootMinimum = SoundManager.GetNoteFreq(root);
            _notes.Add(root);

            string[] intervals = formula.Split(',');
            foreach (string interval in intervals)
            {
                int currInterval = 0;
                try
                {
                    currInterval = int.Parse(interval);
                }
                catch
                {
                    throw new Exception("Syntax Error: intervals are numbers");
                }
                if (!_notes.Contains(SoundManager.GetNoteName(root, int.Parse(interval))))
                {
                    _notes.Add(SoundManager.GetNoteName(root, int.Parse(interval)));
                }
            }
        }
    }
}
