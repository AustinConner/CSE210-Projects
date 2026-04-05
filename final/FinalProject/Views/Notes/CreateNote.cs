using System.ComponentModel;

class CreateNoteView : View
{
    public override ViewName Show()
    {
        Header("Create Note");

        // Check if person is selected
        if (State.GetSelectedPerson() == null)
        {
            // if not, select one.
            State.NextView(ViewName.CreateNote);
            return ViewName.SelectPerson;
        }

        Console.WriteLine("What type of a note would you like to create?");

        Console.WriteLine("1. Gift Idea");
        Console.WriteLine("2. Interest Note");
        Console.WriteLine("3. Life Event Note");
        Console.WriteLine("4. Custom Note");

        int choice = InputService.GetMenuChoice(1,4);

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
            default:
            CustomNote customNote = new();
            customNote.Add();
            note = customNote;
            break;
        }

        State.GetSelectedPerson().AddNote(note);
        State.ClearSelectedPerson();

        return ViewName.MainMenu;
    }
}