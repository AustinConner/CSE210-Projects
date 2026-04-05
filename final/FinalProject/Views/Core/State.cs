// Maintain the state of things when using router
using System.IO.Compression;
using System.Net;
using System.Xml.Serialization;

static class State
{
    // current view
    private static ViewName _currentView = ViewName.MainMenu; // setting to main menu because that's the first state the program needs to start in. It'll be overridden.

    // previous view
    private static ViewName _previousView = ViewName.MainMenu;

    // next view
    private static ViewName _nextView;

    // selected person
    private static Person _selectedPerson;

    /* 
    Methods
    */
    // Set the current view;
    public static void SetView(ViewName view)
    {
        _previousView = _currentView;
        _currentView = view;
    }

    // Select a person
    public static void SelectPerson(Person selectedPerson)
    {
        _selectedPerson = selectedPerson;
    }

    // Clear selected person
    public static void ClearSelectedPerson()
    {
        _selectedPerson = null;
    }

    // set NextView
    public static void NextView(ViewName nextView)
    {
        _nextView = nextView;
    }


    /* 
    GETTERS
    */

    public static ViewName GetView()
    {
        return _currentView;
    }

    public static ViewName GetNextView()
    {
        return _nextView;
    }

    public static ViewName GetPreviousView()
    {
        return _previousView;
    }

    public static Person GetSelectedPerson()
    {
        return _selectedPerson;
    }

}