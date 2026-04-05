class InterestNote : Note
{
    // prompt the user for questions related to this note.
    public void Add()
    {
        string interest = InputService.GetString("Write the interest you want to log: ");

        base.SetType("Interest");
        base.SetContent(interest);
    }
}