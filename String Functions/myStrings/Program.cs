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

/*
Ask:
1. Can we use any data types other than arrays and lists?
2. Is it necessary for the user to be able to exit the program at the beginning (remember quitChoice is at the end of each loop)
3. //This is seemingly the wrong approach 
*/
public static class Program
{
    static bool quit = false;
    public static double Sum = 0;
    public static double Avg = 0;
    public static double Count = 0;
    public static void Main(String[] args)
    {
        while(quit != true)
        {
            Console.WriteLine("\n_____________________________________________");
            Console.WriteLine("Welcome to Triangle. ");

            // Prompt the user to enter their numbers
            string input = getUserInput();
            IEnumerable<double> gen = Split(input, ' ');

            // Checks the generator returned for errors
            int errorPresent = errorCheck(gen); //Returns 0 if no errors persent, else -1

            // If no errors, proceed as usual. ELSE tell the user to stop putting erroneous input and prompt them to either continue the program or quit
            if(errorPresent == 0){
                //No errors
                Avg = AvgCalc(gen, Sum);
                Sum += SumCalc(gen);
                Console.WriteLine($"Your total is: {Sum} and your average is {Avg}");
            }else{
                //Erroneous input
                Console.WriteLine("\nInvalid input, please enter a valid number next time.\n");

            }
            // After calculation or if errors, ask if the user wants to quit
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
    // Adds all the numbers in the generator
    public static double SumCalc(IEnumerable<double> gen)
    {
        double sum = 0;
        foreach (var part in gen)
        {
            sum += part;
        }
        return sum;
    }

    // Averages all the numbers in the generator, but also includes the sum from the previous round(if first round, set to 0)
    public static double AvgCalc(IEnumerable<double> gen, double prevSum)
    {
        double sum = prevSum;
        foreach (var part in gen)
        {
            Count += 1;
            sum += part;
        }

        double avg = Math.Round(sum / Count, 1);

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

    // Turns strings to Doubles, and error handles along the way
    public static double stringToDouble(String str)
    {
        // Try parsing user input into a double. No negative numbers are allowed
        if (double.TryParse(str, out double integer) && integer >= 0)
        {
            return integer;
        }
        else
        {
            //Erroneous input
        }

        return -1;
    }

    // Asks the user for input
    public static string getUserInput()
    {
            Console.Write("\nEnter text to sum and avg (E.g. 50 30 40 60): ");
            string input = Console.ReadLine();
            return input;
    }

    /*
    Checks for errors by checking if -1 is returned (stringToDouble is set to return -1 if the string isn't parsable or is less than 0) 
    */
    public static int errorCheck(IEnumerable<double> gen)
    {
            foreach (var item in gen)
            {
                if(item < 0 ){
                    return -1; //Erroneous
                }
            }

            return 0; //clean 
    }

    //R,

    // Asks the user if they wish to quit
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
