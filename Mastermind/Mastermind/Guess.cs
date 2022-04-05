using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class Guess
    {
        /// <summary>
        /// Creates a guess put in by the user which tracks the quantity and quality of the sequence they guess
        /// </summary>
        /// <param name="guess">the sequence the user submitted</param>
        /// <param name="marginalCorrect">How many times the user used the correct integer, but in the incorrect spot</param>
        /// <param name="absoluteCorrect">How many times the user used the correct integer, and in the correct spot</param>
        public Guess(List<int> guess, int marginalCorrect = 0, int absoluteCorrect = 0)
        {
            Sequence = guess;
            MarginalCorrect = marginalCorrect;
            AbsoluteCorrect = absoluteCorrect;
        }
        /// <summary>
        /// The pattern the user inputed
        /// </summary>
        public List<int> Sequence;
        /// <summary>
        /// the amount of correct numbers in the incorrect position for the given guess
        /// </summary>
        public int MarginalCorrect;
        /// <summary>
        /// the amount of correct answers in the correct position for the given guess
        /// </summary>
        public int AbsoluteCorrect;
        /// <summary>
        /// arranges out the sequence with spaces 1234 => 1 2 3 4 
        /// </summary>
        /// <returns>a string of the sequence with spaces 1234 => 1 2 3 4</returns>
        public override string ToString()
        {
            string str = "";
            foreach (int i in Sequence)
            {
                str += $"{(i == int.MinValue ? 0 : i)} ";
            }
            return str;
        }
    }
}
