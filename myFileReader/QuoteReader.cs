using System;
using System.IO;

/// <summary>
/// Responsible for reading quotes from an external text file
/// and returning them as a string array.
/// </summary>
public class QuoteReader
{
    /// <summary>
    /// Reads all lines from the quotes file and returns them.
    /// Includes basic error handling for missing files.
    /// </summary>
    /// <param name="filePath">Path to the quotes file.</param>
    /// <returns>An array of quotes, or an empty array if file is missing.</returns>
    public static string[] ReadQuotes(string filePath)
    {
        try
        {
            // Read every line from the text file into a string array
            // Each line = one quote
            string[] lines = File.ReadAllLines(filePath);
            return lines;
        }
        catch (FileNotFoundException)
        {
            // Friendly error message for when the file isn't found
            Console.WriteLine($"Error: File '{filePath}' not found.");
            return new string[0]; // return empty array so the app doesn’t crash
        }
    }
}
