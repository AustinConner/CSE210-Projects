/// <summary>
/// Allows editing an existing person's details.
/// </summary>
class EditPerson : View
{
    public override ViewName Show()
    {
        if (State.GetSelectedPerson() == null)
        {
            State.NextView(ViewName.EditPerson);
            return ViewName.SelectPerson;
        }

        Person person = State.GetSelectedPerson();

        Header($"Edit {person.GetName()}");
        PersonPrompts.PrintSummary(person);

        Console.WriteLine("1. Name");
        Console.WriteLine("2. Relationship Type");
        Console.WriteLine("3. Add Hobby");
        Console.WriteLine("4. Birthday");
        Console.WriteLine("5. Favorite Color");
        Console.WriteLine("6. Employer");
        Console.WriteLine("7. Link Partner");
        Console.WriteLine("8. Link Children");
        Console.WriteLine("9. Link Parents");
        Console.WriteLine("10. Done");

        int choice = InputService.GetMenuChoice(1, 10);

        switch (choice)
        {
            case 1: PersonPrompts.GetName(person); break;
            case 2: PersonPrompts.GetRelationshipType(person); break;
            case 3: PersonPrompts.AddHobbies(person); break;
            case 4: PersonPrompts.SetBirthday(person); break;
            case 5: PersonPrompts.SetFavColor(person); break;
            case 6: PersonPrompts.AddEmployer(person); break;
            case 7: PersonPrompts.LinkPartner(person); break;
            case 8: PersonPrompts.LinkChildren(person); break;
            case 9: PersonPrompts.LinkParents(person); break;
        }

        if (choice != 10)
        {
            return ViewName.EditPerson;
        }
        return ViewName.PersonDetails;
    }
}
