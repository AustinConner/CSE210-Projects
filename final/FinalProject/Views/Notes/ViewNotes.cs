class ViewNotes : View
{
    public override ViewName Show()
    {
        if (State.GetSelectedPerson() == null)
        {
            State.NextView(ViewName.ViewNotes);
            return ViewName.SelectPerson;
        }

        Person person = State.GetSelectedPerson();
        Header($"Notes for {person.GetName()}");

        List<Note> notes = person.GetNotes();

        if (notes.Count == 0)
        {
            Console.WriteLine("No notes added yet.");
        }
        else
        {
            int counter = 1;
            foreach (Note note in notes)
            {
                Console.Write($"{counter}. ");
                note.Display();
                counter += 1;
            }
        }

        Console.WriteLine();
        Console.WriteLine("1. Delete a note");
        Console.WriteLine("2. Back");
        int choice = InputService.GetMenuChoice(1, 2);

        if (choice == 1 && notes.Count > 0)
        {
            Console.WriteLine("Select the number of the note to delete:");
            int menuChoice = InputService.GetMenuChoice(1, notes.Count);
            Note toDelete = notes[menuChoice - 1];
            toDelete.Display();
            bool yes = InputService.YesNo("Are you sure you want to delete this note?");
            if (yes)
            {
                person.RemoveNote(toDelete);
            }
            return ViewName.ViewNotes; // refresh
        }

        return ViewName.PersonDetails;
    }
}
