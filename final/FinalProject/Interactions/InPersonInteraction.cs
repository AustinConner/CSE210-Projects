using System.ComponentModel;

class InPersonInteraction : Interaction
{
    // Ask the user questions about this interaction.
    // Where
    public void Add()
    {
        SetType("In-Person");

        string location = InputService.GetString("Where did you see each other? ");
        SetLocation(location);

        BasicInteractionInfo();
    }
}