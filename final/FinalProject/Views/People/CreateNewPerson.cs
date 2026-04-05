/// <summary>
/// Allows for someone to create a new person to add to the database.
/// </summary>
class CreateNewPerson() : View
{
    public override ViewName Show()
    {
        Person newPerson = new();

        Header("Add Person");

        PersonPrompts.GetName(newPerson);
        PersonPrompts.PrintSummary(newPerson);
        PersonPrompts.GetRelationshipType(newPerson);
        PersonPrompts.PrintSummary(newPerson);
        PersonPrompts.AddHobbies(newPerson);
        PersonPrompts.PrintSummary(newPerson);
        PersonPrompts.SetBirthday(newPerson);
        PersonPrompts.PrintSummary(newPerson);
        PersonPrompts.SetFavColor(newPerson);
        PersonPrompts.PrintSummary(newPerson);
        PersonPrompts.AddEmployer(newPerson);
        PersonPrompts.PrintSummary(newPerson);
        PersonPrompts.LinkPartner(newPerson);
        PersonPrompts.PrintSummary(newPerson);
        PersonPrompts.LinkChildren(newPerson);
        PersonPrompts.PrintSummary(newPerson);
        PersonPrompts.LinkParents(newPerson);

        People.AddPerson(newPerson);

        return ViewName.MainMenu;
    }
}
