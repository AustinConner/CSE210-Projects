class GiftIdeaNote : Note
{
    // prompt the user for questions related to this note.

    public void Add()
    {
        Console.WriteLine("Enter your gift idea:");
        string idea = Console.ReadLine();
        
        base.SetType("Gift Idea");
        base.SetContent(idea);
    }
}