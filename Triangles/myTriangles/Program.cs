using System;

/*
Author: @David_Ezima
Purpose: Unit 1 Assingment #2 - Using Herons formula and trig to calculate the area of a triangle
Description: This program will allow the user to choose the type of triangle they want to get the area of (Side Side Side (SSS) or Side Angle Side (SAS)).
            Depending on the type of triangle chosen, either Heron (SSS) or Trig (SAS) will be chosen.
            When they method has been chosen, the program will ask the user for the informations required (like the sides or angles).
             
            at this point, IF the heron formula is used:
                The program uses the fact that in a triangle the sum of any two sides should be greater than the third to validate if the triangle is possible.

                IF the triangle is possible:
                    Program continues
                ELSE:
                    program warns the user against picking unsuitable values and loops

            ELSE IF the Trig method is used:
                The program continues (no method to validate that I know of)

           
            Now the program calculates and returns the answer to the user.
            After this it asks the user if they want to play again, if they say yes it restarts, if no, the program gracefully ends.
*/

class Program
{
    // Global quit flag for the main program loop
    static bool quit = false;

    static void Main(string[] args)
    {
        int choice;

        // Main program loop (keeps running until the user chooses to quit)
        while (quit != true)
        {
            // Reset choice at the start of each loop iteration
            choice = 0;

            Console.WriteLine("\n_____________________________________________");
            Console.WriteLine("Welcome to Triangle. ");

            // Prompt the user for which method (SAS or SSS/Heron) they want
            choice = getUserChoice();

            // Decide which calculation method to call based on user input
            switch (choice)
            {
                case 1:
                    // Case 1 = SAS (Trig formula)
                    Program.sasCaller();
                    break;

                case 2:
                    // Case 2 = SSS (Heron's formula)
                    heronCaller();
                    break;

                default:
                    // Input didn't match 1 or 2
                    Console.WriteLine("Improper Input!");
                    break;
            }

            // After calculation, ask if the user wants to quit
            quit = quitChoice();

            // Cosmetic: print newline if continuing, or goodbye message if quitting
            if (quit == false)
            {
                Console.WriteLine("\n");
            }
            else if (quit == true)
            {
                Console.WriteLine("\nGoodby User!");
            }
        }
    }

    // ----- CALLER METHODS -----

    /*
    Wrapper for the SAS (Trig) method.
    Handles user input (two sides and an angle), then calls SAS().
    */
    public static void sasCaller()
    {
        Console.WriteLine("\nSince you chose (SAS), we'll need the values from you!");

        // Collect values from user
        double side1 = doubleGetUserInput("Enter side 1:");
        double side2 = doubleGetUserInput("Enter side 2:");
        double angle = doubleGetUserInput("Enter the angle:");

        // Call SAS formula and round result
        double area = Math.Round(SAS(side1, side2, angle), 1);

        if (area <= 0)
        {
            Console.WriteLine("Please input resonable values");
        }
        else
        {
            Console.WriteLine("\nYour area is: " + area);
        }
    }

    /*
    Wrapper for the Heron method.
    Handles user input (three sides), then calls heron().
    */
    public static void heronCaller()
    {
        Console.WriteLine("\nSince you chose (SSS), we'll need the values from you!");

        // Collect side lengths
        double side1 = doubleGetUserInput("Enter side 1:");
        double side2 = doubleGetUserInput("Enter side 2:");
        double side3 = doubleGetUserInput("Enter side 3:");

        // Call Heron's formula and round result
        double area = Math.Round(heron(side1, side2, side3), 1);

        // If result is <= 0, triangle was invalid
        if (area <= 0)
        {
            Console.WriteLine("Please input resonable values");
        }
        else
        {
            Console.WriteLine("\nYour area is: " + area);
        }
    }

    // ----- SOLVING METHODS -----

    /*
    SAS Method (Trig formula).
    Formula: Area = 0.5 * a * b * sin(C)
    Angle must be in degrees, so it's converted to radians.
    */
    public static double SAS(double a, double b, double angleC)
    {
        if ((angleC >= 0 || angleC <= 180) && (a >= 0) && (b >= 0))//Checks if the angle is between 0 and 180 exclusive; Checks if a and b are greater than 0
        {
            double area = 0.5 * a * b * Math.Sin(DegreeToRadian(angleC));
            return area;
        }
        else
        {
            return 0;
        }
       
    }

    /*
    Heron's Formula.
    Formula: sqrt(s * (s-a) * (s-b) * (s-c)) where s = semi-perimeter.
    */
    public static double heron(double side1, double side2, double side3)
    {
        // First validate the triangle
        bool validTriangle = isValidTriangle(side1, side2, side3);

        if (!validTriangle)
        {
            return 0;
        }

        // Calculate semi-perimeter
        double semi_p = (side1 + side2 + side3) / 2;

        // Calculate inside of the square root
        double inner = (semi_p * (semi_p - side1) * (semi_p - side2) * (semi_p - side3));

        // Take square root to get area
        double area = Math.Sqrt(inner);

        return area;
    }

    // ----- UTILITY METHODS -----

    /*
    Prompts user to choose triangle type.
    Returns 1 (SAS) or 2 (SSS).
    Includes error handling for invalid inputs.
    */
    public static int getUserChoice()
    {
        bool choiceMade = true;

        while (choiceMade)
        {
            Console.WriteLine("What type of trangle do you wish to get the area of? (Enter: 1/2)");
            Console.WriteLine("\t1. SAS (Side, Side, Angle)");
            Console.WriteLine("\t2. SSS (Side, Side, Side) but with Heron's formula");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 2) //If the number can be parsed && it is 1 or 2
            {
                choiceMade = false;
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. (Choices are 1/2)\n ");
            }
        }
        return 0;
    }

    /*
    Converts degrees to radians for Math.Sin().
    */
    public static double DegreeToRadian(double degrees)
    {
        return degrees * (Math.PI / 180);
    }

    /*
    Generic user input method that prompts with a message and returns a double.
    Keeps looping until a valid number is entered.
    */
    public static double doubleGetUserInput(String message)
    {
        bool answered = false;
        String str = "";

        while (!answered)
        {
            Console.WriteLine(message);
            str = Console.ReadLine();

            // Try parsing user input into a double
            if (double.TryParse(str, out double choice))
            {
                answered = true;
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }
        return 0;
    }

    /*
    Checks if a triangle is valid.
    Condition: The sum of any two sides must be greater than the third.
    */
    public static bool isValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    /*
    Asks the user if they wish to quit.
    Accepts 'y' (continue) or 'n' (quit).
    Defaults to quitting on bad input.
    */
    public static bool quitChoice()
    {
        Console.WriteLine("\nDo you want to continue solving? (y/n)");

        string choice = Console.ReadLine().Trim().ToLower();

        if (choice == "y")
        {
            return false;
        }
        else if (choice == "n")
        {
            return true;
        }

        // On invalid input, assume quit
        return true;
    }
}
