using System;
using System.Linq;
public class Program
{
    static bool exit = false;
    static int[] demonimations = {5,10,20,50,100};
    public static void Main(String[] args)
    {
        int[7, 5] arrSchools = new int[];

        //
        Console.WriteLine("______________________________________________");
        Console.WriteLine("Welcome to School Donation Tracker");
        Console.WriteLine("Sch 1 is Trades.");
        Console.WriteLine("Sch 2 is Rades.");
        Console.WriteLine("Sch 3 is Ades.");
        Console.WriteLine("Sch 4 is Des.");
        Console.WriteLine("Sch 5 is Es.");
        Console.WriteLine("Sch 5 is S.");
        Console.WriteLine("Sch 6 is .");
        Console.WriteLine("Sch 7 is ");

        while (exit == false)
        {


            //Input loop and info updateh
            int[] donoAmounts = getDonoAmounts();


            if (donoAmounts[0] == -1) // IF user wants to exit
            {
                exit();
                exit = true;
                continue;
            }
            else
            {
                updateData(donoAmounts[0], donoAmounts[1]); //update the array
                //everything thet school chsoen has donated
                //the total amount of that denomination
            }
            

            //
        }
    }



    // ------- UTILITIES -------
    //Update the array
    public static void updateData(int school, int amount)
    {
        arrSchools[school, demonimations.IndexOf(amount)] = amount;
    }

    //Get the donation amounts from the user
    public static int[] getDonoAmounts()
    {
        int schIndex = -1; int donoAmount = -1;

        Console.WriteLine("Enter school index (0-6) or -1 to exit: ");
        int userInput = (int)doubleGetUserInput(Console.ReadLine());

        if (userInput > 0)
        {
            schIndex = userInput;

            Console.WriteLine("Enter donation amount ($5, $10, $20, $50, $100): ");
            userInput = (int)doubleGetUserInput(Console.ReadLine());

            if (userInput > 0 && [5,10,20,50,100].Contains(userInput))
            {
                donoAmount = userInput;
            }
            else
            {
                schIndex = -1; //schIndex is checked for erroneous input
            }
        }
        else
        {
            return [-1];
        }

        return [schIndex, donoAmount];
    }

    public static double doubleGetUserInput(String strNum)
    {
        bool answered = false;
        String str = "";

        while (!answered)
        {
            // Try parsing user input into a double
            if (double.TryParse(strNum, out double num) && num >= 0)
                return num;
            else
                return -1;
        }
        return 0;
    }

    public static void exit()
    {
        Console.WriteLine("Goodbye User");
    }
}
