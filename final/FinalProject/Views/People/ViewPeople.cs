using System.Runtime.InteropServices;

class ViewPeople() : View
{
    public override ViewName Show()
    {
        Header("All People");
        if (People.GetCount() == 0)
        {
            Console.WriteLine("You don't have anyone added yet. Add some people first.");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
            return ViewName.MainMenu;
        }

        Console.WriteLine("Select a person to view their details.");
        State.NextView(ViewName.PersonDetails);
        return ViewName.SelectPerson;
    }
}