class TextInteraction : Interaction
{
    // Ask the user questions about this interaction.
    public TextInteraction()
    {
        SetType("Text");
        SetLocation("Text Messaging App");
        
        base.BasicInteractionInfo();   
    }
}