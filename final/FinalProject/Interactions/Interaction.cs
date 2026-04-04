using System.ComponentModel.DataAnnotations;
using System.Dynamic;

class Interaction
{
    private string _interactionType; 
    // in person, video call, phone call, text
    private string _date; // When the interaction occureds
    private List<Note> _InteractionNotes;

    private string _location;
    // platform/place (park, Signal, Facebook)

    // idea: Custom interaction types

    public void SetInteraction(string type)
    {
        _interactionType = type;
    }

    // date of interaction  
    public void SetDate(string date)
    {
        _date = date;
    }

    public void SetLocation(string location)
    {
        _location = location;
    }

    public void AddNote()
    {
        Console.WriteLine("Would you like to add any notes to this interaction?");
        string answer = Console.ReadLine();
        Note newNote = new();
        _InteractionNotes.Add(newNote);
    }

    public void RemoveNote()
    {
        // WIP
    }

    public void New()
    {
        Console.WriteLine("What type of interaction would you like to log?");
    }

}