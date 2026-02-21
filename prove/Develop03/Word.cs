using System.Security.Cryptography;
using System.Text;

public class Word
{
    // variables
    private string _word;
    private string _hiddenWord;
    private bool _hidden;

    // constructor
    public Word(string word)
    {
        _word = word;

        // generate the hidden word
        string hiddenWord = new string('_', _word.Length);
        _hiddenWord = hiddenWord;
    }

    // methods
    public void Hide()
    {
        // hide the word
        _hidden = true;
    }

    public string Get()
    {
        if (_hidden)
        {
            return _hiddenWord;
        } else
        {
            return _word;
        }
    }

    public bool IsVisible()
    {
        bool visible = !_hidden;
        return visible;
    }
}