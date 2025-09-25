using System; // Import for functionality

class Expectation
{
    static bool quit = false; // Flag for main while loop
    public static double Sum = 0; // Global variable for running sum
    public static double Avg = 0; // Global variable for current average
    public static int Count = 0; //Global variable for the current count of numbers

    public static string prevNumbers = ""; // Global variable to store all numbers inputted

    public static string reverseNumbers = ""; // Global varaible to store the current numbers reversed 
    public static void Main(String[] args)
    {
        //
        while (quit != true) //Main while loop. Exiting this ends the program softly
        {
            Console.WriteLine("\n_____________________________________________");
            Console.WriteLine("Welcome to AverageAdder. ");

            // Prompt the user to enter their numbers
            string input = getUserInput().Trim().ToLower(); //Gets the user input and transforms it to remmove irregularities. 

            // Split the input accoding to spaces.
            String[] arrInput = input.Split(); 

            // Check if the user wants to exit
            quit = checkExit(arrInput[0]);

            if (quit == true) //If user wants to exit
            {
                Quit(prevNumbers); //Call the Quit function which contains the exit sequence (i.e. SHow number frequency, check if number is in list, etc.)
                break; // After exit sequence, leave
            }
            else 
            {
                // Add the values in the array (convert to string then add). If error occured, returns -1
                int add = Adder(arrInput);
                if (add < 0) // An error occured with adding values
                {
                    Console.WriteLine("\nInvalid input, please enter a valid number next time.\n");
                    //quit = true; //Will cause the exit sequence to be called in the next loop
                    continue; //GOes to next loop
                }
                else
                {
                    //Gets the average of all numbrs (uses the Count as denominator)
                    Average(Sum, Count); // No need to check for errors because adder already does so.
                }
                // At this point the Sum and Average have been calculated

                // Display the sum and average to the user
                Console.WriteLine($"Your total is: {Sum} and your average is {Math.Round(Avg, 1)}");

            }

        }
    }


    // ------ UTILITIES ------

    // Asks the user for input
    public static string getUserInput()
    {
        Console.Write("\nEnter a spsace seperated list of numbers (or type 'exit' to quit): ");
        string input = Console.ReadLine();
        return input;
    }

    // Check if the user wants to exit | True = Exit, False = Continue
    public static bool checkExit(string str)
    {
        //"str" contins the users choice
        if (str == "exit")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Add the numbers in the String Array together
    public static int Adder(String[] arr)
    {
        foreach (var Item in arr) // For each number in the array,
        {
            double val = stringToDouble(Item); // Tries to turn the string into a number (Error Checks for bad input)

            if (val > 0) //Everything is good
            {
                Sum += val; // Add the value to running sum
                Count += 1; // Add 1 to the count 
                prevNumbers = prevNumbers + val + " "; // Add the number to the end of previous numbers string
                reverseNumbers = val + " " + reverseNumbers; // Add the number to the front of reverse numbers
            }
            else //Erroneous input
            {
                return -1; 
            }
        }
        return 0; // No errors
    }

    // Get's the average by receiving running sum and count.
    public static void Average(double sum, int count)
    {
        double avg = sum / count;
        Avg = avg; // Setting global average to newly calculated average
    }

    /* 
    Convert strings to double
    Error checks for erroneous input and numbers less than 0 
    */
    public static double stringToDouble(string str)
    {
        // Try parsing user input into a double. No negative numbers are allowed
        if (double.TryParse(str, out double val) && val >= 0)
        {
            return val; //No errors, so return value as a double
        }
        else
        {
            // Erroneous input
            return -1;
        }
    }

    /*
    Splits text on a single character delimiter. 

    Returns an Iteratable object that outputs the tokens on demand
    */
    public static IEnumerable<string> Split(string text, char delimiter) //Takes a string (text) and a char (delimeter)
    {
        if (text == null)
            Console.WriteLine("Please input some values!");

        int start = 0;  //start index (functions as a pointer for my purposes)

        for (int i = 0; i < text.Length; i++) //While the "pointer" is within the string
        {

            if (text[i] == delimiter) //If we are currently pointing to the delimeter,
            {
                //Slice from start to i (exclusive)
                string str = text.Substring(start, i - start);
                yield return str; //yield the slice
                start = i + 1; // move past the delimiter
            }
        }

        // yield the last segment (after the last delimiter)
        if (start <= text.Length)
        {
            string str = text.Substring(start);  //Slice from start to end of string
            yield return str; //yield the last slice
        }
    }

    //TODO: Comment
    // Called when the user decieds to quit
    public static void Quit(string numbers)
    { 
        /*
        SECTION 1: Count the frequency of each number
        */

        //Split the string of all numbers
        String[] arr = numbers.Split();
        string strDone = ""; // Will contains numbers that have been counted
        string strCount = ""; // Will Contains the counts of numbers.

        foreach (var number in arr) //For each number in the array,
        {
            string principalString = ""; //contains the string being counted
            int count = 0; //contains the current count 

            if (!strDone.Contains(number)) //If strDone does not contain the value, it means it has not been counted
            {
                strDone += $" {number}"; //Add the value to strDone
                principalString = number; //set principalString to the value
                foreach (var str in arr) 
                {
                    /*If the string in the array is equal to the principalString, they are the same, and thus we can increase the count of value */
                    if (str == principalString) 
                    {
                        count += 1;
                    }
                }
                strCount += $" {count}"; //When counting is finished, add the final count to strCount
            }
            else //If the number in strDone then it has already been counted
            {
                continue; //Go to the next number
            }
        }

        /*
        SECTION 2: Display the frequency
        */

        //"using" keyword used for resource management
        using (var strD = Split(strDone, ' ').GetEnumerator()) // Access the enumerator objects
        using (var strC = Split(strCount, ' ').GetEnumerator()) // Access the enumerator objects
        {
            while (strD.MoveNext() && strC.MoveNext()) // WHile there is a string present
            {
                if (strC.Current != "") // If the string is not empty
                {
                    Console.WriteLine($"[{strD.Current}] → Count: [{strC.Current}]"); // Print "[String] → Count: [frequency]"
                }
            }
        }

        /*
        SECTION 3: Other quit requirements
        */
        // Check if a number is in the list
        Console.WriteLine("\nEnter a number to check if it's in the list"); 
        string input = "";
        input += Console.ReadLine().Trim().ToLower(); //Get the user input


        using (var prevN = Split(prevNumbers, ' ').GetEnumerator()) // Access the enumerator objects
        {
            bool numFound = false;
            while (prevN.MoveNext()) // While there is a string present
            {
                if (prevN.Current != "" && prevN.Current == input) // If the string is not empty and the string is equal to the input
                {
                    Console.WriteLine($"YES, [{prevN.Current}] is in the list"); 
                    numFound = true;
                    break;// Print "[String] is in the list"
                }
                
            }
            if(numFound ==false) //if you have run through and not found the number
                Console.WriteLine($"NO, [{prevN.Current}] is not in the list"); 
            
        }
            
        

        // Print the numbers in reverse
        Console.WriteLine("\nNumbers in reverse order:" + reverseNumbers.Trim()); //Print the list in reverse order

        Console.WriteLine("\nGoodbye User!\n"); 
    }
}
