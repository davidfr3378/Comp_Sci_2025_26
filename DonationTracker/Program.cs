using System;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

public class Program
{
    public static void Main(String[] args)
    {
        //
        Console.WriteLine("______________________________________________");
        Console.WriteLine("Welcome to School Donation Tracker");
        
        //Input loop and info update
        int[] donoAmounts = getDonoAmounts();

    }



    // ------- UTILITIES -------
    public static void _() { }

    public static int[] getDonoAmounts()
    {
        Console.WriteLine("Enter school index (0-6) or -1 to exit: "); int schIndex = -1;
        if (((int) doubleGetUserInput(Console.ReadLine())) > 0)
            schIndex = (int) doubleGetUserInput(Console.ReadLine());

        Console.WriteLine("Enter donation amount ($5, $10, $20, $50, $100): ");
        int donoAmount = (int) doubleGetUserInput(Console.ReadLine());



        int[] a = {schIndex, donoAmount};
        return a;
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
}
