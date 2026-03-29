static class Input
{
    // Reads an integer, re-prompts if input is not a number.
    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int result)) 
            {
                return result;
            }
            
            Tui.SingleLineColor($" Invalid input. Please enter a number. ", ConsoleColor.DarkRed, ConsoleColor.White);
        }
    }

    // Reads an integer that must fall between a range, re-prompts if out of range or if it's not a number at all
    public static int ReadIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            int userInput = ReadInt(prompt);
            if (userInput >= min && userInput <= max)
            {
             return userInput;   
            }

            Tui.SingleLineColor($" Please enter a number between {min} and {max}. ", ConsoleColor.DarkRed, ConsoleColor.White);
        }
    }

    // Reads a string, re-prompts if the user doesn't enter anything.
    public static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(userInput))
            {
                return userInput;
            }

            Tui.SingleLineColor($" Input cannot be empty. ", ConsoleColor.DarkRed, ConsoleColor.White);
        }
    }
}
