using System;
using System.Collections.Generic;

namespace Mastermind
{
    class ConsoleHelper
    {
        public ConsoleHelper(InitialConditions rules)
        {
            Rules = rules;
        }
        static InitialConditions Rules;
        /// <summary>
        /// Parses through the players guess to see if it's a valid guess. The program only accepts guesses that are the smae length as the answer,
        /// integers, and between the min and max pattern values
        /// </summary>
        /// <returns>Returns a proper string selected by the user</returns>
        public string GetValidGuess()
        {
            string exampleInt = GetExampleIntFromRules();
            string selector;
            bool isValid;
            do
            {
                isValid = true;
                selector = Console.ReadLine();
                if (!(selector.Length == Rules.PatternLength))
                {
                    isValid = false;
                    Console.WriteLine($"That is not a valid guess because you do not have a valid number of integers {Environment.NewLine}" +
                        $"Please enter {Rules.PatternLength} numbers (without space, I.E. {exampleInt})");
                }
                foreach (char c in selector)
                {
                    if (!int.TryParse($"{c}", out int i)) {
                        isValid = false;
                        Console.WriteLine($"Please enter only numbers");
                        break;
                    }
                    int num = int.Parse($"{c}");
                    if(num > Rules.PatternMax || num < Rules.PatternMinimum)
                    {
                        isValid = false;
                        Console.WriteLine($"Please enter only numbers between {Rules.PatternMinimum} and {Rules.PatternMax}");
                        break;
                    }
                }
            } while (!isValid);
            return selector;
        }
        /// <summary>
        /// Converts a valid string guess into a list 
        /// </summary>
        /// <returns>a list of the guess</returns>
        public List<int> GetPlayerGuess()
        { 
            string guessString = GetValidGuess();
            List<int> guess = new List<int>();
            foreach (char c in guessString)
            {
                guess.Add(int.Parse($"{c}"));
            }
            return guess;
        }
        /// <summary>
        /// A helper method that prints a string a number of times in a row
        /// </summary>
        /// <param name="amountOfTimesToRepeat">how many times the string should be repeated</param>
        /// <param name="phrase">the character or phrase to be repeated</param>
        /// <param name="newLine">if there should be a carriage return after the method finishes</param>
        public void RepeatPrint(int amountOfTimesToRepeat, string phrase, bool newLine = true)
        {
            for (int i = 0; i < amountOfTimesToRepeat; i++)
            {
                Console.Write(phrase);
            }
            if (newLine)
            {
                Console.WriteLine();
            }
        }
        /// <summary>
        /// A helper method that prints the previous guesses and their quality
        /// </summary>
        public void PrintPreviousGuesses(List<Guess> guessList)
        {
            int i = 1;
            foreach(Guess guess in guessList)
            {
                Console.Write($"{i}.) {guess}");
                RepeatPrint(guess.AbsoluteCorrect, " +", false);
                RepeatPrint(guess.MarginalCorrect, " -");
                i++;
            }
            while (i <= Rules.MaxGuesses)
            {
                Console.WriteLine($"{i}.)");
                i++;
            }
        }
        /// <summary>
        /// Prints the header for the game from the given rules
        /// </summary>
        public void PrintGuessHeader()
        {
            string exampleInt = GetExampleIntFromRules();
            Console.Clear();
            RepeatPrint(Rules.PatternLength, "? ");
            Console.WriteLine($"Please enter {Rules.PatternLength} numbers between {Rules.PatternMinimum} and {Rules.PatternMax} {Environment.NewLine}" +
            $"I.E. {exampleInt}");
            Console.WriteLine();
        }
        /// <summary>
        /// Returns a string of an example input. IE, if the PatternLength is 4, will return 1234
        /// </summary>
        /// <returns>A string of an example answer from the given rules</returns>
        public string GetExampleIntFromRules()
        {
            string exampleInt = "";

            for (int i = 1; i <= Rules.PatternLength; i++)
            {
                int num = i;
                while (num > Rules.PatternMax)
                {
                    num -= Rules.PatternMax;
                }
                exampleInt += $"{num}";

            }
            return exampleInt;
        }
        /// <summary>
        /// Displays the win or loss screen
        /// </summary>
        /// <param name="win">if the player won or lost</param>
        /// <param name="correctAnswer">The correct answer</param>
        public void WinLoss(bool win)
        {
            if (win)
            {
                Console.WriteLine("Congratulations, You Have Won!");
                Console.WriteLine();
                Console.WriteLine(@".''.      .        *''*    :_\/_:     .
      :_\/_:   _\(/_  .:.*_\/_*   : /\ :  .'.:.'.
  .''.: /\ :    /)\   ':'* /\ *  : '..'.  -=:o:=-
 :_\/_:'.:::.  | ' *''*    * '.\'/.'_\(/_ '.':'.'
 : /\ : :::::  =  *_\/_*     -= o =- /)\     '  *
  '..'  ':::' === * /\ *     .'/.\'.  ' ._____
      *        |   *..*         :       |.   |' .---"" |
        *      | _.--'|  ||   | _|    |
        *      |  .- '|       __  |   |  |    ||      |
     .---- -.   |  | ' |  ||  |  | |   |  |    ||      |
 ___'       ' / ""\ |  '-."".    '-'   '-.'    '`      |____
   ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
   ~-~-~-~-~-~-~-~-~-~   /|
        )        ~-~-~-~-~-~-~-~  /|~       /_|\
      _-H-__    -~-~-~-~-~-~     /_|\    -~======-~
~-\XXXXXXXXXX/~     ~-~-~-~     /__|_\ ~-~-~-~
~-~-~-~-~-~    ~-~~-~-~-~-~    ========  ~-~-~-~
      ~-~~-~-~-~-~-~-~-~-~-~-~-~ ~-~~-~-~-~-~
                        ~-~~-~-~-~-~");
            }
            else
            {
                Console.WriteLine("You Lost");
                Console.Write($"The correct answer was {new Guess(Rules.Pattern)}");
                Console.WriteLine();
            }
        }
    }
}
