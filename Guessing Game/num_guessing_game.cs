//import Sysytem namespace
using System;

namespace num_guessing_game_v2{

    class Program{
        
        static void Main()
        {
            //Variables
            Boolean guessed_Correct = false;
            int no_of_guesses = 0;
            
            //Random number generation
            Random rnd = new Random();
            int Correct_Number = rnd.Next(1, 10); // returns random integers >= 10 and  < 20
            
            //Intro
            Console.WriteLine(_________________________________________);
            Console.WriteLine("Welcome to the Number Guessing Game! \n");
            
            //Difficulty choosing
            difficulty = difficulty();
        
            while (!guessed_Correct)
            {
    
                Console.WriteLine("Enter a number between 1 and 10: ");
                string input = Console.ReadLine();
    
                int number;
                if (int.TryParse(input, out number) && number > 0 && number <= 100)
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
                        Console.WriteLine("Higher than answer");
                    }
                   else
                    {
                        no_of_guesses++;
                        Console.WriteLine("Lower than answer");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number between 1 and 10.");
                }
            }
        }
        
        public int difficulty(){
            Console.WriteLine("What level of difficulty do you want? ");
            Console.WriteLine("1. Easy (Effectively infinite guesses)");
            Console.WriteLine("2. Medium (14 guesses)");
            Console.WriteLine("3. Medium (7 guesses)");
            difficulty = Console.ReadLine();
            
            return difficultly;
        }
        
    }
    
}
