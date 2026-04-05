using System.Data.Common;
using System.Dynamic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;

class Person
{
    // What is the persons name?
    private string _name;
    private string _relationshipType; // Acquaintance, CoWorker, Friend, Partner
    private List<string> _hobbies = new(); // list of hobbies.
    private List<Note> _importantNotes = new();
    private Person _partner; // link to their partner in the database
    private List<Person> _pastPartners = new(); // I ain't judging (auto populates)
    private List<Person> _children = new(); // link to kids in the database
    private List<Person> _parents = new(); // Link to person's parents in db if you want
    private string _employer; // where person works
    private List<string> _pastEmployers = new(); // past employers for a person (auto populates)
    private string _birthday;
    private string _favoriteColor;
    private List<Interaction> _interactions = new();

    /* 
    METHODS
    */
    

    // Set the name of a person
    public void SetName(string name)
    {
        _name = name;
    }
    public string GetName()
    {
        return _name;
    }

    // Set the relationship type
    public void DefineRelationship(string relationship)
    {
        _relationshipType = relationship;
    }

    // Get a relationship
    public string GetRelationship()
    {
        return _relationshipType;
    }

    // Add hobbies
    public void AddHobby(string hobby)
    {
        _hobbies.Add(hobby);
    }

    public string GetHobbies()
    {
        if (_hobbies.Count == 0) return "None";
        return string.Join(", ", _hobbies);
    }

    // Add notes
    public void AddNote(Note newNote)
    {
        _importantNotes.Add(newNote);
    }

    public int GetNoteCount()
    {
        return _importantNotes.Count();
    }

    public List<Note> GetNotes()
    {
        return _importantNotes;
    }

    public void RemoveNote(Note note)
    {
        _importantNotes.Remove(note);
    }

    public void AddInteraction(Interaction interaction)
    {
        _interactions.Add(interaction);
    }

    public List<Interaction> GetInteractions()
    {
        return _interactions;
    }

    public int GetInteractionCount()
    {
        return _interactions.Count;
    }

    // Add a partner
    public void AddPartner(Person partner)
    {
        // Check if there's a partner defined already
        if (_partner == null)
        {
        // They don't have one defined yet
            _partner = partner;
        } else
        {
            // They do have one defined.
            _pastPartners.Add(_partner); // add their past partner
            _partner = partner; // Link their new one.
        }
    }

    public string GetPartner()
    {
        if (_partner == null) return "None";
        return _partner.GetName();
    }

    // Add child to person
    public void AddChild(Person child)
    {
        _children.Add(child);
    }

    public string GetChildren()
    {
        if (_children.Count == 0) return "None";
        return string.Join(", ", _children);
    }

    // Add partents to a person
    public void AddParent(Person parent)
    {
        /* 
        TODO: add check to see if there's more than 2 parents in the list and
        Might want to add something sometime to ask user if a newly added parent
        is a step parent.
        */
        _parents.Add(parent);
    }

    public string GetParents()
    {
        if (_parents.Count == 0) return "None";
        return string.Join(", ", _parents);
    }

    // Add employer
    public void AddEmployer(string employer)
    {
        // Check to see if employeer is already defined
        if (_employer == null)
        {
            // don't have one defined
            _employer = employer;   
        } else
        {
            // one is already defined
            _pastEmployers.Add(_employer); // add to past employer
            _employer = employer; // define the new one
        }
    }
    public string GetEmployeer()
    {
        if (_employer == null) return "None";
        return _employer;
    }

    // Add previous employers manually
    public void AddPreviousEmployer(string previousEmployer)
    {
        _pastEmployers.Add(previousEmployer);
    }

    public List<string> GetPastEmployers()
    {
        return _pastEmployers;
    }
    public List<Person> GetChildrenList()
    {
        return _children;
    }
    public List<Person> GetParentsList()
    {
        return _parents;
    }
    public List<Person> GetPastPartners()
    {
        return _pastPartners;
    }
    public List<string> GetHobbiesList()
    {
        return _hobbies;
    }

    // Set birthday
    public void SetBirthday(string birthday)
    {
        _birthday = birthday;
    }
    public string GetBirthday()
    {
        if (_birthday == null) return "None";
        return _birthday;
    }

    // Set fav color
    public void SetFavColor(string favoriteColor)
    {
        _favoriteColor = favoriteColor;
    }

    public string GetFavoriteColor()
    {
        if (_favoriteColor == null) return "None";
        return _favoriteColor;
    }

    // Set date person was added.
    private void SetAddDate()
    {
        // TODO: Get the current date and add it to _dateAdded;
    }
    
}