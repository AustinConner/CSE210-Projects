using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int gradePercentage = int.Parse(userInput);

        string letter = "n";
        bool pass = true;

        if (gradePercentage >= 90)
        {
            letter = "A";

        } else if (gradePercentage >= 80)
        {
            letter = "B";
        } else if (gradePercentage >= 70)
        {
            letter = "C";
        } else if (gradePercentage >= 60)
        {
            letter = "D";
            pass = false;

        } else if (gradePercentage < 60)
        {
            letter = "F";
            pass = false;
        }

        Console.WriteLine($"Your grade is a {letter}");
        if (pass)
        {
            Console.WriteLine("You passed :)");
        } else
        {
            Console.WriteLine("You failed... Better luck next time.");
        }
    }
}