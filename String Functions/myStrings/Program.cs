using System;
using System.Collections.Generic;

/*
TODO:
1. Make Avg and Sum global variables. Add to, and call them when needed
2. Create a main loop and abstract any "loose functions"
3. Add Error handling (zeroDivisions, Wrong inputs(including "Enters"), etc. )
4. Comment


Avg calc isn't working because I'm summing averages rarther than calculating the average of averages
*/
public static class Program
{
    static bool quit = false;
    public static double Sum = 0;
    public static double Avg = 0;
    public static void Main(String[] args)
    {
        while(quit != true)
        {
            Console.WriteLine("\n_____________________________________________");
            Console.WriteLine("Welcome to Triangle. ");

            // Prompt the user for which method (SAS or SSS/Heron) they want
            string choice = getUserChoice();
            IEnumerable<double> gen = Split(choice, ',');
            Sum += SumCalc(gen);
            Avg == AvgCalc(gen);

            Console.WriteLine($"Your total is: {Sum} and your average is {Avg}");

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

    // -------- Solving --------
    public static double SumCalc(IEnumerable<double> gen)
    {
        double sum = 0;
        foreach (var part in gen)
        {
            sum += part;
        }
        return sum;
    }

    public static double AvgCalc(IEnumerable<double> gen)
    {
        double sum = 0;
        int count = 0;
        foreach (var part in gen)
        {
            count += 1;
            sum += part;
        }

        double avg = Math.Round(sum / count, 1);

        return avg;
    }

    // -------- Utilities ---------
    // Splits `text` on a single character delimiter
    public static IEnumerable<double> Split(string text, char delimiter)
    {
        if (text == null)
            throw new ArgumentNullException(nameof(text));

        int start = 0;  // start index of the current segment

        for (int i = 0; i < text.Length; i++)
        {

            if (text[i] == delimiter)
            {
                // slice from start to i (exclusive)
                string str = text.Substring(start, i - start);
                yield return stringToDouble(str);
                start = i + 1; // move past the delimiter
            }
        }

        // yield the last segment (after the last delimiter)
        if (start <= text.Length)
        {
            string str = text.Substring(start);
            yield return stringToDouble(str);
        }
    }

    //
    public static double stringToDouble(String str)
    {
        // Try parsing user input into a double
        if (double.TryParse(str, out double integer))
        {
            return integer;
        }
        else
        {
            Console.WriteLine("\nInvalid input, please enter a valid number next time.\n");
        }

        return 0;
    }

    //
    public static string getUserChoice()
    {
            Console.Write("\nEnter text to sum and avg:");
            string input = Console.ReadLine();
            return input;
    }

    //
     public static bool quitChoice()
    {
        Console.WriteLine("\nDo you want to continue? (y/n)"); string choice = Console.ReadLine().Trim().ToLower();

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
