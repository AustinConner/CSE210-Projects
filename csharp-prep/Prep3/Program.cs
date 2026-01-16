using System;
using System.Diagnostics;

string continueGame = "yes";

while (continueGame == "yes")
{
    Console.Write("Choosing magic number... ");
    Random randomGenerator = new Random();
    int magicNumber = randomGenerator.Next(1,11);
    int guessCount = 0;
    string userInput;
    bool guessing = true;
    while (guessing == true)
    {
        Console.Write("What is your guess? ");
        userInput = Console.ReadLine();
        int userGuess = int.Parse(userInput);

        guessCount += 1;

        if (userGuess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else if (userGuess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (userGuess == magicNumber)
        {
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"It took you {guessCount} tries!");
            guessing = false;
        }
    }
    Console.WriteLine("Want to play again? Type 'yes'!");
    userInput = Console.ReadLine();

    if (userInput != "yes")
    {
        continueGame = "No";
    }


}
