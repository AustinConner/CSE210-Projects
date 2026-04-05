class InterestNote : Note
{
    // prompt the user for questions related to this note.
    public void Add()
    {
        Console.WriteLine("Write the interst you want to log: ");
        string interest = Console.ReadLine();

        base.SetType("Interest");
        base.SetContent(interest);
    }
}