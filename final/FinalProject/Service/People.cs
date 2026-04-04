using System.Diagnostics.Contracts;
using System.Runtime.Loader;

class People
{
    // Stores all the people created in the program
    List<Person> _allPeople; 

    // Add person to manager
    public void AddPerson(Person newPerson)
    {
        _allPeople.Add(newPerson);
    }

    // remove person
    public void RemovePerson(int index)
    {
        // TODO: remove someone from _allPeople list based on their index.
    }

    // get people
    public List<Person> GetPeople()
    {
        return _allPeople;
    } 

    // search for people ? (if time permits.)
}