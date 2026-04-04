using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

class MenuManager
{
    MenuFlow _currentMenu = MenuFlow.MainMenu;

    // initialize the menus
    Menus myMenus = new();

    public enum MenuFlow
    {
        MainMenu,
        ViewPeople,
        AddPeople,
        RemovePeople,
        LogInteraction,
        CreateNote,
        Quit,
    }

   public void ShowMenu(MenuFlow MenuName)
    {
        switch (MenuName)
        {
            case MenuFlow.MainMenu:
            _currentMenu = MenuFlow.MainMenu;
            myMenus.Main();
            break;

            case MenuFlow.ViewPeople:
            break;
        }
    }
}