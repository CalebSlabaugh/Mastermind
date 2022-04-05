using System;
using System.Collections.Generic;


namespace Mastermind
{
    public class InitialConditions
    {
        static Random RandomGenerator;
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
        /// Allows the construction of a custom game
        /// </summary>
        /// <param name="patternLength">The length of the pattern (IE 4 => 1234)</param>
        /// <param name="patternMinimum">The lower bound of each number</param>
        /// <param name="patternMax">The upper bound of each number</param>
        /// <param name="maxGuesses">The amount of guesses allowed in each game</param>
        public InitialConditions(int patternLength, int patternMinimum, int patternMax, int maxGuesses)
        {
            PatternLength = patternLength;
            PatternMax = patternMax;
            PatternMinimum = patternMinimum;
            MaxGuesses = maxGuesses;
            RandomGenerator = new Random();
            this.shuffleAnswer();
            
        }
        /// <summary>
        /// The initial difficulty of the game is: pattern of 4 length, numbers 1 - 6, 10 guesses
        /// </summary>
        public InitialConditions() : this(4, 1, 6, 10)
        {

        }
        /// <summary>
        /// changes the answer of the rules. Answer does not allow repeat characters.
        /// </summary>
        public void shuffleAnswer()
        {
            List<int> answer = new List<int>();
            while (answer.Count != PatternLength)
            {
                int number = int.MinValue;
                while (!((number >= PatternMinimum) && (number <= PatternMax) && !(answer.Contains(number))))
                {
                    number = (int)(RandomGenerator.NextDouble() * 10);
                }
                answer.Add(number);
            }
            this.Pattern = answer;
        }
    }
}
