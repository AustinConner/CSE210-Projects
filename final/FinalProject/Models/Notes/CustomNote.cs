using System.ComponentModel;

class CustomNote : Note
{
    public void Add()
    {
        string type = InputService.GetString("What is this note type? ");
        string content = InputService.GetString("What do you want to attach to this note? ");

        base.SetType(type);
        base.SetContent(content);
    }
}