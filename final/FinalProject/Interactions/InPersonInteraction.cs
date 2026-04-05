using System.ComponentModel;

class InPersonInteraction : Interaction
{
    // Ask the user questions about this interaction.
    // Where
    public void Add()
    {
        SetType("In-Person");

        Console.WriteLine("Where did you see each other?");
        string location = Console.ReadLine();
        SetLocation(location);

        BasicInteractionInfo();
    }
}