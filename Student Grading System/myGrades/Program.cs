using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

/*
Author: @David_Ezima (some help from ChatGPT in comment some stuff and reformatting (arranging) my code to look neater as it was a mess before)
Purpose: Unit 2 Assingment #2 - Simple student grades program using lists.
Description: This program uses a 2d list to store grades for students added by the user. Each colum corresponds to a student.
             Users can add students, add grades to students, display the 2d grades list, modify student grades, and exit the program.

             I was very careful with loopholes in this program. 
             For instance, If the user inputs a student index above the max, what happens?
             If they input nothing for the student name, what happens? 
             I wanted to make sure I dealt with all these. 
              
             Doing so, I found out about: "string.IsNullOrWhiteSpace(input)" as a means to check if a stering is empty or null

*/

public class Program
{
    // Program state
    static bool running = true;                           // flip this to false to quit the main loop
    static List<string> students = new List<string>();    // list of students
    static List<List<double>> grades = new List<List<double>>();

    // Entry point
    public static void Main(String[] args)
    {
        // Main loop: prints a menu, reads a choice, and calls the switch to handle input
        // The menu repeats until EXIT() sets `running = false`.
        while (running == true)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("(1) Add a student");
            Console.WriteLine("(2) Add a grade to a student");
            Console.WriteLine("(3) Display all grades");
            Console.WriteLine("(4) Modify grade");
            Console.WriteLine("(5) Display the average for each student");
            Console.WriteLine("(6/7) EXIT");
            Console.WriteLine("-------------------------------------------");
            string input = Console.ReadLine();

            // Basic menu validation:
            // - First check for empty/whitespace input to avoid parsing exceptions.
            // - Then check the input string is one of the allowed menu items.
            if (!string.IsNullOrWhiteSpace(input) && new[] { "1", "2", "3", "4", "5", "6", "7" }.Contains(input)) //Good input
            {
                // parse the valid numeric string and dispatch to the appropriate case.
                switch (int.Parse(input))
                {
                    case 1:
                        addStudentCaller();
                        break;

                    case 2:
                        addGradeCaller();
                        break;

                    case 3:
                        DisplayAllStudents();
                        break;

                    case 4:
                        modifyGradeCaller();
                        break;

                    case 5:
                        averageGradeCaller();
                        break;

                    case 6:
                        EXIT();
                        break;

                    case 7:
                        EXIT();
                        break;
                }
            }
            else // Erroneous input (empty input or not one of the allowed menu numbers)
            {
                Console.WriteLine("Invalid menu choice. Try again.\n");
            }
        }
    }

    // ------- UTILITIES / Handlers -------

    // Prompts the user for a student name, validates the input, and adds the student.
    public static void addStudentCaller()
    {
        Console.Write("\nName of student: ");
        string name = Console.ReadLine().Trim();

        // Validate name: if it's empty or whitespace-only, tell the user it's invalid.
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid Input\n");
        }
        else
        {
            AddStudent(name);   // create student entry
            Console.WriteLine("Student Added Successfully");
        }
    }

    // Adds the student's name to the students list and creates an empty grade list for them.
    public static void AddStudent(string name)
    {
        students.Add(name);
        int stuIndex = students.IndexOf(name); // not used later, but kept as in original logic
        grades.Add(new List<double> { });      // keep grade list aligned with students list
    }

    // Prompts for which student, then accepts CSV grades and appends them to the student's grades.
    public static void addGradeCaller()
    {
        int studentIndex = getStudentIndex();

        if (studentIndex < 0)
        {
            // Caller already informed the user about the issue (getStudentIndex prints messages).
            // simply return and don't try to add grades.
        }
        else if (studentIndex >= 0)
        {
            // Ask for grades as CSV (example: 99,98,95,97)
            Console.WriteLine("\n Input grades as comma seperated values (99,98,95,97)");
            string strGrades = Console.ReadLine().Trim();

            // Parse the CSV into doubles. tempErr indicates a formatting or value issue.
            bool tempErr = false; // Used to indicate an error in this subsection of the code
            string[] arrGrades = strGrades.Split(',');
            List<double> listGrades = new List<double>();
            try
            {
                foreach (var grade in arrGrades)
                {
                    double val = double.Parse(grade);    // might throw FormatException
                    if (val < 0 || val > 100)            // quick validation for reasonable grade range
                    {
                        Console.WriteLine("Grades must be between 0 and 100");
                        tempErr = true;
                        break;
                    }
                    listGrades.Add(val);
                }
            }
            catch (System.FormatException)
            {
                // If any token isn't parseable to a double, we mark the temporary error and tell the user.
                tempErr = true;
                Console.WriteLine("Wrongly formatted Grades");
            }

            if (tempErr)
            {
                // Parsing or validation failed; user already informed.
            }
            else // IF no errors occurred,
            {
                AddGrades(studentIndex, listGrades);  // append parsed grades to the student's list
                Console.WriteLine("Grades added\n");
            }
        }
    }

    // Adds the given grades to the student's grade list (preserves existing grades).
    public static void AddGrades(int studentIndex, List<double> newGrades)
    {
        grades[studentIndex].AddRange(newGrades);
    }

    // Prints all students and their grades. If a student has no grades, the inner loop is skipped.
    public static void DisplayAllStudents()
    {
        for (int i = 0; i < students.Count; i++) // For each student in the list of students
        {
            Console.Write($"{students[i]}: ");
            for (int j = 0; j < grades[i].Count; j++)
            {
                // Writes each grade padded for nicer alignment.
                Console.Write($"{grades[i][j],-3} ");
            }
            Console.WriteLine("");
        }
    }

    // Prompts for student and grade indices, then asks for the new grade and updates it.
    public static void modifyGradeCaller()
    {
        int studentIndex = getStudentIndex(); // Get student index

        if (studentIndex < 0)
        {
            // getStudentIndex already printed an error or instruction.
        }
        else if (studentIndex >= 0) // If index is reasonable
        {
            int gradeIndex = getGradeIndex(studentIndex);  // Get grade index

            if (gradeIndex < 0)
            {
                // getGradeIndex already printed an error or instruction.
            }
            else if (gradeIndex >= 0)
            {
                Console.WriteLine("\n Input new grade: ");
                string strNewGrade = Console.ReadLine();

                // Validate the new grade is numeric and in [0,100]
                if (double.TryParse(strNewGrade, out double newGrade) && newGrade >= 0 && newGrade <= 100)
                {
                    ModifyGrade(studentIndex, gradeIndex, newGrade);
                    Console.WriteLine("Grades modified successfully");
                }
            }
        }
    }

    // Directly sets the value of a grade at the specified student and grade indices.
    public static void ModifyGrade(int studentIndex, int gradeIndex, double newGrade)
    {
        grades[studentIndex][gradeIndex] = newGrade;
    }

    // Wrapper that gets a student index and prints their average (rounded to 1 decimal).
    public static void averageGradeCaller()
    {
        int studentIndex = getStudentIndex(); // Get student index

        if (studentIndex < 0)
        {
            // getStudentIndex already handled messaging.
        }
        else if (studentIndex >= 0) // If index is reasonable
        {
            double avg = averageGrade(studentIndex);

            // averageGrade returns 0 if the student has no grades (and it prints a message in that case).
            // Here I only print the average if it's greater than 0 (avoids printing "0" after the "Add grades first" message).
            if (avg > 0)
                Console.WriteLine($"Average grade for [{students[studentIndex]}] is: {Math.Round(avg, 1)}");
        }
    }

    // Compute average for a student's grades.
    // - If there are zero grades, prints "Add grades first" and returns 0.
    // - Otherwise sums using LINQ's Sum() and divides by the count.
    public static double averageGrade(int studentIndex)
    {
        if (grades[studentIndex].Count == 0)
        {
            Console.WriteLine("Add grades first");
            return 0;
        }

        double sum = grades[studentIndex].Sum();
        return sum / grades[studentIndex].Count;
    }

    /*
    getStudentIndex:
    - Prints the list of available students with their numeric indexes.
    - Prompts the user to enter an index.
    - Returns:
        * a non-negative integer: a chosen student index
        * -1: invalid index typed (or parsing failed)
        * -2: there are no students yet (empty students list)
    Note: the function both prints prompts and returns an integer status; callers check the return value.
    */
    public static int getStudentIndex()
    {
        if (students.Count > 0)
        {
            Console.WriteLine("Available students:");

            // Print students and their indexes for the user to pick from
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"[{i}]: {students[i],-20}");
            }

            // Accept student index input
            Console.Write("Enter student index: ");
            string strStudentIndex = Console.ReadLine().Trim();

            // If proper index inputted: parse and ensure it's non-negative and not out of the allowed check.
            // Returns -1 if parsing fails or index is invalid.
            if (int.TryParse(strStudentIndex, out int studentIndex) && studentIndex >= 0 && studentIndex <= students.Count)
                return studentIndex;
            else
            {
                Console.WriteLine("Non-existent index chosen\n");
                return -1;
            }
        }
        else
        {
            // No students yet; let the caller know by returning -2.
            Console.WriteLine("Add students first");
            return -2;
        }
    }

    /*
    getGradeIndex:
    - Prints the grades for the chosen student (with indexes).
    - Prompts for a grade index to modify.
    - Returns:
        * non-negative integer: chosen grade index
        * -1: parsing failed or invalid index chosen
        * -2: student currently has no grades
    */
    public static int getGradeIndex(int stuIndex)
    {
        if (grades[stuIndex].Count > 0) // If the student has grades
        {
            for (int i = 0; i < grades[stuIndex].Count; i++)
            {
                Console.WriteLine($"[{i}]: {grades[stuIndex][i]}");
            }

            // Accept grade index
            Console.Write("\nEnter grade index: ");
            string strGradeIndex = Console.ReadLine();

            // If proper index inputted
            if (int.TryParse(strGradeIndex, out int gradeIndex) && gradeIndex >= 0 && gradeIndex < grades[stuIndex].Count)
                return gradeIndex;
            else
            {
                Console.WriteLine("Non-existent index chosen\n");
                return -1;
            }
        }
        else
        {
            Console.WriteLine("Add grades first");
            return -2;
        }
    }

    // Cleanly exit the program by breaking the main loop.
    public static void EXIT()
    {
        Console.WriteLine("Goodbye User");
        running = false;
    }
}