using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

public class BreathingActivity : Activity
{
    /// <summary>
    /// Create a 'Breathing' activity.
    /// </summary>
    /// <param name="name">Name of the breathing activity.</param>
    /// <param name="description">Description of the breathing activity.</param>
    public BreathingActivity(string name, string description) : base(name, description)
    {
        // just passes variables through to the "Activity" class constructor
    }

    /// <summary>
    /// Start the Breathing Activity.
    /// </summary>
    public void Start()
    {
        Initialize();

        void Action()
        {
            Console.Write("Breathe in....");
            ShowCountdown(5);
            Console.WriteLine();

            Console.Write("Breathe out...");
            ShowCountdown(3);
            Console.WriteLine("\n");
        }

        Loop(Action);
        
        ShowClosingMessage();
    }

}