using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

public class Activity
{
    private string _name;
    private string _desc;
    private int _duration;
    private static Random _random = new Random();

    /// <summary>
    /// Create an activity.
    /// </summary>
    /// <param name="name">Name of the activity.</param>
    /// <param name="description">Description of the activity.</param>
    public Activity(string name, string description) // constructor
    {
        _name = name;
        _desc = description;
    }

    /// <summary>
    /// Set the session length of the activity.
    /// </summary>
    /// <param name="seconds"></param>
    public void SetDuration(int seconds)
    {
        _duration = seconds;
    }

    /// <summary>
    /// Starts session. Loops a function for the activity duration.
    /// </summary>
    /// <param name="activityToRun">Function to repeat until session is complete.</param>
    public void StartSession(Action actionToLoop)
    {
        Initialize(); // welcome user. Get session duration.

        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine("");

        Stopwatch stopwatch = new Stopwatch(); // timer
        // start timer.
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds <= _duration)
        {
            actionToLoop();
        } 
        stopwatch.Stop();

        Console.WriteLine("");

        // Show message at end of session
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} activity!");

        ShowSpinner(5);
    }

    /// <summary>
    /// Loops a function for the duration of the activity.
    /// </summary>
    /// <param name="actionToLoop">Function you want to loop</param>
    public void Loop(Action actionToLoop)
    {
        Stopwatch stopwatch = new Stopwatch(); // timer
        // start timer.
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds <= _duration)
        {
            actionToLoop();
        } 
        
        stopwatch.Stop();
    }

    /// <summary>
    /// Display a countdown timer.
    /// </summary>
    /// <param name="seconds">Seconds to countdown from</param>
    public void ShowCountdown(int seconds)
    {
        Console.CursorVisible = false;

        for (int i = seconds; i > 0; i--)
        {
            string secondsLeft = i.ToString();
            Console.Write($"{i}");
            Thread.Sleep(1000); // 1 second.

            for (int number = 0; number < secondsLeft.Length; number++) {
            Console.Write("\b \b");
            };
        }
        
        Console.CursorVisible = true;
    }

    /// <summary>
    /// Display loading spinner.
    /// </summary>
    /// <param name="seconds">Seconds the spinner is shown.</param>
    static public void ShowSpinner(int seconds)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string glpyh = "⠋⠙⠹⠸⢰⣰⣠⣄⣆⡆⠇⠏";
        // https://antofthy.gitlab.io/info/ascii/Spinners.txt - It's the 'Braille Circle Worm'
        
        Console.CursorVisible = false;

        Stopwatch stopwatch = new Stopwatch(); // timer
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds <= seconds) {
            foreach (char i in glpyh)
            {
                if (stopwatch.Elapsed.TotalSeconds >= seconds) break;
                
                Console.Write($"{i}");
                Thread.Sleep(100); // 1 second.
                Console.Write("\b");
            }
       }

       Console.Write(" ");
       Console.CursorVisible = true;
    }

    /// <summary> 
    /// Welcome user to activity. Get activity duration.
    /// </summary>
    public void Initialize()
    {
        Console.Clear();

        // welcome the user
        string greet = $"Welcome to the {_name} Activity! \n";
        string description = _desc;
        Console.WriteLine(greet);
        Console.WriteLine(description);
        
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        int duration = Convert.ToInt32(Console.ReadLine());
        
        SetDuration(duration);

        Console.Clear();

        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine("");
    }

    /// <summary>
    /// Get a random item from a list.
    /// </summary>
    /// <typeparam name="T">Lists</typeparam>
    /// <param name="list">Your list.</param>
    /// <returns></returns>
    public string GetRandomItem<T>(List<T> list) 
    {
        int listLength = list.Count();
        int index = _random.Next(0, listLength);
        string item = list[index].ToString();
        return item;
    }

    /// <summary>
    /// Ending message after user completes activity.
    /// </summary>
    public void ShowClosingMessage()
    {
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} activity!");
        ShowSpinner(5);
    }
}