using System.Diagnostics.Contracts;
using System.Net.NetworkInformation;
using System.Runtime.Loader;

/// <summary>
/// Manages people.
/// </summary>
static class People
{
    // Stores all the people created in the program
    private static List<Person> _allPeople = new();

    // Add person to manager
    public static void AddPerson(Person newPerson)
    {
        _allPeople.Add(newPerson);
    }

    // remove person
    public static void RemovePerson(Person personYouWantToDelete)
    {
        _allPeople.Remove(personYouWantToDelete);
    }

    // get people
    public static List<Person> GetPeopleAsList()
    {
        return _allPeople;
    }
    
    // Get a person's name and have them numbered based on where they are in the list.
    public static void GetPeopleNumbered()
    {
        int counter = 0;

        foreach(Person person in _allPeople)
        {
            counter += 1;
            Console.WriteLine($"{counter}. {person.GetName()} > {person.GetRelationship()}");
        }
    }

    public static int GetCount()
    {
        return _allPeople.Count;
    }

    // search for people ? (if time permits.)
}