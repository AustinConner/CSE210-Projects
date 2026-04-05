using System.ComponentModel;

static class InputService
{
    // Prompt the user and return a valid int. Reprompts on invalid input.
    public static int GetInt(string prompt)
    {
        Console.Write(prompt);
        string userInput = Console.ReadLine();
        if (int.TryParse(userInput, out int result)) 
        {
            return result;
        }
        Console.WriteLine("Invalid input. Please enter a whole number.");
        Thread.Sleep(3000); // 3 seconds
        return 0;
    }

    // Prompt the user and return a non-empty string. Returns "" on blank input (caller should reprompt).
    public static string GetString(string prompt)
    {
       while (true)
       { 
        Console.Write(prompt);
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }
        Console.WriteLine("Input cannot be blank.");
      }
    }

    // Prompt the user and return a string, allowing blank/empty input.
    public static string GetOptionalString(string prompt)
    {
        Console.Write(prompt);
        return (Console.ReadLine() ?? "").Trim();
    }

    // Prompt the user for a menu choice within a given range. Loops until valid.
    public static int GetMenuChoice(int min, int max)
    {
        while (true)
        {
            Console.Write($"Enter choice ({min}-{max}): ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int choice) && choice >= min && choice <= max)
                return choice;

            Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
        }
    }

    // Get answer to Yes or No question.
    public static bool YesNo(string prompt)
    {

        while (true)
        {
            Console.WriteLine(prompt);
            Console.WriteLine("(Y)es or (N)o?");
            ConsoleKeyInfo input = Console.ReadKey(true);

            if(input.Key == ConsoleKey.Y) 
            {
                return true;
            } else if (input.Key == ConsoleKey.N)
            {
                return false;
            } else {
                Console.WriteLine($"{input.Key} is invalid. Only Y or N is valid.");
            }
        }
    }
}
