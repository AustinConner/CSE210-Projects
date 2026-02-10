using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

public class Scripture
{
    // fields
    string _scripture;
    Reference _scriptureRef;
    bool _isCompletelyHidden;
    List<Word> _words; 
    int _totalWords;
    int _wordsHidden;

    // constructors
    Scripture(string scriptureTxt, Reference scriptureRef)
    {
        // set the scripture
        _scripture = scriptureTxt;

        // set scripture reference
        _scriptureRef = scriptureRef;

        // convert scripture to words.
        convertScriptureToWords(_scripture);
    }

    // methods
    public void HideWord()
    {
        // hide the word
    }

    public void CheckComplete()
    {
        // verify if everything has been guessed
    }

    public void Display()
    {
        // Get the scripture

        // Check 'Word' items for "shown" state.
        // if _shown = false,
        //  if word != any punctuation, 
        //      change each character to a '_'

        // print the book, chapter, and verses on the top.

        // print verse number, and words
    }

    // private methods (only usable inside this class.)
    private void convertScriptureToWords(string scriptureTxt)
    {
        // itterate through scripture 

        // pull each word from the scriputre and append the word
        // to the _words list. * don't worry about punctuation.
        // (Split on whitespace?)

        // count each word in the list. Excluding numbers.
    }
}