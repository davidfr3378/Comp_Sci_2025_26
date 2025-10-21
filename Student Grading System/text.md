# Stuff
using System;
using System.Runtime.InteropServices;
//Create a C# program that simulates a student grades system using 1D and 2D lists.

/*
List stuff:
Add: listName.Add();
Remove: listName.Remove();
RemoveAt: listName.RemoveAt(index);

*/
public class Program
{
    static bool running = true;
    static List<string> students = new List<string>();
    static List<List<double>> grades = new List<List<double>>();


    public static void Main(String[] args)
    {
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

            if (new[] { "1", "2", "3", "4", "5", "6" }.Contains(input)) //Good input
            {
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
                }
            }
            else //Erroneous input
            {

            }
        }


    }


    // ------- UTILITIES -------
    public static void addStudentCaller()
    {
        Console.Write("\n Name of student: ");
        string name = Console.ReadLine();

        if (name == "" || name == " ")
        {
            Console.WriteLine("Invalid Input\n");
        }
        else
        {
            AddStudent(name);
        }

    }
    public static void AddStudent(string name)
    {
        students.Add(name);
        Console.WriteLine("Student Added Successfully");


    }

    public static void addGradeCaller()
    {
        int studentIndex = getStudentIndex();

        if (studentIndex < 0)
        {
            //User has been informed of errors, program will exit this method
        }
        else if (studentIndex >= 0)
        {
            //Ask for grades:
            Console.WriteLine("\n Input grades as comma seperated values (99,98,95,97)"); string strGrades = Console.ReadLine().Trim();

            //try to turn the CSV's to a list:
            bool tempErr = false; // Used to indicate an error in this subsection of the code
            string[] arrGrades = strGrades.Split();
            List<double> listGrades = new List<double>();
            try
            {
                foreach (var grade in arrGrades)
                {
                    listGrades.Add(int.Parse(grade));
                }
            }
            catch (System.FormatException)
            {
                tempErr = true;
                Console.WriteLine("Wrongly formatted Grades");
            }

            if (tempErr)
            {
                //Erroneous input
            }
            else // IF no errors occured, 
            {
                AddGrades(studentIndex, listGrades);
            }
        }
        
    }
    

    public static void AddGrades(int studentIndex, List<double> newGrades)
    {
            grades[studentIndex].AddRange(newGrades);
    }


    public static void DisplayAllStudents()
    {

    }

    public static void modifyGradeCaller()
    {
        int studentIndex = getStudentIndex();
        if (studentIndex < 0)
        {
            //User has been informed of errors, program will exit this method
        }
        else if (studentIndex >= 0)
        {
            int gradeIndex = getGradeIndex(studentIndex);

        }
    }
    public static void ModifyGrade(int studentIndex, int gradeIndex, int newGrade)
    {
        grades[studentIndex][gradeIndex] = newGrade;
    }

    public static void averageGradeCaller() { }
    public static double averageGrade(int studentIndex)
    {
        double sum = 0;
        for (int i = 0; i < grades[studentIndex].Count; i++)
        {
            sum += grades[studentIndex][i];
        }

        return sum;
    }


    /*
    Displays all students and their indedx to the user and returns the index chosen
    IF index chosen does not exist, returns -1;
    IF students list is empty, returns -2;
    */
    public static int getStudentIndex()
    {
        if (students.Count > 0)
        {
            Console.WriteLine("Available students:");

            //Print students in student
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"[{i}]: {students[i],-20}");
            }

            //Accept student index
            Console.Write("Enter student index: "); string strStudentIndex = Console.ReadLine();

            //If proper index inputted
            if (int.TryParse(strStudentIndex, out int studentIndex) && studentIndex > -1)
                return studentIndex;
            else
                Console.WriteLine("Non-existent index chosen\n"); return -1;
        }
        else
        {
            Console.WriteLine("Add students first");
            return -2;
        }
    }
    
    /*
    Displays a student's grades (with indexes)
    IF index chosen does not exist, returns -1;
    */
    public static int getGradeIndex(int stuIndex)
    {//TODO: Check if student has grades at all
        for(int i = 0; i < grades[stuIndex].Count; i++)
        {
            Console.WriteLine($"[{i}]: {grades[stuIndex][i]}");
        }

        //Accept grade index
        Console.Write("\nEnter grade index: "); string strGradeIndex = Console.ReadLine();

        //If proper index inputted
        if (int.TryParse(strGradeIndex, out int gradeIndex) && gradeIndex > -1)
            return gradeIndex;
        else
            Console.WriteLine("Non-existent index chosen\n"); return -1;

    }

    public static void EXIT() { }
}
