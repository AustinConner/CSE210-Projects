using System;

class Program
{
    static void Main(string[] args)
    {
        MenuManager menuManager = new();
        menuManager.ShowMenu(MenuManager.MenuFlow.MainMenu);
    }
}