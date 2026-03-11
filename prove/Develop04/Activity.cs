using System.Diagnostics.Contracts;

public class Activity
{
    private string _name;
    private string _desc;
    private int _duration;

    // methods
    public Activity(string name, string description) // constructor
    {
        _name = name;
        _desc = description;
    }

    public void SetDuration(int seconds)
    {
        _duration = seconds;
    }

    public void ShowCountdownTimer(int seconds)
    {
        // timer that shows a countdown at the end of a line.
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{seconds}");
            Thread.Sleep(1000); // 1 second.
            Console.Write("\b \b");
        } 
        
    }

    public void ShowLoadAnimation()
    {
        
    }

    public void Initialize()
    {
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
    }

    public string GetClosingMsg(string activityName)
    {
        // activity name is already in the class - why pass it through again?
        return "test";
    }
}