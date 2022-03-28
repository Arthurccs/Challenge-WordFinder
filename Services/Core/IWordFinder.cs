using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Core
{
    /// <summary>
    /// the WordFinder Interface contain one  method to Find a word in a stream of words.
    /// </summary>
    public interface IWordFinder
    {
        /// <summary>
        /// returns the top 10 of words found it in a word stream.
        /// </summary>
        /// <param name="wordStream"> the word Stream to search</param>
        /// <returns></returns>
        IEnumerable<string> Find(IEnumerable<string> wordStream);
    }
}
