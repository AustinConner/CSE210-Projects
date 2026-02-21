using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Runtime.InteropServices.Marshalling;

public class Reference
{
    //vars
    private string _book;
    private int _chapterNumber;
    private int _startVerse;
    private int _endVerse;

    //constructors
    public Reference(string book, int chapter, int start, int end)
    {
        // reference if there is a start verse AND end verse.
        _book = book;
        _chapterNumber = chapter;
        _startVerse = start;
        _endVerse = end;
    }

    public Reference(string book, int chapter, int start)
    {
        // reference if there is only start verse.
        _book = book;
        _chapterNumber = chapter;
        _startVerse = start;
    }


    //methods
    public void Display()
    {
        // get the reference as a string
        string myRef;

        if (_endVerse <= 0)
        {
            myRef = $"{_book} {_chapterNumber}:{_startVerse}";
        } else
        {
            myRef = $"{_book} {_chapterNumber}:{_startVerse}-{_endVerse}";
        }

        Console.WriteLine(myRef);
    }
}