using System;
using System.Collections.Generic;

public static class Program
{

    public static void Main(String[] args)
    {

        Console.WriteLine("\n_____________________________________________");
        Console.WriteLine("Welcome to Triangle. ");

        // Prompt the user for which method (SAS or SSS/Heron) they want
        string choice = getUserChoice();
        IEnumerable<double> gen = Split(choice, ',');
        double sum = Sum(gen);
        double avg = Avg(gen);

        Console.WriteLine($"Your total is: {sum} and your average is {avg}");
    }

    // -------- Solving --------
    public static double Sum(IEnumerable<double> gen)
    {
        double  sum = 0;
        foreach (var part in gen)
        {
            sum += part;
        }
        return sum;
    }

    public static double Avg(IEnumerable<double> gen)
    {
        int count = 0;
        double sum = 0;

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

     public static string getUserChoice()
    {
            Console.Write("\nEnter text to sum and avg:");
            string input = Console.ReadLine();
            return input;
    }
}
