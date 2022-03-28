using System.Collections.Generic;
using System.Linq;
using Models.Core;
using Services.Helpers;

namespace Services.Core
{
    public class WordFinder : IWordFinder
    {
        #region Fields

        private IEnumerable<string> _matrix;
        private IWordFinderHelper _finderHelper;
        private List<Word> _foundWords;
        private int _matrixSize;


        #endregion

        #region Constructors

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
            _finderHelper = new WordFinderHelper();
            _foundWords = new List<Word>();
            _matrixSize = _matrix.FirstOrDefault()!.Length;
        }

        #endregion

        #region interface Implementation
        
        /// <inheritdoc cref="Find"/>
        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            //clean stream
            wordStream = wordStream.Distinct();

            //check matrix rows 
            _matrix.ToList().ForEach(rowWord =>
            {
                _finderHelper.FindWord(rowWord, wordStream, ref _foundWords);
            });

            //check matrix columns
            for(int i = 0; i < _matrixSize; i++)
            {
                if (i < _matrixSize)
                {
                    string columnWord = _finderHelper.GetColumnWord(i,_matrix).ToLower();
                    _finderHelper.FindWord(columnWord, wordStream, ref _foundWords);
                }
            }

            var result = from f in _foundWords orderby f.Repeat descending select f.StringValue;
            return result.Take(IWordFinderHelper.MaxResult);
        }

        #endregion

        #region Public Methods

        

        #endregion
    }
}
