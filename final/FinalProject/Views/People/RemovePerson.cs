using System.Numerics;

class RemovePerson : View
{
    public override ViewName Show()
    {
        Header("Delete Person");

        Console.WriteLine("Select the person you would like to delete");
        People.GetPeopleNumbered();
    
        int total = People.GetCount();

        

        return ViewName.MainMenu;
    }
}