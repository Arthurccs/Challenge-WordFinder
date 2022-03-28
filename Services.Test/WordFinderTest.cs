using System;
using System.Linq;
using FluentAssertions;
using Services.Core;
using Xunit;

namespace Services.Test
{
    public class WordFinderTest
    {
        private WordFinder _sutWordFinderTest;

        public WordFinderTest()
        {
            
        }

        [Fact]
        public void Test_Finder_WithCorrectSizeMatrix_returnFoundedWords()
        {
            //Arrange
            var matrix = "abcdc,fgwio,chill,pqnsd,uvdxy".Split(',');
            var wordStream = "chill,cold,wind".Split(','); 
            _sutWordFinderTest = new WordFinder(matrix);

            //Act
            var result = _sutWordFinderTest.Find(wordStream);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(3);
        }

        [Fact]
        public void Test_Finder_WithCorrectSizeMatrixAndRepeatedWordInStream_returnFoundedWords()
        {
            //Arrange
            var matrix = "abcdc,fgwio,chill,pqnsd,uvdxy".Split(',');
            var wordStream = "chill,cold,wind,chill,cold".Split(',');
            _sutWordFinderTest = new WordFinder(matrix);

            //Act
            var result = _sutWordFinderTest.Find(wordStream);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(3);
        }

        [Fact]
        public void Test_Finder_RepeatedWordInSameRow_returnFoundedWords()
        {
            //Arrange
            var matrix = "ababc,fgwio,chill,pqnsd,uvdxy".Split(',');
            var wordStream = "chill,cold,wind,ab".Split(',');
            _sutWordFinderTest = new WordFinder(matrix);

            //Act
            var result = _sutWordFinderTest.Find(wordStream);

            //Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(4);
        }

        [Fact]
        public void Test_Finder_IncorrectMatrixSize_returnError()
        {
            //Arrange
            var matrix = "abcdcghg,fgwio,chill,pqnsd,uvdxy".Split(',');
            var wordStream = "chill,cold,wind".Split(',');
            _sutWordFinderTest = new WordFinder(matrix);

            //Act
            var result = _sutWordFinderTest.Find(wordStream);

            //Assert
            result.Should().BeNull();
        }
    }
}
