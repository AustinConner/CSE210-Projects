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
    private List<Note> _InteractionNotes = new();
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
    // TODO - Validate inputs
    protected void BasicInteractionInfo()
    {
        string topic = InputService.GetString("What did you talk about?");

        string date = InputService.GetString("When did you interact? (date)");

        bool hasFuturePlans = InputService.YesNo("Did you make plans to meet in the future?");
        string futurePlans = "None";
        if (hasFuturePlans)
        {
            futurePlans = InputService.GetString("What are the plans?");
        }

        // Set the variables
        SetDate(date);
        SetTopic(topic);
        FuturePlans(futurePlans);

        
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

    public string GetDate()
    {
        return _date;
    }
    public string GetTopic()
    {
        return _topic;
    }
    public string GetFuturePlans()
    {
        return _futurePlans;
    }
    public string GetLocation()
    {
        return _location;
    }
    public string GetInteractionType()
    {
        return _interactionType;
    }

    public void Load(string type, string date, string location, string topic, string futurePlans)
    {
        _interactionType = type;
        _date = date;
        _location = location;
        _topic = topic;
        _futurePlans = futurePlans;
    }

    protected void RemoveNote()
    {
        // WIP
    }

    public virtual void Display()
    {
        Console.WriteLine($"┌─ {GetInteractionType()} — {GetDate()}");
        Console.WriteLine($"│  Location:     {GetLocation()}");
        Console.WriteLine($"│  Topic:        {GetTopic()}");
        Console.WriteLine($"│  Future Plans: {GetFuturePlans()}");
        Console.WriteLine($"└────────────────────────────────────────────────────");
    }
}