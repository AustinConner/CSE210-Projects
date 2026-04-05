class TextInteraction : Interaction
{
    public void Add()
    {
        SetType("Text");
        SetLocation("Text");

        string topic = InputService.GetString("What did you text about?");
        SetTopic(topic);

        string date = InputService.GetString("When did this happen? (date): ");
        SetDate(date);

        bool hasFuturePlans = InputService.YesNo("Did you make plans to meet in the future?");
        string futurePlans = "None";
        if (hasFuturePlans)
        {
            futurePlans = InputService.GetString("What are the plans? ");
        }
        FuturePlans(futurePlans);
    }

    public override void Display()
    {
        Console.WriteLine($"┌─ Text — {GetDate()}");
        Console.WriteLine($"│  Texted about: {GetTopic()}");
        Console.WriteLine($"│  Future Plans: {GetFuturePlans()}");
        Console.WriteLine($"└─────────────────────────────");
    }
}
