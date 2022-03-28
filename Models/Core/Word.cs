using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Core
{
    /// <summary>
    /// The Word Model represents the word to return in solution
    /// </summary>
    public class Word
    {
        /// <summary>
        /// Get or Set the repeat value of a word, represents how many times a word is repeated.
        /// </summary>
        public int Repeat { get; set; }
        /// <summary>
        /// Get or Set the string  value of the word
        /// </summary>
        public string StringValue { get; set; }
    }
}
