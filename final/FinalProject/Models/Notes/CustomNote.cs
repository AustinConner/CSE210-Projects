using System.ComponentModel;

class CustomNote : Note
{
    public void Add()
    {
        Console.WriteLine("What is this note type?");
        string type = Console.ReadLine();

        Console.WriteLine("What do you want to attach to this note? ");
        string content = Console.ReadLine();

        base.SetType(type);
        base.SetContent(content);
    }
}