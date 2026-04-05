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
        Console.WriteLine("1. Add a note");
        Console.WriteLine("2. Delete a note");
        Console.WriteLine("3. Back");
        int choice = InputService.GetMenuChoice(1, 3);

        switch (choice)
        {
            case 1:
                return ViewName.CreateNote;

            case 2:
                if (notes.Count == 0) return ViewName.ViewNotes;
                Console.WriteLine("Select the number of the note to delete:");
                int menuChoice = InputService.GetMenuChoice(1, notes.Count);
                Note toDelete = notes[menuChoice - 1];
                toDelete.Display();
                if (InputService.YesNo("Are you sure you want to delete this note?"))
                {
                    person.RemoveNote(toDelete);
                }
                return ViewName.ViewNotes;

            default:
                return ViewName.PersonDetails;
        }
    }
}
