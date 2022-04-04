using System;
using System.Collections.Generic;

namespace Mastermind
{
    class ConsoleHelper
    {
        /// <summary>
        /// Displays a screen that prompts the user for a number. TryParses until user returns a valid number.
        /// </summary>
        /// <returns>Returns an integer selected by the user</returns>
        public int IntegerSelector()
        {
            string selector;
            bool isValid;
            do
            {
                Console.Write($"Please type an integer: ");
                selector = Console.ReadLine();
                isValid = int.TryParse(selector, out int i);
                if (!isValid)
                {
                    Console.WriteLine("Please enter a valid integer");
                }
            } while (!isValid);
            int selected = int.Parse(selector);
            return selected;
        }
        /// <summary>
        /// Gets a valid guess from the user. If the user inputs something other than a valid integer, it penelizes the user by invalidating their guess.
        /// </summary>
        /// <param name="numberOfColumns">Length of the guess in characters</param>
        /// <returns>a list of the guess</returns>
        public List<int> GetPlayerGuess(InitialConditions Rules)
        {
            string exampleInt = GetExampleIntFromRules(Rules);
            string guessString;
            List<int> guess = new List<int>();
            bool validGuess;
            do
            {
                guessString = Console.ReadLine();
                validGuess = guessString.Length == Rules.PatternLength;
                if (!validGuess)
                {
                    Console.WriteLine($"That is not a valid guess because you do not have a valid number of integers {Environment.NewLine}" +
                        $"Please enter {Rules.PatternLength} numbers (without space, I.E. {exampleInt})");
                }
            } while (!validGuess);
            foreach (char c in guessString)
            {
                string s = $"{c}";
                if (!int.TryParse(s, out int i))
                {
                    guess.Add(int.MinValue);
                }
                else
                {
                    guess.Add(int.Parse(s));
                }
            }
            return guess;
        }
        /// <summary>
        /// A helper method that prints an character a few times in a row
        /// </summary>
        /// <param name="amountOfTimesToRepeat">how many times the character should be repeated</param>
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
                Console.Write($"{i}.) {guess.ToString()}");
                RepeatPrint(guess.AbsoluteCorrect, " +", false);
                RepeatPrint(guess.MarginalCorrect, " -");
                i++;
            }
        }
        /// <summary>
        /// Displays the win or loss screen
        /// </summary>
        /// <param name="win">if the player won or lost</param>
        /// <param name="correctAnswer">The correct answer</param>
        public void WinLoss(bool win, List<int> correctAnswer)
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
                Console.Write($"The correct answer was ");
                foreach(int i in correctAnswer)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Prints the header for the game from the given rules
        /// </summary>
        /// <param name="Rules">The rules of the particular game</param>
        public void PrintGuessHeader(InitialConditions Rules)
        {
            string exampleInt = GetExampleIntFromRules(Rules);
            Console.Clear();
            RepeatPrint(Rules.PatternLength, "? ");
            Console.WriteLine($"Please enter {Rules.PatternLength} numbers between {Rules.PatternMinimum} and {Rules.PatternMax} {Environment.NewLine}" +
            $"I.E. {exampleInt}");
            Console.WriteLine();
        }
        /// <summary>
        /// Takes in the rules of the game and returns a string of an example input. IE, if the PatternLength is 4, will return 1234
        /// </summary>
        /// <param name="Rules">The rules of the particular game</param>
        /// <returns>A string of an example answer from the given rules</returns>
        public string GetExampleIntFromRules(InitialConditions Rules)
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
    }
}
