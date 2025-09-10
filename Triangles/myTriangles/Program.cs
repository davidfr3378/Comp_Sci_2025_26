using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("_____________________________________________");
        Console.WriteLine("Welcome to Triangle. ");
        int u = getUserChoice();
        selectAlgo(u)

    }

    //Solving
    //SAS
    public double SAS(double side1, double side2, double angle)
    {
        //convert angle to radians
        Math.pow(side1, 2) + Math.pow(side2, 2) + 2 * side1 * side2 * Math
        return 0.0;
    }
    //ASS
    public double AAS(double side, double angle1, double angle2)
    {

        return 0.0;
    }

    //AAA
    public double AAA(double side, double angle1, double angle2)
    {

        return 0.0;
    }

    //SSS
    public double SSS(double side1, double side2, double side3)
    {
        
        return 0.0;
    }

    public double heron(double side1, double side2, double side3)
    {
        
        return 0.0;
    }

    public void selectAlgo(int choice)
    { 
        switch()
        {
            //
        }
    }
    ///


    //Utility
    public static int getUserChoice()
    {
        bool choiceMade = true;
        while (choiceMade)
        {
            Console.WriteLine("What type of triangle do you want to get the area of? (Enter: 1/2/3/4/5)");
            Console.WriteLine("\t1. AAA (Angle, Angle, Angle)");
            Console.WriteLine("\t2. AAS (Angle, Angle, Side)");
            Console.WriteLine("\t3. ASS (Angle, Side, Side)");
            Console.WriteLine("\t4. SSS (Side, Side, Side)");
            Console.WriteLine("\t5. SSS (Side, Side, Side) but with Heron's formula");

            if (int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 5)
            {
                choiceMade = false;
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. (Choices are 1/2/3/4/5)\n ");
            }
        }
        return 0;
    }
}