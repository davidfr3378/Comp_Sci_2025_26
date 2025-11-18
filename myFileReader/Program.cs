using System;
using System.IO;

public class Program
{
    public static void main(string[] args){
        string[] linesArr = readLines("file.txt");

    }

    public static string[] readLines(string fileName)
    {
        int[] numbers;
        string[] lines;
        int count = 0;

        try
        {
            lines = File.ReadAllLines("data.txt");

            foreach (var item in lines)
            {
                if(int.TryParse(item, out int x))
                { }
                else
                {count += 1;}
            }
            
            if (count > 0)
                return lines;
            else
                numbers = Array.ConvertAll(lines, int.Parse);
                return numbers;

        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
            return [];
        }
    }


}