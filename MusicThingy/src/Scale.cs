using System;
using System.Collections.Generic;

namespace MusicThingy
{
    class Scale
    {
        public enum ScaleType { MAJOR, MINOR, PENTATONIC_MINOR, PENTATONIC_MAJOR }

        private Dictionary<ScaleType, string> formulaDict = new Dictionary<ScaleType, string>()
        {   { ScaleType.MAJOR , "0,2,4,5,7,9,11"},
            { ScaleType.MINOR, "0,2,3,5,7,8,10"},
            { ScaleType.PENTATONIC_MINOR, "0,3,5,7,10" },
            { ScaleType.PENTATONIC_MAJOR, "0,4,5,7,11" } 
        };
        private int rootMinimum;
        private readonly int formula;

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
        public Scale(string root, ScaleType scaleType = ScaleType.MAJOR)
        {
            Initialize(root, formulaDict[scaleType]);
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
