using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;

public class Scripture
{
    // vars
    private List<Verse> _verses = new List<Verse>(); // hold all the verses

    private Reference _scriptureReference;
    private Random _randomNumber = new Random(); // random number generator

    // methods
    public void AddVerse(int verseNumber, string verseText)
    {
        Verse verseToAdd = new Verse(verseNumber, verseText);
        _verses.Add(verseToAdd);
    }

    public void SetReference(Reference reference)
    {
        _scriptureReference = reference;
    }

    public void Display()
    {
        _scriptureReference.Display();
        foreach (Verse verse in _verses)
        {
            verse.Display();
        }
    }

    // Hide random word in specified verse.
    public void HideRandomWord()
    {
        List<int> visibleVerses = new List<int>();
        for (int i = 0; i <_verses.Count; i++)
        {
            if (_verses[i].IsHidden() == false)
            {
                visibleVerses.Add(i);
            }
        }
        
        if (visibleVerses.Count == 0)
        {
            return;
        }

        int randomIndex = _randomNumber.Next(visibleVerses.Count);
        int randomVerse = visibleVerses[randomIndex];

        _verses[randomVerse].HideRandomWord();
    }

    // Total verses completely hidden
    public int TotalHiddenVerses()
    {
        int complete = 0;
        foreach (Verse verse in _verses)
        {
            if (verse.IsHidden())
            {
                complete += 1;
            }
        }

        return complete;
    }

   // Get total verses
   public int TotalVerses()
    {
        int total = _verses.Count();
        return total;
    }

    public List<ScriptureJson> GetRandomScriptures(int amt) // how many random scriptures?
    {
        // load scriptures json file
        string json = File.ReadAllText("scripture_json/lds-scriptures-json.txt");

        // convert each json object into c# objects
        var loadedJson = JsonSerializer.Deserialize<List<ScriptureJson>>(json); 

        if (loadedJson == null)
        {
            return null;
        } 

        int selection = _randomNumber.Next(loadedJson.Count - 1);
        var selectedVerse = loadedJson[selection];

        // list that holds verses from the same chapter so multiple scripture selections
        // don't go to the next chapter.
        List<ScriptureJson> sameBookAndChapter =  new List<ScriptureJson>();
        List<ScriptureJson> finalList = new List<ScriptureJson>();
        string title = selectedVerse.BookTitle;
        int chapter = selectedVerse.ChapterNumber;

        // itterate over each verse
        foreach (var verse in loadedJson)
        {
            if (verse.BookTitle == title & verse.ChapterNumber == chapter)
            {
                sameBookAndChapter.Add(verse); // keep the verse if the title and chapter number match.
            }
        }

        // choose random verses from the smaller list remaining.
        int totalFinalVerses = sameBookAndChapter.Count;
        int listSize = totalFinalVerses - 1; // we start counting from zero.
        int maxIndex = listSize - amt; // create wiggle room so that we don't select outside range of list
        int randomIndex = _randomNumber.Next(maxIndex);

        // grab total amount of requested scriptures
        for (int i = 1; i <= amt; i++)
        {
            var v = sameBookAndChapter[randomIndex + i];
            finalList.Add(v);
        }
        
        return finalList;
    }
}