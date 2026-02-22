using System;

class Program
{
    static void Main(string[] args)
    {
        // homework track
        Assignment myAssignment = new Assignment("Samuel Bennett", "Samuel Bennett");
        Console.WriteLine(myAssignment.GetSummary());

        MathAssignment newMathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions",
        "7.3", "8-19");

        Console.WriteLine(newMathAssignment.GetSummary());
        Console.WriteLine(newMathAssignment.GetHomeworkList());

        WritingAssignment newWriting = new WritingAssignment("Mary Waters", "European History",
        "The Causes of World War II");

        Console.WriteLine(newWriting.GetSummary());
        Console.WriteLine(newWriting.GetWritingInfromation());
    }
}