using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numberGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] playerNames = new string[2];
            PlayerCreation(playerNames);

            // Readability
            string playerOne = playerNames[0];
            string playerTwo = playerNames[1];

            do
            {
                // Game State -- Default
                var pickingPlayer = playerOne;
                var guessingPlayer = playerTwo;

                Console.Clear();

                int playerOneNumber = GetNumber(pickingPlayer, guessingPlayer);

                // Game State -- Invert
                pickingPlayer = playerTwo;
                guessingPlayer = playerOne;

                int playerTwoNumber = GetNumber(pickingPlayer, guessingPlayer);

                // Game State -- Default
                pickingPlayer = playerOne;
                guessingPlayer = playerTwo;


                GuessNumbers(pickingPlayer, guessingPlayer, playerOneNumber);

                // Game State -- Invert
                pickingPlayer = playerTwo;
                guessingPlayer = playerOne;

                GuessNumbers(pickingPlayer, guessingPlayer, playerTwoNumber);

                Console.WriteLine("Thanks for playing! Hit any key to play again.", guessingPlayer);
                Console.ReadLine();
            } while (true);
        }
        
        /// <summary>
        /// Prompts players to enter thier names. 
        /// </summary>
        /// <param name="playerNames">An array that stores the (currently) two player names.</param>            
        private static void PlayerCreation(string[]  playerNames)
        {
            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine();
            for(int i=0;i<=1;i++)
            {
                Console.WriteLine("Player {0}, what is you name?", i+1);
                playerNames[i] = Console.ReadLine();
            }
        }

        /// <summary>
        /// Asks the two players to pick thier own numbers.
        /// </summary>
        /// <param name="pickingPlayer">The player who is selecting thier number for the other player to guess.</param>
        /// <param name="guessingPlayer">The player who *should* be looking away while the other player is picking thier number.</param>
        /// <returns>Picking player's number.</returns>
        private static int GetNumber(string pickingPlayer, string guessingPlayer)
        {
            Console.WriteLine("Ok. {0}, please look away.", guessingPlayer);
            int number;
            while (true)
            {
                Console.WriteLine("Now {0}, if you could pick a number.", pickingPlayer);

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("That is not a valid number.");
                    Console.WriteLine();
                }
            }
            return number;
        }

        /// <summary>
        /// The game operating. Each players have 10 chances to guess the number of the other, with hints decribing thier guess relative to the right number.
        /// </summary>
        /// <param name="pickingPlayer">The player who picked the number that is being guessed.</param>
        /// <param name="guessingPlayer">The player who is actively putting in inputs trying to guess the picked number.</param>
        /// <param name="playerNumber">The number trying to be guessed by the guessingPlayer.</param>
        private static void GuessNumbers(string pickingPlayer, string guessingPlayer, int playerNumber)
        {
            // Custom First Message
            Console.WriteLine("Ok {0}, try to guess {1}'s number. You have 10 guesses remaining.", guessingPlayer, pickingPlayer);
            for (int j = 10; j > 0; j--)
            {
                int guess;
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    if (guess < playerNumber)
                    {
                        Console.WriteLine("That number is too low! {0}'s number is higher than that. You have {1} guesses remaining.", pickingPlayer, j - 1);
                    }
                    else if (guess > playerNumber)
                    {
                        Console.WriteLine("That number is too high! {0}'s number is lower than that. You have {1} guesses remaining.", pickingPlayer, j - 1);
                    }
                    else if (guess == playerNumber)
                    {
                        Console.WriteLine("That's it! Great guess {0}! Hit any key to continue.", guessingPlayer);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry {0}, you're out of guesses. Better luck next time. Hit any key to continue.", guessingPlayer);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("That's not a valid guess. Try Again.");
                    Console.WriteLine();
                    j++;
                }
            }
        }
    }
}
