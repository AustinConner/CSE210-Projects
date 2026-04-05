using System.ComponentModel;

class CreateNoteView : View
{
    public override ViewName Show()
    {
        // Check if person is selected
        if (State.GetSelectedPerson() == null)
        {
            // if not, select one.
            State.NextView(ViewName.CreateNote);
            return ViewName.SelectPerson;
        }

         Header($"Create Note for {State.GetSelectedPerson().GetName()}");

        Console.WriteLine("What type of a note would you like to create?");
        Console.WriteLine("1. Gift Idea");
        Console.WriteLine("2. Interest Note");
        Console.WriteLine("3. Life Event Note");
        Console.WriteLine("4. Custom Note");
        Console.WriteLine("5. Go Back");

        int choice = InputService.GetMenuChoice(1,5);

        Note note;
        
        switch(choice)
        {
            case 1:
            GiftIdeaNote giftNote = new();
            giftNote.Add();
            note = giftNote;
            break;

            case 2:
            InterestNote interestNote = new();
            interestNote.Add();
            note = interestNote;            
            break;

            case 3:
            LifeEventNote lifeEventnote = new();
            lifeEventnote.Add();
            note = lifeEventnote;               
            break;

            case 4:
            CustomNote customNote = new();
            customNote.Add();
            note = customNote;
            break;

            case 5:
            return State.GetPreviousView();

            default:
            CustomNote defaultNote = new();
            defaultNote.Add();
            note = defaultNote;
            break;

        }

        State.GetSelectedPerson().AddNote(note);

        return ViewName.ViewNotes;
    }
}