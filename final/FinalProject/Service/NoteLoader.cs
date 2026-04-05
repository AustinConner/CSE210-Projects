/// <summary>
/// Creates Notes from saved data.
/// </summary>
static class NoteLoader
{
    public static Note Create(string type, string content)
    {
        Note note;

        switch (type)
        {
            case "Gift Idea":
                note = new GiftIdeaNote();
                break;
            case "Interest":
                note = new InterestNote();
                break;
            case "Life Event":
                note = new LifeEventNote();
                break;
            default:
                note = new CustomNote();
                break;
        }

        note.Load(type, content);
        return note;
    }
}
