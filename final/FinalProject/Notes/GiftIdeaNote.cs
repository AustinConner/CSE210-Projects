class GiftIdeaNote : Note
{
    // prompt the user for questions related to this note.

    public void Add()
    {
        string idea = InputService.GetString("Enter your gift idea: ");
        
        base.SetType("Gift Idea");
        base.SetContent(idea);
    }
}