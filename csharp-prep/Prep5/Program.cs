using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int birthyear = 0;
        PromptUserBirthYear(out birthyear);
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber, birthyear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine()); 
        return userNumber;
    }
    
    static void PromptUserBirthYear(out int birthyear)
    {
        Console.Write("Please enter the year you were born: ");
        birthyear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;
        return squaredNumber;
    }

    static void DisplayResult(string userName, int squaredNumber, int birthYear)
    {
        int currentYear = 2025;
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
        Console.WriteLine($"{userName}, you will turn {currentYear - birthYear} this year.");
    }

}