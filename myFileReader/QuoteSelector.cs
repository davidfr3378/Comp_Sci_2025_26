using System;

/// <summary>
/// Picks a random quote from a provided array.
/// </summary>
public class QuoteSelector
{
    // One Random instance shared across the whole program
    private static Random random = new Random();

    /// <summary>
    /// Returns a random quote from the provided array.
    /// Falls back to a default message if the array is empty.
    /// </summary>
    /// <param name="quotes">Array containing quotes.</param>
    /// <returns>A single randomly-selected quote.</returns>
    public static string GetRandomQuote(string[] quotes)
    {
        // If the file didn't load / had no lines
        if (quotes.Length == 0)
        {
            return "No quotes available.";
        }

        // Pick a random index inside the array
        int index = random.Next(quotes.Length);
        return quotes[index];
    }
}
