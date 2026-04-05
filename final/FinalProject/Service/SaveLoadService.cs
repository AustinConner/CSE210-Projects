/// <summary>
/// Saves and loads all people data to/from a plain text file.
/// </summary>
static class SaveLoadService
{
    private static string _filePath = "data.txt";

    public static void Save()
    {
        Console.Clear();
        Console.WriteLine("========== Save Data ==========");
        List<string> lines = new();

        foreach (Person person in People.GetPeopleAsList())
        {
            SavePerson(person, lines);
        }

        File.WriteAllLines(_filePath, lines);
        Console.WriteLine("Data saved.");
    }

    private static void SavePerson(Person person, List<string> lines)
    {
        lines.Add("PERSON");
        SaveBasicInfo(person, lines);
        SaveHobbies(person, lines);
        SaveEmployers(person, lines);
        SaveLinkedPeople(person, lines);
        SaveNotes(person, lines);
        SaveInteractions(person, lines);
        lines.Add("END_PERSON");
    }

    private static void SaveBasicInfo(Person person, List<string> lines)
    {
        lines.Add($"{person.GetName()}|{person.GetRelationship()}|{person.GetBirthday()}|{person.GetFavoriteColor()}|{person.GetEmployeer()}");
    }

    private static void SaveHobbies(Person person, List<string> lines)
    {
        lines.Add($"HOBBIES|{string.Join(",", person.GetHobbiesList())}");
    }

    private static void SaveEmployers(Person person, List<string> lines)
    {
        lines.Add($"PAST_EMPLOYERS|{string.Join(",", person.GetPastEmployers())}");
    }

    private static void SaveLinkedPeople(Person person, List<string> lines)
    {
        lines.Add($"PARTNER|{person.GetPartner()}");

        List<string> childNames = new List<string>();
        foreach (Person child in person.GetChildrenList())
        {
            childNames.Add(child.GetName());
        }
        lines.Add($"CHILDREN|{string.Join(",", childNames)}");

        List<string> parentNames = new List<string>();
        foreach (Person parent in person.GetParentsList())
        {
            parentNames.Add(parent.GetName());
        }
        lines.Add($"PARENTS|{string.Join(",", parentNames)}");
    }

    private static void SaveNotes(Person person, List<string> lines)
    {
        foreach (Note note in person.GetNotes())
        {
            lines.Add($"NOTE|{note.GetNoteType()}|{note.GetNoteContent()}");
        }
    }

    private static void SaveInteractions(Person person, List<string> lines)
    {
        foreach (Interaction interaction in person.GetInteractions())
        {
            lines.Add($"INTERACTION|{interaction.GetInteractionType()}|{interaction.GetDate()}|{interaction.GetLocation()}|{interaction.GetTopic()}|{interaction.GetFuturePlans()}");
        }
    }

    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("========== Load Data ==========");
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("No save file found...");
            return;
        }

        People.Clear();
        string[] lines = File.ReadAllLines(_filePath);

        LoadPeople(lines);
        LinkPeople(lines);

        Console.WriteLine("Data loaded.");
    }

    // Pass 1: create each person and populate their basic data, notes, and interactions.
    private static void LoadPeople(string[] lines)
    {
        Person current = null;

        foreach (string line in lines)
        {
            if (line == "PERSON")
            {
                current = new Person();
                continue;
            }

            if (line == "END_PERSON")
            {
                if (current != null)
                {
                    People.AddPerson(current);
                }
                current = null;
                continue;
            }

            if (current == null)
            {
                continue;
            }

            string[] parts = line.Split('|');

            if (parts[0] == "PARTNER" || parts[0] == "CHILDREN" || parts[0] == "PARENTS")
            {
                continue;
            }

            switch (parts[0])
            {
                case "HOBBIES":
                    LoadHobbies(current, parts);
                    break;

                case "PAST_EMPLOYERS":
                    LoadPastEmployers(current, parts);
                    break;

                case "NOTE":
                    LoadNote(current, parts);
                    break;

                case "INTERACTION":
                    LoadInteraction(current, parts);
                    break;

                default:
                    LoadBasicInfo(current, parts);
                    break;
            }
        }
    }

    private static void LoadBasicInfo(Person person, string[] parts)
    {
        if (parts.Length >= 5)
        {
            person.SetName(parts[0]);
            person.DefineRelationship(parts[1]);
            if (parts[2] != "None")
            {
                person.SetBirthday(parts[2]);
            }
            if (parts[3] != "None")
            {
                person.SetFavColor(parts[3]);
            }
            if (parts[4] != "None")
            {
                person.AddEmployer(parts[4]);
            }
        }
    }

    private static void LoadHobbies(Person person, string[] parts)
    {
        if (parts.Length > 1 && parts[1] != "")
        {
            foreach (string hobby in parts[1].Split(','))
            {
                person.AddHobby(hobby);
            }
        }
    }

    private static void LoadPastEmployers(Person person, string[] parts)
    {
        if (parts.Length > 1 && parts[1] != "")
        {
            foreach (string emp in parts[1].Split(','))
            {
                person.AddPreviousEmployer(emp);
            }
        }
    }

    private static void LoadNote(Person person, string[] parts)
    {
        if (parts.Length >= 3)
        {
            Note note = NoteLoader.Create(parts[1], parts[2]);
            person.AddNote(note);
        }
    }

    private static void LoadInteraction(Person person, string[] parts)
    {
        if (parts.Length >= 6)
        {
            Interaction interaction = InteractionLoader.Create(parts[1], parts[2], parts[3], parts[4], parts[5]);
            person.AddInteraction(interaction);
        }
    }

    // Pass 2: link partner, children, and parents by name now that all people are loaded.
    private static void LinkPeople(string[] lines)
    {
        Person current = null;

        foreach (string line in lines)
        {
            if (line == "PERSON")
            {
                current = null;
                continue;
            }
            if (line == "END_PERSON")
            {
                current = null;
                continue;
            }

            string[] parts = line.Split('|');

            if (current == null && parts.Length >= 5
                && parts[0] != "HOBBIES"
                && parts[0] != "PAST_EMPLOYERS"
                && parts[0] != "NOTE"
                && parts[0] != "INTERACTION"
                && parts[0] != "PARTNER"
                && parts[0] != "CHILDREN"
                && parts[0] != "PARENTS")
            {
                foreach (Person person in People.GetPeopleAsList())
                {
                    if (person.GetName() == parts[0])
                    {
                        current = person;
                        break;
                    }
                }
                continue;
            }

            if (current == null)
            {
                continue;
            }

            switch (parts[0])
            {
                case "PARTNER":
                    LinkPartner(current, parts);
                    break;

                case "CHILDREN":
                    LinkChildren(current, parts);
                    break;

                case "PARENTS":
                    LinkParents(current, parts);
                    break;
            }
        }
    }

    private static void LinkPartner(Person current, string[] parts)
    {
        if (parts.Length > 1 && parts[1] != "None")
        {
            foreach (Person person in People.GetPeopleAsList())
            {
                if (person.GetName() == parts[1])
                {
                    current.AddPartner(person);
                    break;
                }
            }
        }
    }

    private static void LinkChildren(Person current, string[] parts)
    {
        if (parts.Length > 1 && parts[1] != "")
        {
            foreach (string name in parts[1].Split(','))
            {
                foreach (Person person in People.GetPeopleAsList())
                {
                    if (person.GetName() == name)
                    {
                        current.AddChild(person);
                        break;
                    }
                }
            }
        }
    }

    private static void LinkParents(Person current, string[] parts)
    {
        if (parts.Length > 1 && parts[1] != "")
        {
            foreach (string name in parts[1].Split(','))
            {
                foreach (Person person in People.GetPeopleAsList())
                {
                    if (person.GetName() == name)
                    {
                        current.AddParent(person);
                        break;
                    }
                }
            }
        }
    }
}
