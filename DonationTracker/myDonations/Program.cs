using System; 

public class Program 
{ 
    static bool exit = false; 
    static int[] demonimations = {5,10,20,50,100}; 
    static int[,] arrSchools = new int[7,5]; 
    public static void Main(String[] args) 
    { 
        //
        Console.WriteLine("_______________________________________________________"); 
        Console.WriteLine("Welcome to School Donation Tracker\n"); 
        Console.WriteLine("Skyrai Academy (1)"); 
        Console.WriteLine("Melee Sequans (2)"); 
        Console.WriteLine("Golden Wind Private School (3)"); 
        Console.WriteLine("Peregrinans Public School (4)"); 
        Console.WriteLine("Ad lecum Sequans (5)"); 
        Console.WriteLine("Onyx Orion Academy (6)");
        Console.WriteLine("Bishop Quatach-Ichl Ulquaan-Ibasan Secondary School (7)");


        while (exit == false)
        {
            //Input loop and info updateh 
            int[] donoAmounts = getDonoAmounts();

            if (donoAmounts[0] == -1) // IF user wants to exit 
            {
                Exit();
                exit = true;

            }
            else if (donoAmounts[1] == -1) //Erroneous input
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
                Console.WriteLine($"Total donations for ${donoAmounts[1]} denomination: {columnSum(arrSchools, Array.IndexOf(demonimations, donoAmounts[1]))}");
            }
            // 
        } 
    } 
 
 

    // ------- UTILITIES ------- 
    //Update the array 
    public static void updateData(int school, int amount) 
    { 
        arrSchools[school, Array.IndexOf(demonimations, amount)] += amount; 
    } 
 

    //Get the donation amounts from the user 
    public static int[] getDonoAmounts() 
    { 
        int schIndex = -1; int donoAmount = -1; 
        Console.WriteLine("\n--------------------------------------------------------"); 
        Console.WriteLine("Enter school index (1-7) or -1 to exit: "); 
        int userInput = (int)doubleGetUserInput(Console.ReadLine()); 
 

        if (userInput >= 0) 
        { 
            schIndex = userInput-1; // 
 
            Console.WriteLine("Enter donation amount ($5, $10, $20, $50, $100): "); 
            userInput = (int)doubleGetUserInput(Console.ReadLine()); 
 

            if (userInput > 0 && demonimations.Contains(userInput)) 
            { 
                donoAmount = userInput; 
            } 
            else 
            { 
                donoAmount = -1; //schIndex is checked for erroneous input //TODO: Repetition
            } 
        } 
        else
        { 
            return new[] {-1}; 
        } 


        return new[] {schIndex, donoAmount}; 
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


    // ------- ARRAY MANIPULATIONS ------- 
    // Print the array 
    
    public static void printArr(int[,] arr)
    {
        //Format
        // Schools $D1 $D2 $D3 ...
        // High A    x   x   x ...
        // High B    x   x   x ...
        // High C    x   x   x ...

        Console.Write("School  ");
        //Per denomination
        for(int i = 0; i < demonimations.Length; i++)
        {
            Console.Write($"${demonimations[i], -4}");
        }
        Console.WriteLine("");

        //Values
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.Write($"High {i + 1, -4}");
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j],-5}");
            }
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
        return new[] {index, max}; 
    }

    //Lowest Donation in a row and it's denomination
    public static int[] lowestDono(int[,] arr, int row)
    {
        int max = arr[row, 0]; // Setting the minimum value to the first
        int index = 0; 
        for (int i = 0; i < arr.GetLength(1); i++)
        {
            if (arr[row, i] > max)
            {
                index = i;
                max = arr[row, i];
            }
        }
        return new[] {index, max}; 
    }



    // -- OTHER -- 
    public static void Exit()
    {
        Console.WriteLine("");
        printArr(arrSchools);

        //TODO: BONUS: Display highest and lowest donations per school at the end.
        Console.WriteLine("\n_________________________________________________________");
    } 
} 
