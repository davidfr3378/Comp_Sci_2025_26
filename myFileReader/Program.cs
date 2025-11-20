// using System;

// /// <summary>
// /// Entry point of the program. Loads quotes and displays a random one.
// /// </summary>
// class Program
// {
//     static void Main()
//     {
//         // The text file MUST be in the same folder as Program.cs
//         string filePath = "quotes.txt";

//         // Load all quotes from file
//         string[] quotes = QuoteReader.ReadQuotes(filePath);

//         // Grab one random quote
//         string quoteOfTheDay = QuoteSelector.GetRandomQuote(quotes);

//         Console.WriteLine("\nQuote of the Day");
//         Console.WriteLine("----------------");
//         Console.WriteLine(quoteOfTheDay);
//     }
// }
using System;

class Program
{
    static void Main()
    {
        string filePath = "quotes.txt";

        // Read quotes from file
        string[] quotes = QuoteReader.ReadQuotes(filePath);

        // Select a random quote
        string quoteOfTheDay = QuoteSelector.GetRandomQuote(quotes);

        // Make the header pop
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n===============================");
        Console.WriteLine("        QUOTE OF THE DAY       ");
        Console.WriteLine("===============================");
        Console.ResetColor();

        // If the file was missing, show the error in red and dip
        if (quoteOfTheDay == "No quotes available.")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nError: No quotes found. Make sure quotes.txt is in the project folder!");
            Console.ResetColor();
            return;
        }

        // Pick a random color for the quote itself
        ConsoleColor[] colors = (ConsoleColor[]) ConsoleColor.GetValues(typeof(ConsoleColor));
        Random rng = new Random();
        ConsoleColor randomColor = colors[rng.Next(colors.Length)];

        // Print border + quote in a fun color
        Console.ForegroundColor = randomColor;
        Console.WriteLine("\n-----------------------------------");
        
        // Wrap the quote if it's super long (console-safe)
        PrintWrappedQuote(quoteOfTheDay, 35);

        Console.WriteLine("-----------------------------------");
        Console.ResetColor();
    }

    /// <summary>
    /// Prints text wrapped to a specific line width.
    /// Helps long quotes not explode the console UI.
    /// </summary>
    static void PrintWrappedQuote(string text, int width)
    {
        string[] words = text.Split(' ');
        string currentLine = "";

        foreach (string word in words)
        {
            if ((currentLine + word).Length > width)
            {
                Console.WriteLine(currentLine);
                currentLine = "";
            }
            currentLine += word + " ";
        }

        if (currentLine.Length > 0)
            Console.WriteLine(currentLine);
    }
}
