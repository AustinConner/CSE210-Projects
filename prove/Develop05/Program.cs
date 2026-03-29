using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
         if(Tui.MainMenu() == false)
            {
             running = false;   
            }

        }
    }
}