class Note
{
    private string _noteType;
    private string _noteContent;

    public void SetType(string noteType)
    {
        _noteType = noteType;
    }

    public void Add(string note)
    {
        _noteContent = note;
    }

}