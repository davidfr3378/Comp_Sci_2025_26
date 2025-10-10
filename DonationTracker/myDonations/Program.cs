using System; 

public class Program 
{ 
    static bool exit = false; 


    //School and Denominations
    static int[] denominations = { 5, 10, 20, 50, 100 }; 
    static string[] schools = {"Skyrai Academy", "Melee Sequans", "Golden Wind Private School", "Peregrinans Public School",
                                "Ad lecum Sequans", "Onyx Orion Academy", "Bishop Quatach-Ichl Ulquaan-Ibasan Secondary School"}; 
    
    static int[,] arrSchools = new int[7, 5]; 
    public static void Main(String[] args) 
    {
        //Listing the schools
        Console.WriteLine("_______________________________________________________"); 
        Console.WriteLine("Welcome to School Donation Tracker\n"); 
        for (int i = 0; i < schools.Length; i++)
        {
            Console.WriteLine($"{schools[i]} ({i + 1})");
        }

        while (exit == false)
        {
            //Input loop and info updates 
            int[] donoAmounts = getDonoAmounts();

            if (donoAmounts[0] == -1) // IF user wants to exit 
            {
                Exit();
                exit = true;

            }
            else if (donoAmounts[1] < 0) //Erroneous input
            {
                Console.WriteLine("\nInvalid Input");
            }
            else //Everything is fine
            {
                //update the array 
                updateData(donoAmounts[0], donoAmounts[1]);

                //TODO: ERRONEOUS 
                //everything thet school chsoen has donated 
                Console.WriteLine($"Total donations for High School {donoAmounts[0] + 1}: {rowSum(arrSchools, donoAmounts[0])}");
                //the total amount of that denomination 
                Console.WriteLine($"Total donations for ${donoAmounts[1]} denomination: {columnSum(arrSchools, Array.IndexOf(denominations, donoAmounts[1]))}");
            }
            // 
        } 
    } 
 
 

    // ------- UTILITIES ------- 
    //Update the array 
    public static void updateData(int school, int amount) 
    { 
        arrSchools[school, Array.IndexOf(denominations, amount)] += amount; 
    } 
 

    //Get the donation amounts from the user 
    public static int[] getDonoAmounts() 
    { 
        int schIndex = 0; int donoAmount = 0; 
        Console.WriteLine("\n--------------------------------------------------------"); 
        Console.WriteLine("Enter school index (1-7) or -1 to exit: "); 
        int userInput = (int)doubleGetUserInput(Console.ReadLine());


        if (userInput >= 1 && userInput <= schools.Length)
        {
            schIndex = userInput - 1; // 

            Console.WriteLine("Enter donation amount ($5, $10, $20, $50, $100): ");
            userInput = (int)doubleGetUserInput(Console.ReadLine());


            if (userInput > 0 && denominations.Contains(userInput))
            {
                donoAmount = userInput;
            }
            else
            {
                donoAmount = -1; //schIndex is checked for erroneous input //TODO: Repetition
            }
        }
        else if(!(userInput <= schools.Length))//If the school index provided is greater than the maximum index possible. 
        {
            return new[] { 0, -1 }; //donoAmount is set to -1, which triggers the "Invalid Input" prompt.
        }
        else
        {
            return new[] { -1, 0 }; //User wants to quit
        } 


        return new[] {schIndex, donoAmount}; 
    }


    public static double doubleGetUserInput(String strNum)
    {
        // Try parsing user input into a double 
        if (double.TryParse(strNum, out double num) && num >= 0)
            return num;
        else
            return -1;
    }


    // ------- ARRAY MANIPULATIONS ------- 
    // Print the array 

    public static void printArr(int[,] arr)
    {
        //Format
        // Schools $D1 $D2 $D3 ...
        // schName   x   x   x ...
        // schName   x   x   x ...
        // schName   x   x   x ...

        Console.Write($"School {string.Concat(Enumerable.Repeat(" ", 50))}"); //TODO: Make it modular
        //Per denomination
        for (int i = 0; i < denominations.Length; i++)
        {
            Console.Write($"${denominations[i],-4}");
        }
        Console.WriteLine("");

        //Values
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.Write($"{schools[i],-53} {i + 1,-4}");
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j],-5}");
            }

            //Printing highest and lowest donation per school
            int[] highestDonation = highestDono(arrSchools, i); //index, max
            int[] lowestDonation = lowestDono(arrSchools, i); //index, min

            string donoReport = $"Denomination w. largest donation: ${denominations[highestDonation[0]]}; Total Donations: ${highestDonation[1]}; Denomination  w. lowest donations: ${denominations[lowestDonation[0]]};";//If donation made
            string output = (highestDonation[1] > 0) ? donoReport : "No Donations Made";

            Console.Write(output);
            Console.WriteLine("");
        }
        
    } 

    //return: Sum a column in the array 
    public static int columnSum(int[,] arr, int col) 
    { 
        int sum = 0;
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            sum += arr[i, col];
        }
        
        return sum; 
    } 

    //return: Sum a row in the array 
    public static int rowSum(int[,] arr, int row) 
    { 
        int sum = 0;
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            sum += arr[row, j];
        } 
        
        return sum; 
    }

    //Highest Donation in a row and it's denomination
    public static int[] highestDono(int[,] arr, int row)
    {
        int max = 0;
        int index = 0;
        for (int i = 0; i < arr.GetLength(1); i++)
        {
            if (arr[row, i] > max)
            {
                index = i;
                max = arr[row, i];
            }
        }
        

        return new[] { index, max }; 
    }

    //Lowest Donation in a row and it's denomination
    public static int[] lowestDono(int[,] arr, int row)
    {
        int min = arr[row, 0]; // Setting the minimum value to the first
        int index = 0; 
        for (int i = 0; i < arr.GetLength(1); i++)
        {
            if (arr[row, i] > min)
            {
                index = i;
                min = arr[row, i];
            }
        }
        return new[] {index, min}; 
    }



    // -- OTHER -- 
    public static void Exit()
    {
        Console.WriteLine("");
        Console.WriteLine("\n Report: ");
        printArr(arrSchools);
        Console.WriteLine("\n_________________________________________________________");
    } 
} 
