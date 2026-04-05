class Note
{
    private string _noteType;
    private string _noteContent;
    private string _addDate;

    protected void SetType(string noteType)
    {
        _noteType = noteType;
    }

    protected void SetContent(string note)
    {
        _noteContent = note;
    }

    protected void AddDate(string date)
    {
        _addDate = date;
    }

    public void Display()
    {
        Console.WriteLine($"[{_noteType}] {_noteContent}");
    }

    public string GetNoteType()
    {
        return _noteType;
    }
    public string GetNoteContent()
    {
        return _noteContent;
    }

    public void Load(string type, string content)
    {
        _noteType = type;
        _noteContent = content;
    }
}