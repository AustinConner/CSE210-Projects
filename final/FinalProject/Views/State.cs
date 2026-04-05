// Maintain the state of things when using router
using System.IO.Compression;
using System.Net;
using System.Xml.Serialization;

static class State
{
    // current menu
    private static ViewName _currentView = ViewName.MainMenu; // setting to main menu because that's the first state the program needs to start in. It'll be overridden. 

    // Currently selected person
    private static int _selectedPerson;

    // Current Note
    private static Note _currentNote;

    /* 
    Methods
    */
    // Set the current view;
    public static void SetView(ViewName view)
    {
        _currentView = view;
    }

    // Select a person
    private static void SelectPerson(int index)
    {
        _selectedPerson = index;
    }

    // Set a current note
    public static void SetNote(Note note)
    {
        _currentNote = note;
    }

    /* 
    GETTERS
    */

    public static ViewName GetView()
    {
        return _currentView;
    }

}