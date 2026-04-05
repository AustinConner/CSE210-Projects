using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

/// <summary>
/// Routes to different views.
/// </summary>
public class Router
{
    // Create the menu list using the enum in "MenuList.cs" for the key and the "Menu" class for the value.
    private Dictionary<ViewName, View> _views;

    // Add the different Menu enum and their respective menu
    public Router()
    {       
        // Populate the views
         _views = new Dictionary<ViewName, View>()
        {
            // add items into the dictonary linking to other menus
            {ViewName.MainMenu, new MainMenu()},
            {ViewName.ViewPeople, new ViewPeople()},
            {ViewName.CreateNewPerson, new CreateNewPerson()},
            {ViewName.RemovePerson, new RemovePerson()},
            {ViewName.SelectPerson, new SelectPerson()},
            {ViewName.CreateNote, new CreateNoteView()},
        };
    }

    // Start the router.
    public void Run()
    {
        while (State.GetView() != ViewName.Quit)
        {
            State.SetView(_views[State.GetView()].Show());
        }
    }
}