using System.Runtime.ConstrainedExecution;

/// <summary>
/// Allows for someone to create a new person to add to the database.
/// </summary>
class CreateNewPerson() : View
{
    // Dictonary to store specified values and print them later.
    Dictionary<string, string> _userChoices = new();
    Person newPerson = new();

    public override ViewName Show()
    {
        // Clear the dictonary in case someone runs this to add multiple new people.
        _userChoices.Clear();

        Header("Add Person");
        GetName();
        Console.Clear();
        GetRelationshipType();

        Console.Clear();
        AskAddHobby();

        Console.Clear();
        SetBirthday();

        Console.Clear();
        SetFavColor();

        Console.Clear();
        AskAddNote();

        Console.Clear();
        AskAddPartner();

        Console.Clear();
        AskAddChild();

        Console.Clear();
        AskAddParents();

        Console.Clear();
        AskAddEmployer();

        Console.Clear();

        SavePerson();

        return ViewName.MainMenu;
    }
    
    // Save the new person to manager
    public void SavePerson()
    {
     People.AddPerson(newPerson);   
    }

    // easily add items into the _userChoices dictonary for clean console UI
    private void Track(string key, string value)
    {
        _userChoices.Add(key, value);
    }

    // Print the currently set values
    private void PrintSummary()
    {
        Console.Clear();
        Console.WriteLine($"Details for {newPerson.GetName()}");

        foreach (KeyValuePair<string, string> entry in _userChoices)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }

        Console.WriteLine("");
    }

    // get the persons name to add
    private void GetName()
    {
        Console.WriteLine("What is the person's name you want to add?");
        string name = Console.ReadLine();
        newPerson.SetName(name);
        Track("Name", name);


    }

    private void GetRelationshipType()
    {
        PrintSummary();
        Console.WriteLine($"How would you define your relationship with {newPerson.GetName()}?");
        Console.WriteLine("1. Acquaintance");
        Console.WriteLine("2. Friend");
        Console.WriteLine("3. Partner");
        Console.WriteLine("4. Co-Worker");

        int sel = InputService.GetMenuChoice(1,4);

        string relationship = "";

        switch (sel)
        {
            case 1:
            relationship = "Acquaintance";
            break;

            case 2:
            relationship = "Friend";
            break;

            case 3:
            relationship = "Partner";
            break;  

            case 4:
            relationship = "Co-Worker";
            break;
        }
        Track("Relationship", relationship);
        newPerson.DefineRelationship(relationship);
    }

    // add hobbies?
    private void AskAddHobby()
    {
        PrintSummary();
        Console.WriteLine($"Do you want to add any of {newPerson.GetName()}'s hobbies?");
        bool yes = InputService.YesNo();

        if (yes)
        {
            AddHobby();
        }
        else
        {
            Console.WriteLine("Skipping...");
            Track("Hobbies", "None Added.");
        }
    }
    private void AddHobby()
    {
        string hobbies = "";
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"What hobby do you want to add for {newPerson.GetName()}?");
            string newHobby = Console.ReadLine();
            // TODO add input service method to verify a choice.
            newPerson.AddHobby(newHobby);
            // Add hobbies to the dictonary as a string
            if (hobbies == "")
            {
                hobbies = newHobby;
            } else
            {
                hobbies += $", {newHobby}"; // only need comma if there's more than one hobby.
            }
            Console.WriteLine("Do you want to add more hobbies?");
            bool yes = InputService.YesNo();

            if (!yes)
            {
                Track("Hobbies", hobbies);
                break;
            }
        }
    }

    private void AskAddNote()
    {
        PrintSummary();
        Console.WriteLine($"Do you want to add any notes to {newPerson.GetName()}?");
        bool yes = InputService.YesNo();
        if (yes)
        {
            AddNote();
        }
        else
        {
            Track("Notes", "None added.");
        }
    }
    private void AddNote()
    {
        PrintSummary();
        int totalNotes = 0;
        
        while (true)
        {
            // TODO: Create "Note" class and view to create notes.
        }
    }

    private void AskAddPartner()
    {
        PrintSummary();
        Console.WriteLine($"Do you want to link a partner to {newPerson.GetName()} from your database?");
        bool yes = InputService.YesNo();
        if (yes)
        {
            AddPartner();
        } else
        {
            Track("Partner", "None linked.");
        }
    }
    private void AddPartner()
    {
        // TODO: List all the people in the database and show their index so someone
        // can link them to another person.

        // add tracking
    }

    private void AskAddChild()
    {
        PrintSummary();
        Console.WriteLine($"Does {newPerson.GetName()} have children?");
        bool hasKids = InputService.YesNo();
        if (!hasKids)
        {
            Track("Children", "N/A");
            return; // person has no kids
        } 

        // person has kids
        Console.WriteLine($"Do you want to link children to {newPerson.GetName()} from your database?");
        bool yes = InputService.YesNo();
        if (yes)
        {
            AddChild();
        } else
        {
            Track("Children", "None linked.");
        }
    }
    private void AddChild()
    {
        // TODO: List all the people in the database and show their index so someone
        // can link them to another person.
    }

    private void AskAddParents()
    {
        PrintSummary();
        Console.WriteLine($"Do you have {newPerson.GetName()}'s parents in your database?");
        bool parentsInDB = InputService.YesNo();
        if (!parentsInDB)
        {
            // Parents not in database
            Track("Parents", "None to link.");
            return; // person has no kids
        } 

        // Parents ARE in database
        Console.WriteLine($"Do you want to link them to {newPerson.GetName()} from your database?");
        bool yes = InputService.YesNo();
        if (yes)
        {
            AddParents();
        } else
        {
            Track("Parents", "None linked.");
        }
    }
    private void AddParents()
    {
        // TODO: List all the people in the database and show their index so someone
        // can link them to another person.
    }

    private void AskAddEmployer()
    {
        PrintSummary(); 
        Console.WriteLine($"Do you want to add an employer for {newPerson.GetName()}?");
        bool addEmployer = InputService.YesNo();
        if (!addEmployer)
        {
            Track("Employers", "Not linking.");
            return;
        }

        AddEmployer();
    }
    private void AddEmployer()
    {
        string currentEmployer = "";
        string pastEmployers = "";
        Console.WriteLine($"What is the name of {newPerson.GetName()}'s current employeer?");
        string employer = Console.ReadLine();
        currentEmployer = employer;
        newPerson.AddEmployer(employer);

        while (true)
        {
            Console.WriteLine($"Current past employers: {pastEmployers}");
            Console.WriteLine($"Do you want to add previous employers for {newPerson.GetName()}");            
            bool yes = InputService.YesNo();
            if (yes)
            {
                Console.WriteLine("Enter a previous employer:");
                string past = Console.ReadLine();
                if (pastEmployers == "")
                {
                    // add it normally. no seperator.
                    pastEmployers = past;
                }
                else
                {
                    pastEmployers += $", {past}";
                }
            }
            else
            {
                break;
            }
        }

        Track("Current Employer", currentEmployer);
        Track("Past Employers", pastEmployers);
    }

    private void SetBirthday()
    {
        PrintSummary(); 
        Console.WriteLine($"Do you want to set a birthday for {newPerson.GetName()}");
        bool yes = InputService.YesNo();
        if (yes)
        {
            Console.WriteLine($"When is {newPerson.GetName()}'s birthday?");
            string bday = Console.ReadLine();
            newPerson.SetBirthday(bday);
            Track("Birthday", bday);
        } else
        {
            Track("Birthday", "None added.");
        }
    }
    private void SetFavColor()
    {
        PrintSummary();
        Console.WriteLine($"Do you want to set a favorite color for {newPerson.GetName()}");
        bool yes = InputService.YesNo();
        if (yes)
        {
            Console.WriteLine($"What is {newPerson.GetName()}'s favorite color?");
            string color = Console.ReadLine();
            newPerson.SetFavColor(color);
            Track("Favorite Color", color);
        } else
        {
            Track("Favorite Color", "None added.");
        }
    }
}