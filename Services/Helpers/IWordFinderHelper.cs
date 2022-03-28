using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Models.Core;

namespace Services.Helpers
{
    /// <summary>
    /// The WordFinderHelper interface, it would help with all the methods need it to make the search.
    /// </summary>
    public interface IWordFinderHelper
    {
        /// <summary>
        /// is going to search the word in a specific wordstream and affect the foundwords list
        /// </summary>
        /// <param name="word"> string to check in wordstream</param>
        /// <param name="wordstream"> strings to search</param>
        /// <param name="foundWords">the foundWords list </param>
        public void FindWord(string word, IEnumerable<string> wordstream, ref List<Word> foundWords);

        public const int MaxResult = 10;
    }
}
