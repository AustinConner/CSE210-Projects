using System.Diagnostics;
using System.Runtime.CompilerServices;

public class ListingActivity : Activity
{
    //var
    private int _listedItems;
    private List<string> _prompts;


    public ListingActivity(string name, string description) : base (name, description)
    {
        
    }

    // Start the activity.
    public void Start()
    {
        Initialize(); // welcome user. Get session duration.

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomItem(_prompts)} ---");
        Console.Write("You may begin in...");
        ShowCountdown(5);

        void input()
        {
            // get answers from user
            Console.Write("> ");
            Console.ReadLine();
            _listedItems =+ 1;
            Console.WriteLine();   
        }

        Loop(input);

        Console.WriteLine($"You listed {_listedItems}!");

        ShowClosingMessage();        
    }
}