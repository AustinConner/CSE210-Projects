using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Security.Principal;
using System.Transactions;

public class Verse
{
    //var
    private string _verseText;
    private int _verseNumber;
    private List<Word> _words = new List<Word>(); // hold all the words.
    private Random _randomNumber = new Random(); // random number generator
    private bool _allWordsHidden;

    // constuctor
    public Verse(int verseNumber, string verseText)
    {
        _verseNumber = verseNumber;
        _verseText = verseText;
        ToWords();
    }
    // Methods
    // convert verse text to single words and put them into a list.
    private void ToWords()
    {
        string[] words = _verseText.Split(' ');

        foreach (string word in words) // add each word to the list.
        {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    // hide a random word in the verse
    public void HideRandomWord()
    {
        List<int> visibleWords = new List<int>();
        for (int i = 0; i <_words.Count; i++)
        {
            if (_words[i].IsVisible())
            {
                visibleWords.Add(i);
            }
        }
        
        if (visibleWords.Count == 0)
        {
            _allWordsHidden = true;
            return;
        }

        int randomIndex = _randomNumber.Next(visibleWords.Count);
        int randomWord = visibleWords[randomIndex];

        _words[randomWord].Hide();

    }

    // Show the verse
    public void Display()
    {
        Console.Write($"{_verseNumber}: ");

        int consoleWidth = _verseNumber.ToString().Length + 2;

        foreach (Word _word in _words)
        {
         string text = _word.Get();

         if (consoleWidth + text.Length + 1 > 100)
            {
                Console.WriteLine();
                Console.Write("   ");
                consoleWidth = 3;
            }

        Console.Write($"{text} ");
        consoleWidth += text.Length + 1;
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    public bool IsHidden()
    {
        return _allWordsHidden;
    }

}