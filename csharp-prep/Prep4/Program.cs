using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numberList = new List<int>();
        bool addToList = true;

        while (addToList)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            int number = int.Parse(userInput);

            if (number == 0)
            {
                addToList = false;
                break;
            }

            numberList.Add(number);
        }
        
        int largestNumber = 0;
        int smallestNumber = numberList.First();
        int sum = 0;
        foreach (int number in numberList)
        {
            if (largestNumber <= number)
            {
                largestNumber = number;
            }

            if (smallestNumber >= number)
            {
                smallestNumber = number;
            }

            sum += number;
        }

        float average = sum / numberList.Count();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest number is {smallestNumber}");

 }

}