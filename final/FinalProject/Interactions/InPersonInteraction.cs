using System.ComponentModel;

class InPersonInteraction : Interaction
{
    // Ask the user questions about this interaction.
    // Where
    public void Add()
    {
        Console.WriteLine("Where did you see each other?");
        string location = Console.ReadLine();

        Console.WriteLine("What date? ");
        string date = Console.ReadLine();

        Console.WriteLine("Why did you meet?");
        string why = Console.ReadLine();

        Console.WriteLine("Did you make any future plans?");
        string plans = Console.ReadLine();
    }
}