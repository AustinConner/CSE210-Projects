using System.Diagnostics.Contracts;
using System.Net.NetworkInformation;
using System.Runtime.Loader;

static class People
{
    // Stores all the people created in the program
    private static List<Person> _allPeople;

    // Add person to manager
    public static void AddPerson(Person newPerson)
    {
        _allPeople.Add(newPerson);
    }

    // remove person
    public static void RemovePerson(int index)
    {
        // TODO: remove someone from _allPeople list based on their index.
    }

    // get people
    public static List<Person> GetPeopleAsList()
    {
        return _allPeople;
    }

    public static void GetPeople()
    {
        foreach (Person person in _allPeople)
        {
            
        }
    }

    // search for people ? (if time permits.)
}