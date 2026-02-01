using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class Entry
{
    // layout for the journal entry
    public string _date;
    public string _prompt;
    public string _userEntry;

    public Entry() // Runs when class is instantiated. 
    {
        _date = GetDate(); // Set entry date to current date.
    }

    public string GetDate() // get the current date.
    {
        DateTime date = DateTime.Now;
        string dateString = date.ToShortDateString();
        return dateString;
    }

    public string Create() // Prompt user to create a journal entry.
    {
        Console.WriteLine(_prompt);
        _userEntry = Console.ReadLine();

        string myEntry = $"Date: {_date} - Prompt: {_prompt}\n{_userEntry}\n";
        return myEntry;
    }

}