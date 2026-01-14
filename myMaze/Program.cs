using System;
using System.IO;
//using stuff

public class Program
{
    public static char[,] maze;
    /// <summary>
    /// The main method assigns the parts of the maze to the maze array with LoadMaze(), prints the maze to the user using PrintMaze(), 
    /// and then checks if the maze has a start, then tries to solve the maze with SolveMaze()
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("Loading maze...\n");

        maze = LoadMaze();

        if (maze == null)
        {
            return; // if maze equals null, then wy is water wet?
        }

        Console.WriteLine("Maze loaded!\n");
        PrintMaze();

        Console.WriteLine("Looking for a solution...");

        if (!FindStart(maze, out int startRow, out int startCol))
        {
            Console.WriteLine("No start (S) found in the maze!");
            return;
        }

        if (SolveMaze(maze, startRow, startCol))
        {
            Console.WriteLine("\nMaze solved!\n");
            PrintMaze();
        }
        else
        {
            Console.WriteLine("\nNo path to the exit was found.");
        }
    }

    /// <summary>
    /// the LoadMaze method simply calls in the maze from the maze.txt file and assigns it to the char array
    /// </summary>
    public static char[,] LoadMaze(string filePath = "maze.txt")
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: maze.txt not found.");
            return null;
        }

        string[] lines = File.ReadAllLines(filePath);
        int rows = lines.Length;
        int cols = lines[0].Length;

        char[,] grid = new char[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                grid[r, c] = lines[r][c];
            }
        }

        return grid;
    }

    /// <summary>
    /// the PrintMaze() method prints out the maze to the user
    /// </summary>
    public static void PrintMaze()
    {
        Console.WriteLine("----------------------------------------");

        for (int r = 0; r < maze.GetLength(0); r++)
        {
            for (int c = 0; c < maze.GetLength(1); c++)
            {
                Console.Write(maze[r, c]);
            }
            Console.WriteLine();
        }

        Console.WriteLine("----------------------------------------");
    }

    /// <summary>
    /// the FindStart() method checks if the maze has a start (S) position within it
    /// </summary>
    public static bool FindStart(char[,] maze, out int row, out int col)
    {
        for (int r = 0; r < maze.GetLength(0); r++)
        {
            for (int c = 0; c < maze.GetLength(1); c++)
            {
                if (maze[r, c] == 'S')
                {
                    row = r;
                    col = c;
                    return true;
                }
            }
        }

        row = -1;
        col = -1; // Easter Egg (3)
        return false;
    }

    /// <summary>
    /// the method uses recursion to solve the maze by following the following steps:
    /// 1: check if it's going out of bounds
    /// 2: check if it hits a wall
    /// 3: check if it's at the exit
    /// 4: start at the start position
    /// 5: move up and down and left and right
    /// 6: check if it's at a dead end
    /// </summary>
    public static bool SolveMaze(char[,] maze, int row, int col)
    {
        char marker = '*';
        // Stop if out of bounds
        if (row < 0 || row >= maze.GetLength(0) || col < 0 || col >= maze.GetLength(1))
            return false;

        // Stop if wall or already visited
        if (maze[row, col] == '#' || maze[row, col] == marker)
            return false;

        // Found the exit!
        if (maze[row, col] == 'E')
            return true;

        // Mark this spot as visited
        if (maze[row, col] != 'S')
            maze[row, col] = marker;

        // Try moving: up, right, down, left
        if (SolveMaze(maze, row - 1, col) ||
            SolveMaze(maze, row, col + 1) ||
            SolveMaze(maze, row + 1, col) ||
            SolveMaze(maze, row, col - 1))
        {
            return true;
        }

        // Dead end, unmark and backtrack
        if (maze[row, col] != 'S')
            maze[row, col] = ' ';

        return false;
    }
}