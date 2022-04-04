using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class Mastermind
    {
        static ConsoleHelper CurrentConsole;
        /// <summary>
        /// The mastermind class runs the game mastermind, where the player tries to guess a hidden number with hints revealed by the computer.
        /// </summary>
        public Mastermind()
        {
            Rules = new InitialConditions();
            CurrentConsole = new ConsoleHelper();
        }
        /// <summary>
        /// The defenition of the rules of the game
        /// </summary>
        public InitialConditions Rules;
        
        /// <summary>
        /// the game of mastermind. The user plays the game.
        /// </summary>
        /// <returns>a bool indicating if the player won or not</returns>
        public void PlayGame()
        {
            bool isWon = false;
            List<Guess> guesses = new List<Guess>();
            for(int i = 0; (i < Rules.MaxGuesses) && !isWon; i++)
            {
                CurrentConsole.PrintGuessHeader(Rules);
                Console.WriteLine($"You have {Rules.MaxGuesses - i} left.");
                CurrentConsole.PrintPreviousGuesses(guesses);
                List<int> guess = CurrentConsole.GetPlayerGuess(Rules);
                int marginalCorrect = CheckMarginalCorrect(guess, Rules.Pattern);
                int absoluteCorrect = CheckAbsoluteCorrect(guess, Rules.Pattern);
                if (absoluteCorrect == Rules.PatternLength) {
                    isWon = true;
                }
                else
                {
                    guesses.Add(new Guess(guess, marginalCorrect, absoluteCorrect)); 
                }
            }
            Console.Clear();
            CurrentConsole.WinLoss(isWon, Rules.Pattern);
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("(press enter to close the program)");
            Console.ReadLine();
        }
        /// <summary>
        /// Method checks the users guess and the answer pattern and returns the amount of correct answers that were in the correct spot
        /// </summary>
        /// <param name="guess">the users guess</param>
        /// <param name="correct">the correct pattern</param>
        /// <returns>the amount of correct answers in the correct spot</returns>
        private int CheckAbsoluteCorrect(List<int> guess, List<int> correct)
        {
            int numberInRightSpot = 0;
            for (int i = 0; i < correct.Count; i++)
            {
                if(guess[i] == correct[i])
                {
                    numberInRightSpot++;
                }
            }
            return numberInRightSpot;
        }
        /// <summary>
        /// Method checks the users guess and the answer pattern and returns the amount of correct answers that were the incorrect spot
        /// </summary>
        /// <param name="guess">the users guess</param>
        /// <param name="correct">the correct pattern</param>
        /// <returns>the amount of correct answers in the incorrect spot</returns>
        private int CheckMarginalCorrect(List<int> guess, List<int> correct)
        {
            int numberInRightSpot = 0;
            for (int i = 0; i < correct.Count; i++)
            {
                if (correct.Contains(guess[i]) && (correct[i] != guess[i]))
                {
                    numberInRightSpot++;
                }
            }
            return numberInRightSpot;
        }
    }
}
