/// <summary>
/// Shared prompts for creating and editing a person.
/// </summary>
static class PersonPrompts
{
    public static void PrintSummary(Person person)
    {
        Console.Clear();
        Console.WriteLine($"Name:           {person.GetName()}");
        Console.WriteLine($"Relationship:   {person.GetRelationship()}");
        Console.WriteLine($"Birthday:       {person.GetBirthday()}");
        Console.WriteLine($"Favorite Color: {person.GetFavoriteColor()}");
        Console.WriteLine($"Hobbies:        {person.GetHobbies()}");
        Console.WriteLine($"Employer:       {person.GetEmployeer()}");
        Console.WriteLine($"Partner:        {person.GetPartner()}");
        Console.WriteLine($"Children:       {person.GetChildren()}");
        Console.WriteLine($"Parents:        {person.GetParents()}");
        Console.WriteLine();
    }

    public static void GetName(Person person)
    {
        string name = InputService.GetString("What is the person's name? ");
        person.SetName(name);
    }

    public static void GetRelationshipType(Person person)
    {
        Console.WriteLine($"How would you define your relationship with {person.GetName()}?");
        Console.WriteLine("1. Acquaintance");
        Console.WriteLine("2. Friend");
        Console.WriteLine("3. Partner");
        Console.WriteLine("4. Co-Worker");

        int choice = InputService.GetMenuChoice(1, 4);

        string relationship = "";
        switch (choice)
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

        person.DefineRelationship(relationship);
    }

    public static void AddHobbies(Person person)
    {
        Console.WriteLine($"Do you want to add hobbies for {person.GetName()}?");
        bool yes = InputService.YesNo();
        if (!yes) return;

        while (true)
        {
            string hobby = InputService.GetString($"Enter a hobby for {person.GetName()}: ");
            person.AddHobby(hobby);

            Console.WriteLine("Add another hobby?");
            if (!InputService.YesNo()) break;
        }
    }

    public static void SetBirthday(Person person)
    {
        Console.WriteLine($"Do you want to set a birthday for {person.GetName()}?");
        bool yes = InputService.YesNo();
        if (!yes) return;

        string bday = InputService.GetString($"When is {person.GetName()}'s birthday? ");
        person.SetBirthday(bday);
    }

    public static void SetFavColor(Person person)
    {
        Console.WriteLine($"Do you want to set a favorite color for {person.GetName()}?");
        bool yes = InputService.YesNo();
        if (!yes) return;

        string color = InputService.GetString($"What is {person.GetName()}'s favorite color? ");
        person.SetFavColor(color);
    }

    public static void LinkPartner(Person person)
    {
        if (People.GetCount() == 0)
        {
            Console.WriteLine("No people in the database to link.");
            return;
        }

        Console.WriteLine($"Do you want to link a partner to {person.GetName()}?");
        if (!InputService.YesNo()) return;

        People.GetPeopleNumbered();
        int sel = InputService.GetMenuChoice(1, People.GetCount());
        Person partner = People.GetPeopleAsList()[sel - 1];
        person.AddPartner(partner);
    }

    public static void LinkChildren(Person person)
    {
        if (People.GetCount() == 0)
        {
            Console.WriteLine("No people in the database to link.");
            return;
        }

        Console.WriteLine($"Does {person.GetName()} have children in the database?");
        if (!InputService.YesNo()) return;

        while (true)
        {
            People.GetPeopleNumbered();
            int sel = InputService.GetMenuChoice(1, People.GetCount());
            person.AddChild(People.GetPeopleAsList()[sel - 1]);

            Console.WriteLine("Link another child?");
            if (!InputService.YesNo()) break;
        }
    }

    public static void LinkParents(Person person)
    {
        if (People.GetCount() == 0)
        {
            Console.WriteLine("No people in the database to link.");
            return;
        }

        Console.WriteLine($"Do you want to link parents for {person.GetName()}?");
        if (!InputService.YesNo()) return;

        while (true)
        {
            People.GetPeopleNumbered();
            int sel = InputService.GetMenuChoice(1, People.GetCount());
            person.AddParent(People.GetPeopleAsList()[sel - 1]);

            Console.WriteLine("Link another parent?");
            if (!InputService.YesNo()) break;
        }
    }

    public static void AddEmployer(Person person)
    {
        Console.WriteLine($"Do you want to add an employer for {person.GetName()}?");
        bool yes = InputService.YesNo();
        if (!yes) return;

        string employer = InputService.GetString($"What is {person.GetName()}'s current employer? ");
        person.AddEmployer(employer);

        while (true)
        {
            Console.WriteLine("Add a previous employer?");
            if (!InputService.YesNo()) break;

            string past = InputService.GetString("Enter previous employer: ");
            person.AddPreviousEmployer(past);
        }
    }
}
