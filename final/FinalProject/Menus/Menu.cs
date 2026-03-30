// base for all the other menus
abstract class Menu
{
    // VARIABLES //
    private string _menuTitle;

    // METHODS //
    // constructor for the manu
    public Menu(string menuTitle)
    {
        _menuTitle = menuTitle;
    }

    // show the menu
    public void Display()
    {
        bool active = true;
        while (active)
        {
            Console.Clear();
            Console.WriteLine($"===== {_menuTitle} =====");
            Console.WriteLine();
            // display options for the user to select
            Options();
        }
    }

    // Specify the options that display inside the menu.
    // having this as 'abstract' forces the subclass to override it with something.
    protected abstract void Options();
    
    // show a formatted header
    public virtual void ShowHeader()
    {
        // allow user to set a color of the header
    }

    
    // show a single line of text with color.

    // verify input is valid int
    

    // verify input is valid string

}