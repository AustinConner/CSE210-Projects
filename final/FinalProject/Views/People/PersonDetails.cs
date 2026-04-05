using System.Net.Mail;

class PersonDetails : View
{
    // See person details
    public override ViewName Show()
    {
        // Check if person is selected. If not, we need to select someone.
        if (State.GetSelectedPerson() == null)
        {
            Console.WriteLine("Select the person to additional details.");

            // set the value in the state so that select person routes back to this when it hits the router again.
            State.NextView(ViewName.PersonDetails);
            return ViewName.SelectPerson;
        } else
        {
            Console.Clear();
            Header("Person Details");
            // print the person details
            Person selectedPerson = State.GetSelectedPerson();

            Console.WriteLine($"┌─ {selectedPerson.GetName()} — {selectedPerson.GetRelationship()}");
            Console.WriteLine($"│ Birthday:       {selectedPerson.GetBirthday()}");
            Console.WriteLine($"│ Favorite Color: {selectedPerson.GetFavoriteColor()}");
            Console.WriteLine($"│ Hobbies:        {selectedPerson.GetHobbies()}");
            Console.WriteLine($"│ Employer:       {selectedPerson.GetEmployeer()}");
            Console.WriteLine($"│");
            Console.WriteLine($"│ Partner:        {selectedPerson.GetPartner()}");
            Console.WriteLine($"│ Children:       {selectedPerson.GetChildren()}");
            Console.WriteLine($"│ Parents:        {selectedPerson.GetParents()}");
            Console.WriteLine($"│");
            Console.WriteLine($"│ Notes:          {selectedPerson.GetNoteCount()}");
            Console.WriteLine($"│ Interactions:   {selectedPerson.GetInteractionCount()}");
            Console.WriteLine($"└──────────────────────────────────");

            Console.WriteLine();
            Console.WriteLine("1. Add a note");
            Console.WriteLine("2. Log interaction");
            Console.WriteLine("3. View notes");
            Console.WriteLine("4. View interactions");
            Console.WriteLine("5. Edit person");
            Console.WriteLine("6. Back to people");
            Console.WriteLine("7. Back to main menu");
            int choice = InputService.GetMenuChoice(1, 7);

            switch (choice)
            {
                case 1: return ViewName.CreateNote;
                case 2: return ViewName.LogInteraction;
                case 3: return ViewName.ViewNotes;
                case 4: return ViewName.ViewInteractions;
                case 5: return ViewName.EditPerson;
                case 6:
                State.ClearSelectedPerson();
                return ViewName.ViewPeople;
            }

            State.ClearSelectedPerson();
        }

        return ViewName.MainMenu;
    }
}