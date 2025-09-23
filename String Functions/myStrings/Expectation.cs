using System;
using System.Runtime.CompilerServices;
class Expectation
{
    static bool quit = false;
    public static double Sum = 0;
    public static double Avg = 0;
    public static int Count = 0;

    public static string prevNumbers = "";

    public static string reverseNumbers = "";
    public static void Main(String[] args)
    {
        while (quit != true)
        {
            Console.WriteLine("\n_____________________________________________");
            Console.WriteLine("Welcome to AverageAdder. ");

            // Prompt the user to enter their numbers
            string input = getUserInput().Trim().ToLower();

            // Split the input accoding to spaces.
            String[] arrInput = input.Split();

            // Check if the user wants to exit
            quit = checkExit(arrInput[0]);

            if (quit == true)
            {
                Quit(prevNumbers);
                break;
            }
            else //Else proceed with the program
            {
                // Add the values in the array (convert to string then add). If error occured, returns -1
                int add = Adder(arrInput);
                if (add < 0) // An error occured with addig values
                {
                    Console.WriteLine("\nInvalid input, please enter a valid number next time.\n");
                    quit = true;
                    break;
                }
                else
                {
                    Average(Sum, Count); // No need to check for errors because adder already does so.
                }
                // At this point the Sum and Average have been calculated

                // Display the sum and average to the user
                Console.WriteLine($"Your total is: {Sum} and your average is {Math.Round(Avg, 1)}");

            }

        }
    }


    // ------ UTILITIES ------

    // Asks the user for input
    public static string getUserInput()
    {
        Console.Write("\nEnter a spsace seperated list of numbers (or type 'exit' to quit): ");
        string input = Console.ReadLine();
        return input;
    }

    // Check if the user wants to exit | True = Exit, False = Continue
    public static bool checkExit(string str)
    {
        if (str == "exit")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Add the numbers in the String Array together
    public static int Adder(String[] arr)
    {
        foreach (var Item in arr)
        {
            double val = stringToDouble(Item); // Tries to turn the string into a number (Error Checks for bad input)

            if (val > 0) //Everything is good
            {
                Sum += val; // Add the value to running sum
                Count += 1; // Add 1 to the count 
                prevNumbers = prevNumbers + val + " "; // Add the number to the end of previous numbers string
                reverseNumbers = val + " " + reverseNumbers; // Add the number to the front of reverse numbers
            }
            else
            {
                return -1;
            }
        }
        return 0;
    }

    // Get's the average by receiving running sum and count.
    public static void Average(double sum, int count)
    {
        double avg = sum / count;
        Avg = avg; // Setting global average to newly calculated average
    }

    /* 
    Convert strings to double
    Error checks for erroneous input and numbers less than 0 
    */
    public static double stringToDouble(string str)
    {
        // Try parsing user input into a double. No negative numbers are allowed
        if (double.TryParse(str, out double val) && val >= 0)
        {
            return val;
        }
        else
        {
            // Erroneous input
            return -1;
        }
    }


    // Called when the user decieds to quit
    public static void Quit(string numbers)
    { //TODO: David you're allowed to use classes.
        /*
            Section 1 will count the numbers using the following algorithm:

        */
        //Split the string of all numbers
        String[] arr = numbers.Split();
        string strDone = ""; // Will contains numbers that have been counted
        string strCount = ""; // Will Contains the counts of numbers.

        foreach (var number in arr)
        {
            string principalString = "";
            int count = 0;

            if (!strDone.Contains(number))
            {
                strDone += $" {number}";
                principalString = number;
                foreach (var str in arr)
                {
                    if (str == principalString)
                    {
                        count += 1;
                    }
                }
                strCount += $" {count}";
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine($"numbers: {numbers}");
        Console.WriteLine($"Done: {strDone}");
        Console.WriteLine($"Count: {strCount}");


        /*

        */
        // Check if a number is in the list
        Console.WriteLine("\nEnter a number to check if it's in the list");
        string input = Console.ReadLine().Trim().ToLower();
        bool isInList = prevNumbers.Contains(input);
        if (isInList)
        {
            Console.WriteLine($"\nYes {input} is in the list\n");
        }
        else
        {
            Console.WriteLine($"\nNo, {input} is not in the list");
        }

        // Print the numbers in reverse
        Console.WriteLine("Numbers in reverse order:" + reverseNumbers.Trim());

        Console.WriteLine("\nGoodby User!\n");
    }
}