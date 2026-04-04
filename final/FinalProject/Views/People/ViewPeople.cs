using System.Runtime.InteropServices;

class ViewPeople() : View
{
    public override ViewName Show()
    {
        Header("All People");
        Console.WriteLine("Here is a list of all the people logged in Relationship Manager");

        // Print a list of everyone in the relationship manager.
        People.GetPeople();

        Console.ReadLine();

        return ViewName.MainMenu;
    }
}