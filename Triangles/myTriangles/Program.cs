using System;
using System.Collections.Generic;

//Get the area
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("_____________________________________________");
        Console.WriteLine("Welcome to Triangle. ");
        int choice = getUserChoice();
        
        
        switch(choice)
        {
            //TRIGONOMETRIC (SAS)
            case 1: 
                sasCaller();
                break;

            //HERON (SSS)
            case 2: 
                heronCaller();
                break;
        }

    }


    //Callers
    public void sasCaller(){
        Console.WriteLine("");
    }

     public void heronCaller(){
        Console.WriteLine("");
    }
    //Solving
    //SASTrigonometric method
    public double SAS(double a, double b, double angleC)
    {
        //convert angle to radians
        double area = 0.5 * a * b * Math.Sin(DegreeToRadian(angleC));
        return area;
    }

    //Area using Heron's Formula
    public double heron(double side1, double side2, double side3)
    {
        //Get the Semi Perimeter
        double semi_p = (side1 + side2 + side3)/2

        //Resolve wht's inside thhe square root in Heron's formula
        double inner = (semi_p * (semi_p - a) * (semi_p - b) * (semi_p - c))

        //square root the inner
        area = Math.sqrt(inner);

        return area;
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
            Console.WriteLine("What type of trangle do you wish to get the area of? (Enter: 1/2)");
            Console.WriteLine("\t3. SSA (Side, Side, Angle)");
            Console.WriteLine("\t4. SSS (Side, Side, Side) but with Heron's formula");

            if (int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 2)
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
