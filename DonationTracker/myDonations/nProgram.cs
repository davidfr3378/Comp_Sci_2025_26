
using System;
using System.Linq;

/*
Author: @David
Purpose: Unit 2 Assingment #1 - User arrays and control flow to make a donation tracker for 7 schools.
Description: This program will... [step by step but concise]


*/

class nProgram
{
    public static int school_choice = 0;
    public static int[,] data = new int[8, 6];
    public static int[,] denominations = new int[8, 6];
    public static int[,] amounts = new int[8, 6];
    public static string[] schools = { "", "Bishop Jerry Secondary", "Mother Reagan Academy", "Dwayne Johnson High School", "Pope Gale Middle", "Tupac School of Rap", "St Chris Middle-High School", "Illuminati Institute of Subliminal Messaging" };

    static void m()
    {
        Console.WriteLine("\n-------------Data Collector-------------");

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("\nLoading...");
        Console.WriteLine("Now Online");
        data[0, 1] = 5;
        data[0, 2] = 10;
        data[0, 3] = 20;
        data[0, 4] = 50;
        data[0, 5] = 100;

        bool running = true;

        while (running == true)
        {
            Console.WriteLine("\nMake a choice: (or press -1 to exit)\n");
            Console.WriteLine("The 7 schools with their index numbers are as follows:\n");
            Console.WriteLine("Bishop Jerry Secondary (1)");
            Console.WriteLine("Mother Reagan Academy (2)");
            Console.WriteLine("Dwayne Johnson High School (3)");
            Console.WriteLine("Pope Gale Middle (4)");
            Console.WriteLine("Tupac School of Rap (5)");
            Console.WriteLine("St Chris Middle-High School (6)");
            Console.WriteLine("Illuminati Institute of Subliminal Messaging (7)");
            string strSchChoice = Console.ReadLine();
            int schChoice = 0;

            if (int.TryParse(strSchChoice, out schChoice) && (schChoice <= 7 && schChoice > 0))
            {
                school_choice = schChoice;
                switch (school_choice)
                {
                    case 1:
                        Console.WriteLine("\nBishop Jerry Secondary:");
                        DataCollect();
                        break;
                    case 2:
                        Console.WriteLine("\nMother Reagan Academy:");
                        DataCollect();
                        break;
                    case 3:
                        Console.WriteLine("\nDwayne Johnson High School:");
                        DataCollect();
                        break;
                    case 4:
                        Console.WriteLine("\nPope Gale Middle:");
                        DataCollect();
                        break;
                    case 5:
                        Console.WriteLine("\nTupac School of Rap:");
                        DataCollect();
                        break;
                    case 6:
                        Console.WriteLine("\nSt Chris Middle-High School:");
                        DataCollect();
                        break;
                    case 7:
                        Console.WriteLine("\nIlluminati Institute of Subliminal Messaging:");
                        DataCollect();
                        break;
                    default:
                        Console.WriteLine("\nIf you are seeing this, then something is horribly wrong!");
                        break;
                }
            }
            else if (int.TryParse(strSchChoice, out schChoice) && (schChoice == -1))
            {
                Console.WriteLine("\nExiting...");
                running = false;
            }
            else
            {
                Console.WriteLine("\nThat Number is invalid. Pick again.");
            }
        }
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Outputing final data...\n");
        Console.Write($"{string.Concat(Enumerable.Repeat(" ", 52))}");

        for (int i = 1; i < data.GetLength(1); i++)
        {
            Console.Write($"{"$" + data[0, i],7}:");
        }
        Console.WriteLine("");

        for (int i = 1; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                if (i == 0 && j == 0)
                {
                    Console.Write($"{data[i, j],-6}");
                }
                else if (j == 0)
                {
                    Console.Write($" {schools[i] + ":",-50}");
                }
                else
                {
                    Console.Write($"{"$" + data[i, j],8}");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("-------------------------------------------");
    }
    public static void DataCollect() //the method to collect data to store in the data array for later
    {
        Console.WriteLine("-------------------------------------------");
        int x = school_choice;
        int y = 0;
        int total = 0;

        bool grabbing_data = true;
        while (grabbing_data == true)
        {
            Console.WriteLine("Enter one of the 5 valid donation amounts (or press -1 to exit.)\n");
            Console.WriteLine("$5");
            Console.WriteLine("$10");
            Console.WriteLine("$20");
            Console.WriteLine("$50");
            Console.WriteLine("$100");
            string strDonation_choice = Console.ReadLine();
            int donation_choice = 0;
            if (int.TryParse(strDonation_choice, out donation_choice) && ((donation_choice == 5) || (donation_choice == 10) || (donation_choice == 20) || (donation_choice == 50) || (donation_choice == 100)))
            {

                Console.WriteLine("\nProcessing...");
                switch (donation_choice)
                {
                    case 5:
                        y = 1;
                        amounts[x, y] = amounts[x, y] + 5;
                        denominations[x, y] = denominations[x, y] + 1;
                        data[x, y] = amounts[x, y];
                        Console.WriteLine("\nNumber of $5 donations from this school: " + denominations[x, y]);
                        Console.WriteLine("Amount of $5 donations from this school: $" + amounts[x, y]);
                        break;
                    case 10:
                        y = 2;
                        amounts[x, y] = amounts[x, y] + 10;
                        denominations[x, y] = denominations[x, y] + 1;
                        data[x, y] = amounts[x, y];
                        Console.WriteLine("\nNumber of $10 donations from this school: " + denominations[x, y]);
                        Console.WriteLine("Amount of $10 donations from this school: $" + amounts[x, y]);
                        break;
                    case 20:
                        y = 3;
                        amounts[x, y] = amounts[x, y] + 20;
                        denominations[x, y] = denominations[x, y] + 1;
                        data[x, y] = amounts[x, y];
                        Console.WriteLine("\nNumber of $20 donations from this school: " + denominations[x, y]);
                        Console.WriteLine("Amount of $20 donations from this school: $" + amounts[x, y]);
                        break;
                    case 50:
                        y = 4;
                        amounts[x, y] = amounts[x, y] + 50;
                        denominations[x, y] = denominations[x, y] + 1;
                        data[x, y] = amounts[x, y];
                        Console.WriteLine("\nNumber of $50 donations from this school: " + denominations[x, y]);
                        Console.WriteLine("Amount of $50 donations from this school: $" + amounts[x, y]);
                        break;
                    case 100:
                        y = 5;
                        amounts[x, y] = amounts[x, y] + 100;
                        denominations[x, y] = denominations[x, y] + 1;
                        data[x, y] = amounts[x, y];
                        Console.WriteLine("\nNumber of $100 donations from this school: " + denominations[x, y]);
                        Console.WriteLine("Amount of $100 donations from this school: $" + amounts[x, y]);
                        break;
                    default:
                        Console.WriteLine("\nIf you are seeing this, then something is horribly wrong!");
                        break;
                }
                total = amounts[x, 1] + amounts[x, 2] + amounts[x, 3] + amounts[x, 4] + amounts[x, 5];
                Console.WriteLine("Total amount of donations from this school: $" + total);
                Console.WriteLine("The data has been documented.\n");

            }
            else if (int.TryParse(strDonation_choice, out donation_choice) && (donation_choice == -1))
            {
                Console.WriteLine("\nSaving all the school data...");
                grabbing_data = false;
                Console.WriteLine("Returning to school Select...");
                break;
            }
            else
            {
                Console.WriteLine("\nEnter one of the 5 valid options. or press -1 to exit");
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}