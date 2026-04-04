using System.IO.Pipes;
using System.Runtime.CompilerServices;

class Person
{
    // What is the persons name?
    private string _name;
    private string _relationshipType; // Acquaintance, CoWorker, Friend, Partner
    private List<string> _hobbies;
    private List<Note> _importantNotes;
    private Person _partner; // link to their partner in the database
    private List<Person> _pastPartners; // I ain't judging
    private List<Person> _children; // link to kids in the database
    private List<Person> _parents; // Link to person's parents in db if you want
    private string _employer;
    private string _birthday;
    private string _favoriteColor;
}