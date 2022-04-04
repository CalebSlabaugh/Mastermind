using System;
using System.Collections.Generic;


namespace Mastermind
{
    public class InitialConditions
    {
        /// <summary>
        /// the length of the pattern (ie, 4 would be a 4 integer length number 2341)
        /// </summary>
        public int PatternLength;
        /// <summary>
        /// the minimum each integer can be
        /// </summary>
        public int PatternMinimum;
        /// <summary>
        /// the maximum each number can be
        /// </summary>
        public int PatternMax;
        /// <summary>
        /// The max number of guesses the player has
        /// </summary>
        public int MaxGuesses;
        /// <summary>
        /// the randomly generated pattern that the player is trying to figure out
        /// </summary>
        public List<int> Pattern;
        /// <summary>
        /// A string that describes the difficulty of the game
        /// </summary>
        public string Difficulty;
        /// <summary>
        /// The initial difficulty of the game is Medium (pattern of 4 length, numbers 1 - 6, 10 guesses)
        /// </summary>
        public InitialConditions()
        {
            PatternLength = 4;
            PatternMax = 6;
            PatternMinimum = 1;
            MaxGuesses = 10;
            Difficulty = "Medium";
            this.shuffleAnswer();
        }
        /// <summary>
        /// Allows the construction of a custom game
        /// </summary>
        /// <param name="patternLength">The length of the pattern (IE 4 => 1234)</param>
        /// <param name="patternMinimum">The lower bound of each number</param>
        /// <param name="patternMax">The upper bound of each number</param>
        /// <param name="maxGuesses">The amount of guesses allowed in each game</param>
        /// <param name="difficulty">A string to define the difficulty of the game</param>
        public InitialConditions(int patternLength, int patternMinimum, int patternMax, int maxGuesses, string difficulty)
        {
            PatternLength = patternLength;
            PatternMax = patternMax;
            PatternMinimum = patternMinimum;
            MaxGuesses = maxGuesses;
            Difficulty = difficulty;
            this.shuffleAnswer();
        }
        /// <summary>
        /// changes the answer of the rules
        /// </summary>
        public void shuffleAnswer()
        {
            Random randomGenerator = new Random();
            List<int> answer = new List<int>();
            while (answer.Count != PatternLength)
            {
                int number = int.MinValue;
                while (!((number >= PatternMinimum) && (number <= PatternMax)))
                {
                    number = (int)(randomGenerator.NextDouble() * 10);
                }
                answer.Add(number);
            }
            this.Pattern = answer;
        }
    }
}
