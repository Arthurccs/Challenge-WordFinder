using System;
using System.Linq;
using Services.Core;
using Services.Helpers;
using WordFinder.Properties;

namespace WordFinder
{
    class WordSearch
    {
        /// <summary>
        /// Main Program
        /// </summary>
        /// <param name="args"> you need to add 2 arguments, 1 set of strings which represents a character matrix and 2 the word stream list </param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    var matrix = args[0].Split(',');
                    var wordStream = args[1].Split(',');

                    var wordFinder = new Services.Core.WordFinder(matrix);
                    var foundwords = wordFinder.Find(wordStream);
                    var enumerable = foundwords as string[] ?? foundwords.ToArray();
                    Console.WriteLine(enumerable.Any() ? $"Top {IWordFinderHelper.MaxResult} founded words ordered by repeated times: " + string.Join(',', enumerable) : "No words founded");
                }
                else
                {
                    Console.WriteLine(Resources.WordSearch_Main_No_input_data_);
                }
                Console.ReadLine();
            }
            catch (Exception e) // TODO check for possible exceptions and added here 
            {
                Console.WriteLine(e);
                Console.ReadLine();
                throw;
            }
        }
    }
}
