public class ReflectingActivity : Activity
{
    //var
    private List<string> _prompts;
    private List<string> _usedPrompts;
    private List<string> _questions;

    //methods

    public ReflectingActivity(string name, string description, List<string> prompts, List<string> questions) : base(name, description)
    {
        _prompts = prompts;
        _questions = questions;
    } 

    /// <summary>
    /// Start the Reflecting Activity.
    /// </summary>
    public void Start()
    {
        Initialize();

        void Action()
        {
            Console.WriteLine("Consider the following prompt: \n");

            string prompt = GetRandomItem(_prompts);
            Console.WriteLine($"---{prompt}---\n");

            Console.WriteLine("When you have something in mind, press enter to continue...");
            Console.ReadLine();
            Console.WriteLine("Now, take some time to ponder each of the following questions as they relate to this experience...\n");

            Console.Write("You may begin in...");
            ShowCountdown(5);
            Console.WriteLine();

            Console.Clear();

            Console.Write($"> {GetRandomItem(_questions)} ");
            ShowSpinner(10);

            Console.WriteLine("");
            Console.Write($"> {GetRandomItem(_questions)} ");
            ShowSpinner(10);

            Console.WriteLine("\n\nIt's good to take the time to reflect. If today isn't your day, tommorow will be.");
            ShowSpinner(5);
        }

        Loop(Action);

        ShowClosingMessage();
    }
}