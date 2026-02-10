using System.ComponentModel;

public class Reference
{
    // fields
    string _book;
    int _chapter;
    int _startVerse;
    int _endVerse;

    // constructors
    Reference(string book, int chapter, int startVerse, int endVerse)
    {
        /* create a reference that has a
        starting verse and ending verse. */
    }

    Reference(string book, int chapter, int verse)
    {
        // create a reference with only a single verse
    }
}