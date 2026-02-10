public class Word
{
    // fields
    string _word;
    bool _shown = true; // word starts as shown

    // contructor
    Word(string myWord)
    {
        // specify the word
        _word = myWord;
    }

    // methods
    public void Hide()
    {
        _shown = false; // hides the word.
    }
}