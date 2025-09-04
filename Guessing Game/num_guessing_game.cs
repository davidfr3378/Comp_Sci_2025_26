//import Sysytem namespace
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace num_guessing_game_v2{

    class Program
    {

        static void Main()
        {
            //Variables
            Boolean guessed_Correct = false;
            int no_of_guesses = 0;
            int max_guesses = 0;
            Boolean quit = false;
            int upper_boundary = 10;
            //Random number generation
            Random rnd = new Random();
            int Correct_Number = rnd.Next(1, upper_boundary); // returns random integers >= 10 and  < 20

            //Intro
            Console.WriteLine("_________________________________________");
            Console.WriteLine("Welcome to the Number Guessing Game! \n");

            //Creating a list to store the scores of different matches
            List<int> scoreboard = new List<int>();
            //Game Loop
            while (!quit)
            {
                //Difficulty setting
                int difficulty = Difficulty(upper_boundary);
                max_guesses = difficulty;


                while (!guessed_Correct && no_of_guesses < max_guesses)
                {
                    Console.WriteLine("No of guesses rn (at the beginini): " +no_of_guesses);
                    Console.WriteLine("Max:" +max_guesses);

                    Console.WriteLine($"Enter a number between 1 and {upper_boundary}: ");
                    string input = Console.ReadLine();

                    int number;
                    if (int.TryParse(input, out number) && number > 0 && number <= upper_boundary)
                    {
                        if (number == Correct_Number)
                        {
                            no_of_guesses++;
                            Console.WriteLine("You got it correct");
                            Console.WriteLine("You guessed " + no_of_guesses + " times");
                            guessed_Correct = true;

                        }
                        else if (number > Correct_Number)
                        {
                            no_of_guesses++;
                            Console.WriteLine($"Higher than answer | {max_guesses - no_of_guesses} left\n");
                        }
                        else
                        {
                            no_of_guesses++;
                            Console.WriteLine($"Lower than answer | {max_guesses - no_of_guesses} left\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input. Please enter a positive number between 1 and {upper_boundary}.");
                    }
                }
                if (!guessed_Correct)
                {
                    Console.WriteLine("YOU FAILED");
                    Console.WriteLine($"\nThe correct number was {Correct_Number}");
                    scoreboard.Add(max_guesses + 1);
                }
                else
                {
                    //Add score to scoreboard
                    scoreboard.Add(no_of_guesses);
                }

                //Message at the end of each game
                print_bestScore(scoreboard);
                Console.WriteLine("Do you want to play again? (0 = no, 1 = yes)");
                string choice = Console.ReadLine();

                if (int.TryParse(choice, out int actual_choice))
                {
                    if (actual_choice == 0)
                    {
                        Console.WriteLine("Goodbye Guesser, may your estimations be ever accurate!");
                        Console.WriteLine("-----------------------------------------------------------");

                        quit = true;
                    }
                    else
                    {
                        guessed_Correct = false;
                        no_of_guesses = 0; 
                    }
                }
            }
        }

        /*
        The Difficulty method's purpose is to (with the upper boundary):
            1. Create the max guesses for easy, medium, and hard mode.
            2. Query the user about their difficulty choice
            3. Choose the max guess for the game based on the users' choice.
            4. Return the max guess
        */
        public static int Difficulty(int upper_boundary)
        {
            //Calculating Guess limits
            //Hard: The log (in base 2) of the upper boundary
            double result = Math.Log(upper_boundary, 2);   // ≈ 6.643856
            int hard = (int)Math.Ceiling(result);

            //Medium: Hard * 2
            int medium = hard * 2;

            //Easy: Just 80% of Upper Boundary (Eg., if upper Boundary is 100, guesses will be 80)
            double easy_guesses = Math.Ceiling(0.8 * (upper_boundary));
            int easy = (int)easy_guesses;

            Console.WriteLine("What level of difficulty do you want? ");
            Console.WriteLine("1. Easy (Effectively infinite guesses)");
            Console.WriteLine($"2. Medium ({medium} guesses)");
            Console.WriteLine($"3. Hard ({hard} guesses)");
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

        public static void print_bestScore(List<int> scoreboard)
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
