using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("Akhabue Matthew", "Addition");
        Console.WriteLine(a1.GetSummary());

        // Now create the derived class assignments
        MathAssignment a2 = new MathAssignment("Mike Henry", "Algebra", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Rock Puttin", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}