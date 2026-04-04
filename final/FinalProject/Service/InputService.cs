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
        Console.Write(prompt);
        string input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }
        Console.WriteLine("Input cannot be blank.");
        Thread.Sleep(3000); // 3 seconds
        return "";
    }

    // Prompt the user and return a string, allowing blank/empty input.
    public static string GetOptionalString(string prompt)
    {
        Console.Write(prompt);
        return (Console.ReadLine() ?? "").Trim();
    }

    // Prompt the user for a menu choice within a given range. Returns 0 on invalid input (caller should reprompt).
    public static int GetMenuChoice(int min, int max)
    {
        int choice = GetInt($"Enter choice ({min}-{max}): ");
        if (choice >= min && choice <= max)
            return choice;

        Console.WriteLine($"Please enter a number between {min} and {max}.");
        Thread.Sleep(3000); // 3 seconds
        return 0;
    }
}
