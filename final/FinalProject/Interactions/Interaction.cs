using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO.Compression;

class Interaction
{
    private string _interactionType; 
    // in person, video call, phone call, text
    private string _topic; // what types of things were discussed
    private string _date; // When the interaction occured
    private string _futurePlans;
    private List<Note> _InteractionNotes;
    private string _location;
    // platform/place (park, Signal, Facebook)
    /**********************************************************************
    *                           CONSTRUCTORS                              *
    **********************************************************************/
    // public Interaction()
    // {
    //     BasicInteractionInfo();
    // }


    /**********************************************************************
    *                              METHODS                                *
    **********************************************************************/
    // Interaction information that will be the same accross all interactions
    protected void BasicInteractionInfo()
    {
        Console.WriteLine("What did you talk about?");
        string topic = Console.ReadLine();

        Console.WriteLine("When did you interact? (date)");
        string date = Console.ReadLine();

        Console.WriteLine("Did you make plans to meet in the future?");
        string futurePlans = Console.ReadLine();

        Console.WriteLine("Is there anything you want to make note of for this person since this interaction?");
        string addtlNotes = Console.ReadLine();

        // Set the variables
        SetDate(date);
        SetTopic(topic);

        
    }

    protected void SetType(string type)
    {
        _interactionType = type;
    }

    // date of interaction  
    protected void SetDate(string date)
    {
        _date = date;
    }

    protected void SetLocation(string location)
    {
        _location = location;
    }

    protected void SetTopic(string topic)
    {
        _topic = topic;
    }

    protected void FuturePlans(string plans)
    {
        _futurePlans = plans;
    }

    protected void AddNote()
    {
        // TODO: move this outside of the interaction class.
        Console.WriteLine("Would you like to add any notes to this interaction?");
        string answer = Console.ReadLine();
        // move this somewhere.

        Note newNote = new();
        _InteractionNotes.Add(newNote);
    }

    // Remove an interaction note

    protected void RemoveNote()
    {
        // WIP
    }

    public void GetInteraction()
    {
        // print interaction
    }
}