using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Models;
using Models.Core;

namespace Services.Helpers
{
    public class WordFinderHelper : IWordFinderHelper
    {
        #region Fields
        


        #endregion

        #region Contructors

        public WordFinderHelper()
        {
            
        }

        #endregion

        #region Interface Implementation

        /// <inheritdoc />
        public void FindWord(string word, IEnumerable<string> wordstream, ref List<Word> foundWords)
        {
            var list = foundWords;
            wordstream.ToList().ForEach(valueStream =>
            {
                if (word.ToLower().Contains(valueStream.ToLower()))
                {
                    var countWord = Regex.Matches(word, valueStream).Count;
                    for (int countWordIndex = 0; countWordIndex < countWord; countWordIndex++)
                    {
                        var wordAdded = list.FirstOrDefault(x => x.StringValue.ToLower() == valueStream);
                        if (wordAdded != null)
                        {
                            wordAdded.Repeat += 1;
                        }
                        else
                        {
                            list.Add(new Word() { StringValue = valueStream, Repeat = 1 });
                        }
                    }
                }
            });
        }

        #endregion

    }
}
