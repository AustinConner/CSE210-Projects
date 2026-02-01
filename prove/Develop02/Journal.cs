using System.Configuration.Assemblies;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.CompilerServices;
public class Journal
{
    public List<string> _journalEntries = new List<string>();

    public string GetPrompt() // Select a random prompt for the entry.
    {
        List<string> prompts =
        [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
        ];

        Random randomNumber = new Random();

        // Get random number.
        int randomPromptIndex = randomNumber.Next(prompts.Count);

        return prompts[randomPromptIndex];
    }

    public void Display()
    {
        foreach (string item in _journalEntries)
        {
            Console.WriteLine(item);
        }
    }

    public void Save(string filename) // Save journal entries to text file.
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (string item in _journalEntries)
            {
                outputFile.WriteLine(item);
            }
        }
    }

    public void Load(string filename) // Load previously saved jorunal.
    {
        string[] text = File.ReadAllLines(filename);

        // Clear existing entries
        _journalEntries.Clear();

        foreach (string line in text)
        {
            _journalEntries.Add(line);
        }
    }
}