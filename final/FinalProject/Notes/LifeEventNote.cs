using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

class LifeEventNote : Note
{
    // prompt the user for questions related to this note.
    public void Add()
    {
        Console.WriteLine("Enter the life event you want to log: ");
        string lifeEvent = Console.ReadLine();
        base.SetType("Life Event");
        base.SetContent(lifeEvent);

        // Maybe override something in the "note" class so that we can show a date?
    }
}