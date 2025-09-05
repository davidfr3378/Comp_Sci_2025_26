//import Sysytem namespace
using System;
using System.Collections.Generic;


namespace num_guessing_game_v2{

    class Program
    {

        static void Main()
        {
            //Variables
            bool guessedCorrect = false;
            int noOfGuesses = 0;
            int maxGuesses = 0;
            bool quit = false;
            int upperBoundary = 100;

            //Intro
            Console.WriteLine("_________________________________________");
            Console.WriteLine("Welcome to the Number Guessing Game! \n");

            //Creating a list to store the scores of different matches
            List<int> scoreboard = new List<int>();

            //Random number generator creator
            Random rnd = new Random();
            //Game Loop
            while (!quit)
            {
                int correctNumber = rnd.Next(1, upperBoundary + 1); // returns a random integer between 1 and the upper bound.
                guessedCorrect = false;
                noOfGuesses = 0; 

                //Difficulty setting
                int difficulty = Difficulty(upperBoundary);
                maxGuesses = difficulty;


                while (!guessedCorrect && noOfGuesses < maxGuesses)
                {
                    Console.WriteLine($"Enter a number between 1 and {upperBoundary}: ");
                    string input = Console.ReadLine();

                    int number;
                    if (int.TryParse(input, out number) && number > 0 && number <= upperBoundary)
                    {
                        if (number == correctNumber)
                        {
                            noOfGuesses++;
                            Console.WriteLine("You got it correct \n"  +
                                              "You guessed " + noOfGuesses + " times");
                            guessedCorrect = true;

                        }
                        else if (number > correctNumber)
                        {
                            noOfGuesses++;
                            Console.WriteLine($"Your guess is higher than answer | {maxGuesses - noOfGuesses} left\n");
                        }
                        else
                        {
                            noOfGuesses++;
                            Console.WriteLine($"Your guess is lower than answer | {maxGuesses - noOfGuesses} left\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Please enter a positive number between 1 and {upperBoundary}.");
                    }
                }
                if (!guessedCorrect)
                {
                    Console.WriteLine("YOU FAILED");
                    Console.WriteLine($"\nThe correct number was {correctNumber}");
                }
                else
                {
                    //Add score to scoreboard
                    scoreboard.Add(noOfGuesses);
                }

                //Message at the end of each game
                PrintBestScore(scoreboard);
                Console.WriteLine("Do you want to play again? (0 = no, 1 = yes)");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int actual_choice))
                {
                    if (actual_choice == 0)
                    {
                        Console.WriteLine("Goodbye Guesser, may your estimations be ever accurate!");
                        Console.WriteLine("-----------------------------------------------------------");

                        quit = true;
                    }else if (actual_choice == 1)
                    {
                        Console.WriteLine("\n Loading new round...\n");
                    }else {
                        Environment.Exit(0); 
                    }
                }
            }
        }

        /*
        The Difficulty method's purpose is to (with the upper boundary):
            1. Create the max guesses for easy, medium, and hard mode.
            2. Query the user about their difficulty choice
            3. Choose and return the max guess for the game based on the users' choice.
        */
        public static int Difficulty(int upperBoundary)
        {
            //Calculating Guess limits
            //Hard: The log (in base 2) of the upper boundary
            double result = Math.Log(upperBoundary, 2);   // ≈ 6.643856
            int hard = (int)Math.Ceiling(result);

            //Medium: Hard * 2
            int medium = hard * 2;

            //Easy: Just 80% of Upper Boundary (Eg., if upper Boundary is 100, guesses will be 80)
            double easy_guesses = Math.Ceiling(0.8 * (upperBoundary));
            int easy = (int) easy_guesses;

            Console.WriteLine($"What level of difficulty do you want? \n\t1. Easy ({easy} guesses) \n\t2. Medium ({medium} guesses) \n\t3. Hard ({hard} guesses)");

            string str_difficulty = Console.ReadLine();

            if (int.TryParse(str_difficulty, out int int_difficulty))
            {
                switch (int_difficulty)
                {
                    case 1:
                        return easy;
                    case 2:
                        return medium;
                    case 3:
                        return hard;
                }
            }
            else
            {
                Console.WriteLine($"Failed to parse: {str_difficulty}. Level set to Hard");
            }

            return hard;
        }

        public static void PrintBestScore(List<int> scoreboard)
        {
            if (scoreboard.Count > 0)
            {
                int bestscore = scoreboard[0];
                foreach (int score in scoreboard)
                {
                    if (score < bestscore)
                    {
                        bestscore = score;
                    }
    
                }
                Console.WriteLine($"Best score is {bestscore}");
            }

        }
    }
    
}
