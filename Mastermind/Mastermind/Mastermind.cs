using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class Mastermind
    {
        /// <summary>
        /// The mastermind class runs the game mastermind, where the player tries to guess a hidden number with hints revealed by the computer.
        /// </summary>
        public Mastermind()
        {
            Rules = new InitialConditions();
            CurrentConsole = new ConsoleHelper(Rules);
        }
        static ConsoleHelper CurrentConsole;
        /// <summary>
        /// The defenition of the rules of the game
        /// </summary>
        public InitialConditions Rules;
        /// <summary>
        /// Plays the game of mastermind. The console exits when the user is done
        /// </summary>
        public void PlayGame()
        {
            bool isWon = false;
            List<Guess> guesses = new List<Guess>();
            for(int i = 0; (i < Rules.MaxGuesses) && !isWon; i++)
            {
                CurrentConsole.PrintGuessHeader();
                Console.WriteLine($"You have {Rules.MaxGuesses - i} left.");
                CurrentConsole.PrintPreviousGuesses(guesses);
                Console.WriteLine();
                List<int> guess = CurrentConsole.GetPlayerGuess();
                int marginalCorrect = CheckMarginalCorrect(guess);
                int absoluteCorrect = CheckAbsoluteCorrect(guess);
                if (absoluteCorrect == Rules.PatternLength) {
                    isWon = true;
                }
                else
                {
                    guesses.Add(new Guess(guess, marginalCorrect, absoluteCorrect)); 
                }
            }
            Console.Clear();
            CurrentConsole.WinLoss(isWon);
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("(press enter to close the program)");
            Console.ReadLine();
        }
        /// <summary>
        /// Method checks the users guess and the answer pattern and returns the amount of correct answers that were in the correct spot
        /// </summary>
        /// <param name="guess">the users guess</param>
        /// <returns>the amount of correct answers in the correct spot</returns>
        private int CheckAbsoluteCorrect(List<int> guess)
        {
            List<int> correct = Rules.Pattern;
            int numberInRightSpot = 0;
            for (int i = 0; i < correct.Count; i++)
            {
                if((guess[i] == correct[i]))
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
        /// <returns>the amount of correct answers in the incorrect spot</returns>
        private int CheckMarginalCorrect(List<int> guess)
        {
            List<int> correct = Rules.Pattern;
            List<int> checkedNumbers = new List<int>();
            int numberInIncorrectSpot = 0;
            for (int i = 0; i < correct.Count; i++)
            {
                if ((guess[i] == correct[i]))
                {
                    checkedNumbers.Add(guess[i]);
                }
            }
            for (int i = 0; i < correct.Count; i++)
            {
                if (correct.Contains(guess[i]) && !(checkedNumbers.Contains(guess[i])))
                {
                    numberInIncorrectSpot++;
                    checkedNumbers.Add(guess[i]);
                }
            }
            return numberInIncorrectSpot;
        }
    }
}
