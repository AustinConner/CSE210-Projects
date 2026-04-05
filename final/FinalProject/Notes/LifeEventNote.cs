using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

class LifeEventNote : Note
{
    // prompt the user for questions related to this note.
    public void Add()
    {
        string lifeEvent = InputService.GetString("Enter the life event you want to log: ");
        
        base.SetType("Life Event");
        base.SetContent(lifeEvent);
    }
}