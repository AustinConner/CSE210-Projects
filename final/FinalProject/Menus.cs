using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Menus
{   

    public int LoopForChoice(Action menuOptions, int min, int max)
    {
        Console.Clear();
        int userChoice;
        
        while (true)
        {
            menuOptions();
            userChoice = InputService.GetMenuChoice(min, max);
            if (userChoice > 0) break;
        }
        return userChoice;
    }

    public int Main()
    {
        return LoopForChoice(MainOptions, 1, 6);
    }
    // Options that get listed in the main manu.
    private void MainOptions()
    {
        Console.WriteLine("1. View People");
        Console.WriteLine("2. Add People");
        Console.WriteLine("3. Remove People");
        Console.WriteLine("4. Log Interaction");
        Console.WriteLine("5. Create Note");
        Console.WriteLine("6. Quit.");
    }

    public int ViewPeople()
    {
        return LoopForChoice(ViewPeopleOptions, 1, 2);
    }
    public void ViewPeopleOptions()
    {
    }

    public void AddPeople()
    {
        
    }

    public void RemovePeople()
    {
        
    }

    public void LogInteraction()
    {
        
    }

    public void CreateNote()
    {
        
    }
}