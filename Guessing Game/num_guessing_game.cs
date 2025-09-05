//import system namespace
using System;

//using namespace for organization (not neccesary)
namespace num_guessing_game
{
    //Creating program class
    class Program
    {

        //Creating the Main method and setting the input parameter to a string list.
        static void Main(string[] args)
        {
            //Variables
            bool guessedCorrect = false; //to check if the user has guessed correct
            int noOfGuesses = 0; //to keep track of the number of guesses made by the user
            int maxGuesses = 0; //to store the maximum allowed guesses for the user
            bool quit = false; //to check if the user has decided to quit the game

            //Setting Upper boundary 
            int upperBoundary = SetUpperBoundary(args); //Calling the SetUpperBoundary method to take CLI arguments and set the first as upper Bound 

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
                //If it's empty, 
                }else{
                    Console.WriteLine("Play SG, Win TP");
                    Environment.Exit(0);
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

        /*
        PrintBestScore is a method created to iterate through the scoreboard list and print the lowest (best) score to the user
        */
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

        /*
        Sets the Upper Boundary by getting user input at the CLI
        Rules:
        1. Upper Bound must be a multiple of 10
        2. Upper Bound must be greater than or equal to 10
        3. Upper Bound must be less than or equal to 1000000 (1 mil)
        4. If no input given, default is 100
        */
        public static int SetUpperBoundary(string[] args)
        {
            //Ensuring we have proper input
            if(args == null || args.Count == 0)
            {
                return 100;
            }else if(!int.TryParse(args[0], out int upperBound) || upperBound < 10 || upperBound >1000000 || upperBound%10 != 0 )
            {
                return 100;
            }else{
                return upperBound;
            }
        }
    }
    
}