// Abstract class/template for a menu.
abstract class View
{
    public abstract ViewName Show();

    // Display text in the header of a menu.
    public void Header(string text)
    {
        Console.WriteLine($"========== {text} ==========");
    }
}