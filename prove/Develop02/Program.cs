using System.Dynamic;
using System.Net.Quic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal(); // create journal.
        bool myProgram = true; // Variable for while loop.

        while (myProgram)
        {
            Console.Clear();
            int choice = Menu(); // get choice number from menu

            if (choice == 1) // Write
            {
                AddEntry(myJournal);
                Console.WriteLine("");
            }

            if (choice == 2) // Display
            {
                myJournal.Display();
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
                Console.WriteLine("");
            }

            if (choice == 3) // Load
            {
                Console.WriteLine("What is the filename?");
                string userInput = Console.ReadLine();

                myJournal.Load(userInput);
                Console.WriteLine("\n=====[ LOADED ] =====\n");
            }

            if (choice == 4) // Save
            {
                Console.WriteLine("What is the filename?");
                string userInput = Console.ReadLine();
                myJournal.Save(userInput);
                Console.WriteLine("\n===========[ SAVED ] ===========");
                Console.WriteLine($"Jounral Saved as: {userInput}");
                Console.WriteLine("================================\n");
            }

            if (choice  == 5) // Quit
            {
                myProgram = false;
            }
            }

}

    private static void AddEntry(Journal myJournal)
    {
        // define journal entry "slot"
        Entry newEntry = new Entry();

        // get a random prompt from the journal
        newEntry._prompt = myJournal.GetPrompt();
        
        // prompt user for entry
        string myEntry = newEntry.Create();

        // add entry to journal.
        myJournal._journalEntries.Add(myEntry);
    }

    private static int Menu() // display the menu for user.
    {
        bool select = true;
        int selection = 0;
        while (select)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string userInput = Console.ReadLine();  
            if (int.TryParse(userInput, out selection) == false || selection > 5)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection...");
                Console.WriteLine("Valid selections: 1, 2, 3, 4, 5");
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("");
            } else
            {
                select = false;
            }
        } // end while loop
        
        return selection;
    }
}