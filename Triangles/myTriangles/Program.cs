using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("_____________________________________________");
        Console.WriteLine("Welcome to Triangle. ");
        int u = getUserChoice();
        Console.WriteLine("U:" + u);

    }

    //Solving
    //SAS
    public double SAS(float side1, float side2, float angle)
    {
        return 0.0;
    }
    //SSS
    public double heron(float side1, float side2, float side3)
    {
        return 0.0;
    }
    //ASS
    public double AAS(float side, float angle1, float angle2)
    {
        return 0.0;
    }


    //Utility
    public static int getUserChoice()
    {
        bool choiceMade = true;
        while (choiceMade)
        {
            Console.WriteLine("What type of triangle do you want to get the area of? (Enter: 1/2/3/4)");
            Console.WriteLine("\t1. AAA (Angle, Angle, Angle)");
            Console.WriteLine("\t2. AAS (Angle, Angle, Side)");
            Console.WriteLine("\t2. ASS (Angle, Side, Side)");
            Console.WriteLine("\t3. SSS (Side, Side, Side)");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                choiceMade = false;
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. (Choices are 1/2/3/4)\n ");
            }
        }
        return 0;
    }
}