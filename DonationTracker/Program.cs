using System;
using System.Linq;

/*
Issue log:

*/

/*
    DONATION TRACKER: ...
*/
public class Program
{
    static bool exit = false;
    static int[] demonimations = {5,10,20,50,100};
    static int[,] arrSchools = new int[7,5];
    public static void Main(String[] args)
    {


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
                Exit();
                exit = true;
                continue;
            }
            else
            {
                updateData(donoAmounts[0], donoAmounts[1]); //update the array

                //everything thet school chosen has donated
                int schTotalDonation = returnSchoolTotalDonation(donoAmount[0]);
                Console.WriteLine($"School {donoAmount[0]} has donated a total of {schTotalDonation}");
                //the total amount of that denomination
                int totalDenominationDonation = returnTotalDonations(donoAmount[1]);
                Console.WriteLine($"The total number of ${donoAmount[1]} that has been donated is {totalDenominationDonation}");
            }

            //
        }
    }



    // ------- UTILITIES -------
    //Update the array
    public static void updateData(int school, int amount)
    {
        arrSchools[school, Array.IndexOf(demonimations, amount)] = amount;
    }

    //Get the donation amounts from the user
    public static int[] getDonoAmounts()
    {
        int schIndex = -1; int donoAmount = -1;

        Console.WriteLine("Enter school index (0-6) or -1 to exit: ");
        int userInput = (int)doubleGetUserInput(Console.ReadLine());

        if (userInput >= 0)
        {
            schIndex = userInput;

            Console.WriteLine("Enter donation amount ($5, $10, $20, $50, $100): ");
            userInput = (int)doubleGetUserInput(Console.ReadLine());

            if (userInput > 0 && demonimations.Contains(userInput)) //TODO: NEEDS TO BE REPLACED. WAIT WHY?
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
            // Try parsing user input into a double
            if (double.TryParse(strNum, out double num) && num >= 0) //no negative input is expected (negative input means exit)
                return num;
            else
                return -1;
    }

    public static void Exit()
    {
        //TODO: Print the whole array (formatted and whatnot)
        Console.WriteLine("Goodbye User");
    }
}
