using System;
/*
TODO:
Comment
*/

//Get the area



class Program
{
    static bool quit = false;

    static void Main(string[] args)
    {
        int choice;
        while(quit != true)
        {
            //resetting values
            choice = 0;

            Console.WriteLine("\n_____________________________________________");
            Console.WriteLine("Welcome to Triangle. ");
            choice = getUserChoice();
            
            
            switch(choice)
            {
                //TRIGONOMETRIC (SAS)
                case 1: 
                    Program.sasCaller();
                    break;

                //HERON (SSS)
                case 2: 
                    heronCaller();
                    break;

                default:
                    Console.WriteLine("Improper Input!");
                    break;
            }

            //Check if user wants to continue
            quit = quitChoice();
            if(quit == false){
                Console.WriteLine("\nCongrats you get to live");
            }else if(quit == true){
                Console.WriteLine("\nHave a nice death");
            }

        }
    }

    //Callers 
    public static void sasCaller(){
        Console.WriteLine("\nSince you chose (SAS), we'll need the values from you!");
        double side1 = doubleGetUserIpnut("Enter side 1:"); 
        double side2 = doubleGetUserIpnut("Enter side 2:");
        double angle = doubleGetUserIpnut("Enter the angle:");
        double area = Math.Round(SAS(side1, side2, angle), 1);
        Console.WriteLine("\nYour area is: " + area);
    }

     public static void heronCaller(){
        Console.WriteLine("\nSince you chose (SSS), we'll need the values from you!");
        double side1 = doubleGetUserIpnut("Enter side 1:");
        double side2 = doubleGetUserIpnut("Enter side 2:");
        double side3 = doubleGetUserIpnut("Enter side 3:");
        double area = Math.Round(heron(side1, side2, side3), 1);
        Console.WriteLine("Your area is: " + area);
    }
    //Solving
    //SASTrigonometric method
    public static double SAS(double a, double b, double angleC)
    {
        //convert angle to radians
        double area = 0.5 * a * b * Math.Sin(DegreeToRadian(angleC));
        return area;
    }

    //Area using Heron's Formula
    public static double heron(double side1, double side2, double side3)
    {
        //Get the Semi Perimeter
        double semi_p = (side1 + side2 + side3)/2;

        //Resolve wht's inside thhe square root in Heron's formula
        double inner = (semi_p * (semi_p - side1) * (semi_p - side2) * (semi_p - side3));

        //square root the inner
        double area = Math.Sqrt(inner);

        return area;
    }

    
    //UTILITY
    public static int getUserChoice()
    {
        bool choiceMade = true;
        while (choiceMade)
        {
            Console.WriteLine("What type of trangle do you wish to get the area of? (Enter: 1/2)");
            Console.WriteLine("\t1. SAS (Side, Side, Angle)");
            Console.WriteLine("\t2. SSS (Side, Side, Side) but with Heron's formula");

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

    //
    public static double DegreeToRadian(double degrees)
    {
        return degrees * (Math.PI / 180);
    }

    //Get User Input as String and convert to double
    public static double doubleGetUserIpnut(String message){
        bool answered = false;
        String str = "";

        while(!answered){
            Console.WriteLine(message);
            str = Console.ReadLine();
            if (double.TryParse(str, out double choice))
                { 
                    return choice; 
                    answered = true;
                }
                
            else{}

        
        }
        return 0;
    }

    public static bool quitChoice(){
        Console.WriteLine("\nDo you want to continue solving? (y/n)");  string choice = Console.ReadLine().Trim().ToLower();

                if(choice == "y"){
                    return false;
                }else if(choice == "n"){
                    return true;
                }

                //If bad input is put, the program will assume the user does not want to continue
                return true;
    }

}
