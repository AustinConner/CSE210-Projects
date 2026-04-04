using System.Dynamic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;

class Person
{
    // What is the persons name?
    private string _name;
    private string _relationshipType; // Acquaintance, CoWorker, Friend, Partner
    private List<string> _hobbies; // list of hobbies.
    private List<Note> _importantNotes;
    private Person _partner; // link to their partner in the database
    private List<Person> _pastPartners; // I ain't judging (auto populates)
    private List<Person> _children; // link to kids in the database
    private List<Person> _parents; // Link to person's parents in db if you want
    private string _employer; // where person works
    private List<string> _pastEmployers; // past employers for a person (auto populates)
    private string _birthday;
    private string _favoriteColor;
    private string _dateAdded; // when a person was added

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

    // Add hobbies
    public void AddHobby(string hobby)
    {
        _hobbies.Add(hobby);
    }

    // Add notes
    public void AddNote(Note newNote)
    {
        _importantNotes.Add(newNote);
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

    // Add child to person
    public void AddChild(Person child)
    {
        _children.Add(child);
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

    // Add previous employers manually
    public void AddPreviousEmployer(string previousEmployer)
    {
        _pastEmployers.Add(previousEmployer);
    }

    // Set birthday
    public void SetBirthday(string birthday)
    {
        _birthday = birthday;
    }

    // Set fav color
    public void SetFavColor(string favoriteColor)
    {
        _favoriteColor = favoriteColor;
    }

    // Set date person was added.
    private void SetAddDate()
    {
        // TODO: Get the current date and add it to _dateAdded;
    }
    
}