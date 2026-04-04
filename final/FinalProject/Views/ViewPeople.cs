using System.Runtime.InteropServices;

class ViewPeople() : View
{
    public override ViewName Show()
    {
        Header("All People");
        Console.WriteLine("Here is a list of all the people logged in Relationship Manager");
        Console.WriteLine("People would be listedd here");

        Console.ReadLine();

        return ViewName.MainMenu;
    }
}