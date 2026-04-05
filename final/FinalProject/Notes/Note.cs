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
}