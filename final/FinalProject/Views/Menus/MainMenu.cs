using System.Collections;

class MainMenu : View
{
    public override ViewName Show()
    {
        while (true)
        {
            Console.Clear();
            Header("Main Menu");
            Console.WriteLine("1. View People");
            Console.WriteLine("2. Add Person");
            Console.WriteLine("3. Remove Person");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");

            int choice = InputService.GetMenuChoice(1, 6);

            switch (choice)
            {
                case 1: return ViewName.ViewPeople;
                case 2: return ViewName.CreateNewPerson;
                case 3: return ViewName.RemovePerson;
                case 4:
                    SaveLoadService.Save();
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 5:
                    SaveLoadService.Load();
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case 6: return ViewName.Quit;
            } 
        }
    }
}