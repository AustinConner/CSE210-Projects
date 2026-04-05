class TextInteraction : Interaction
{
    public void Add()
    {
        SetType("Text");
        SetLocation("Text");

        Console.WriteLine("What did you text about?");
        string topic = Console.ReadLine();
        SetTopic(topic);

        Console.WriteLine("When did this happen? (date)");
        string date = Console.ReadLine();
        SetDate(date);

        Console.WriteLine("Did you make plans to meet in the future?");
        bool hasFuturePlans = InputService.YesNo();
        string futurePlans = "None";
        if (hasFuturePlans)
        {
            Console.WriteLine("What are the plans?");
            futurePlans = Console.ReadLine();
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
