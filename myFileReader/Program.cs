using System;

/// <summary>
/// Entry point of the program. Loads quotes and displays a random one.
/// </summary>
class Program
{
    static void Main()
    {
        // The text file MUST be in the same folder as Program.cs
        string filePath = "quotes.txt";

        // Load all quotes from file
        string[] quotes = QuoteReader.ReadQuotes(filePath);

        // Grab one random quote
        string quoteOfTheDay = QuoteSelector.GetRandomQuote(quotes);

        Console.WriteLine("\nQuote of the Day");
        Console.WriteLine("----------------");
        Console.WriteLine(quoteOfTheDay);
    }
}
