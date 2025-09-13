using System;

/*
Author: @David_Ezima
Purpose: Unit 1 Assingment #2 - Using Herons formula and trig to calculate the area of a triangle
Description: This program will allow the user to choose the type of triangle they want to get the area of (Side Side Side (SSS) or Side Angle Side (SAS)).
             Depending on the type of triangle chosen, either Heron (SSS) or Trig (SAS) will be chosen.
             When they method has been chosen, the program will ask the user for the informations required (like the sides or angles), the it calculates and returns the answer to the user.
             After this it asks the user if they want to play again, if they say yes it restarts, if no, the program gracefully ends. 
*/

class Program
{
    static bool quit = false; //quit variable for the program loop

    static void Main(string[] args)
    {
        int choice;
        while (quit != true) //until the user wants to quit, loop
        {
            //resetting values
            choice = 0;

            Console.WriteLine("\n_____________________________________________");
            Console.WriteLine("Welcome to Triangle. ");
            choice = getUserChoice(); //method to prompt the user to choose a type of triangle


            switch (choice) //switch to call the method of the traingle th user chose
            {
                //TRIGONOMETRIC (SAS)
                case 1:
                    Program.sasCaller(); //SAS - Side Angle Side. This calls the Trigonometric method called SAS
                    break;

                //HERON (SSS)
                case 2:
                    heronCaller(); //THis calls the method that uses Herons formula
                    break;

                default:
                    Console.WriteLine("Improper Input!");
                    break; //This runs if the user provides something unexpected
            }

            //Check if user wants to continue and give them a message depending on their answer
            quit = quitChoice();
            if (quit == false)
            {
                Console.WriteLine("\n"); //If the user wants to continue, no need for a message.
            }
            else if (quit == true)
            {
                Console.WriteLine("\nGoodby User!");
            }

        }
    }

    //Callers - Methods used to call other functions

    /*
    This is a "Wrapper" around the SAS method (Trig) used to collect the values it needs for the calculations from the user. 
    After it has the values, it calls the method.
    */
    public static void sasCaller()
    {
        Console.WriteLine("\nSince you chose (SAS), we'll need the values from you!");
        double side1 = doubleGetUserInput("Enter side 1:");
        double side2 = doubleGetUserInput("Enter side 2:");
        double angle = doubleGetUserInput("Enter the angle:");
        double area = Math.Round(SAS(side1, side2, angle), 1);
        Console.WriteLine("\nYour area is: " + area);
    }


    /*
    This is a "Wrapper" around the Heron method used to collect the values it needs for the calculations from the user via the doubleGetUserInput method. 
    After it has the values, it calls the method.
    */
    public static void heronCaller()
    {
        Console.WriteLine("\nSince you chose (SSS), we'll need the values from you!");
        double side1 = doubleGetUserInput("Enter side 1:");
        double side2 = doubleGetUserInput("Enter side 2:");
        double side3 = doubleGetUserInput("Enter side 3:");
        double area = Math.Round(heron(side1, side2, side3), 1);
        Console.WriteLine("Your area is: " + area);
    }


    //Solving - Methods that do the actual computation


    //SAS - Trigonometric method
    public static double SAS(double a, double b, double angleC) //Takes in two sides and an angle (doubles)
    {
        //Uses the Area = 0.5 * a * b * Sin(C) function
        double area = 0.5 * a * b * Math.Sin(DegreeToRadian(angleC));
        return area;
    }

    //Area using Heron's Formula
    public static double heron(double side1, double side2, double side3)
    {
        //Get the Semi Perimeter
        double semi_p = (side1 + side2 + side3) / 2;

        //Resolve wht's inside thhe square root in Heron's formula
        double inner = (semi_p * (semi_p - side1) * (semi_p - side2) * (semi_p - side3));

        //square root the inner
        double area = Math.Sqrt(inner);

        return area;
    }


    //UTILITY - Methods made to abstract functionality and enable non-C# inherent actions


    /*Gets the user choice of Triangle. Erros handles unwanted input. */
    public static int getUserChoice()
    {
        bool choiceMade = true;
        while (choiceMade)
        {
            Console.WriteLine("What type of trangle do you wish to get the area of? (Enter: 1/2)");
            Console.WriteLine("\t1. SAS (Side, Side, Angle)");
            Console.WriteLine("\t2. SSS (Side, Side, Side) but with Heron's formula");

            if (int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 2)
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

    /*Converts degrees to radians*/
    public static double DegreeToRadian(double degrees)
    {
        return degrees * (Math.PI / 180);
    }


    /* Get User Input as String and convert to double*/
    public static double doubleGetUserInput(String message) //accepts a message of type string. 
    {
        bool answered = false; //used to check if the user has properly ansered the prompt.
        String str = ""; //Assignment of the input value because of C#'s quirkiness

        while (!answered) //While not answered, continue to prompt the user repeatedly
        {
            Console.WriteLine(message);
            str = Console.ReadLine();
            if (double.TryParse(str, out double choice))
            {
                answered = true;
                return choice;
                
            }

            else { }


        }
        return 0;
    }

    /*Asks the user if they wish to quit. Error handles unwanted input.*/
    public static bool quitChoice()
    {
        Console.WriteLine("\nDo you want to continue solving? (y/n)"); string choice = Console.ReadLine().Trim().ToLower();

        if (choice == "y")
        {
            return false;
        }
        else if (choice == "n")
        {
            return true;
        }

        //If bad input is put, the program will assume the user does not want to continue
        return true;
    }

}