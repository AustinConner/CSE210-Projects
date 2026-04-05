class CreateNoteView : View
{
    public override ViewName Show()
    {
        Header("Create Note");

        Console.WriteLine("What type of a note would you like to create?");

        

        return ViewName.MainMenu;
    }
}