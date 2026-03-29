using System.Linq.Expressions;
using System.Xml.Serialization;
using System.Diagnostics;
using System.IO.Compression;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

static class Tui
{
    // Show loading spinner.
    public static void ShowSpinner(int seconds)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string glpyh = "⠋⠙⠹⠸⢰⣰⣠⣄⣆⡆⠇⠏";
        // ⠋⠙⠹⠸⢰⣰⣠⣄⣆⡆⠇⠏
        // https://antofthy.gitlab.io/info/ascii/Spinners.txt - It's the 'Braille Circle Worm'
        
        Console.CursorVisible = false;

        Stopwatch stopwatch = new Stopwatch(); // timer
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds <= seconds) {
            foreach (char i in glpyh)
            {
                if (stopwatch.Elapsed.TotalSeconds >= seconds) break;
                
                Console.Write($"{i}");
                Thread.Sleep(150);
                Console.Write("\b\b");
            }
       }

       Console.Write(" ");
       Console.CursorVisible = true;
       Console.WriteLine();
    }

    // Programming starting heading.
    private static void Heading(string text, int characterWidth)
    {
        Console.Clear();

        Console.ResetColor();
        // Specify each side of the box for the heading.
        char top = '─';
        char bottom = '─';
        char left = '│';
        char right = '│';
        char topLeft = '╭';
        char bottomLeft = '╰';
        char topRight = '╮';
        char bottomRight = '╯';

        // Calculate padding to center the text inside the box
        int contentWidth = characterWidth - 2;
        int leftPadding = (contentWidth - text.Length) / 2;
        int rightPadding = contentWidth - text.Length - leftPadding;

        // Build reusable strings for each part of the box
        string leftSpace = new string(' ', leftPadding);
        string rightSpace = new string(' ', rightPadding);
        string horizontalLine = new string(top, contentWidth);
        string emptyRow = new string(' ', contentWidth);

        // Display the box with white background and black text
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"{topLeft}{horizontalLine}{topRight}"); 
        Console.WriteLine($"{left}{emptyRow}{right}");            
        Console.WriteLine($"{left}{leftSpace}{text}{rightSpace}{right}"); 
        Console.WriteLine($"{left}{emptyRow}{right}");            
        Console.WriteLine($"{bottomLeft}{horizontalLine}{bottomRight}");
        Console.ResetColor();
    }

    // Message telling someone how many points they earned
    public static void PointsCharm(string text)
    {
        string topBottom = new(' ', text.Length);
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($" {topBottom} ");
        Console.WriteLine($" {text} ");
        Console.WriteLine($" {topBottom} ");
        Console.ResetColor();
        Console.WriteLine();
        SingleLineColor($"You now have {Manager.GetPoints()} points.", ConsoleColor.DarkBlue, ConsoleColor.White);
        ShowSpinner(3);

    }
    
    // Displays the user current points in the main menu if they have any
    private static void CurrentPoints()
    {
        int points = Manager.GetPoints();

        if (points == 0)
        {
            return;
        }
        else
        {
            SingleLineColor($"Points: {points}", ConsoleColor.DarkBlue, ConsoleColor.White);
        }
    }

    // Message telling someone that a goal was created
    public static void GoalCreated()
    {
        Console.WriteLine();
        SingleLineColor("Goal Created.", ConsoleColor.DarkGreen, ConsoleColor.White);
        ShowSpinner(3);
        Console.Write(" ");
        Console.WriteLine();
    }

    // Create Goals
    // Create a Simple Goal
    private static void MakeSimpleGoal()
    {
        Console.Clear();
        SingleLineColor("Simple Goal", ConsoleColor.DarkGray, ConsoleColor.White);
        SimpleGoal mySimpleGoal = new();
        GoalCreated();
        Manager.AddGoalToList(mySimpleGoal);
    }

    // Create a Eternal Goal.
    private static void MakeEternalGoal()
    {
        Console.Clear();
        SingleLineColor("Eternal Goal", ConsoleColor.Yellow, ConsoleColor.Black);
        EternalGoal myEternalGoal = new();
        GoalCreated();
        Manager.AddGoalToList(myEternalGoal);
    }

    
    // Create a Checklist Goal.
    private static void MakeChecklisGoal()
    {
        Console.Clear();
        SingleLineColor("Checklist Goal", ConsoleColor.Cyan, ConsoleColor.White);
        ChecklistGoal myChecklistGoal = new();
        GoalCreated();
        Manager.AddGoalToList(myChecklistGoal);
    }

    // Format a single line of text.
    public static void SingleLineColor(string text, 
    ConsoleColor backgroundColor = ConsoleColor.DarkGreen, 
    ConsoleColor foregroundColor = ConsoleColor.White)
    {
        Console.BackgroundColor = backgroundColor;
        Console.ForegroundColor = foregroundColor;
        Console.Write($" {text} ");
        Console.ResetColor();
        Console.WriteLine();
    }

    // =============
    // = Main Menu =
    // =============
    public static bool MainMenu()
    {
        Console.Clear();

        // show heading
        Heading("Eternal Quest Program", 82);
        CurrentPoints();
        Console.WriteLine();


        // show choices
        Console.WriteLine("1. Create New Goal.");
        Console.WriteLine("2. List Goals.");
        Console.WriteLine("3. Save Goals.");
        Console.WriteLine("4. Load Goals.");
        Console.WriteLine("5. Record Event.");
        Console.WriteLine("6. Stats.");
        Console.WriteLine("7. Quit.");

        Console.WriteLine("");

        // get user input
        int choice = Input.ReadIntInRange("Enter your selection: ", 1, 7);
        switch (choice)
        {
            case 1: // create goal
            NewGoalMenu();
            break;

            case 2: // list goals
            GetGoals();
            break;

            case 3: // save goals
            State.Save();
            break;

            case 4: // load goals
            State.Load();
            break;

            case 5: // record event
            RecordGoal();
            break;

            case 6: // show stats
            GetStats();
            break;

            case 7: // quit
            return false;
        }

        return true;

    }

        // Submenu
        // ~ NewGoal
        private static void NewGoalMenu()
    {
        Console.Clear();
        SingleLineColor("Create New Goal");
        Console.WriteLine("Goal types:");
        Console.WriteLine("1. Simple Goal.");
        Console.WriteLine("2. Eternal Goal.");
        Console.WriteLine("3. Checklist Goal");

        int choice = Input.ReadIntInRange("Which goal would you like to create? ", 1, 3);

        switch (choice)
        {
            case 1: // simple goal
            MakeSimpleGoal();
            break;

            case 2: // eternal goal
            MakeEternalGoal();
            break;

            case 3: // checklist goal
            MakeChecklisGoal();
            break;

        }
    }

    private static void RecordGoal()
    {   
        Console.Clear();
        SingleLineColor("Record a Goal", ConsoleColor.DarkBlue, ConsoleColor.White);
        if  (PrintGoals() == false)
        {
            Console.WriteLine("You have no goals.");
            ShowSpinner(3);
            return;
        }
        Console.WriteLine("");
        int selection;
        while (true)
        {
            selection = Input.ReadIntInRange("What goal would you like to record an event for? ", 1, Manager.GetGoals().Count);

            Goal selected = Manager.GetGoals()[selection - 1];
            if (selected.GetCompletionStatus())
            {
                SingleLineColor("That goal is already complete. Please choose another.", ConsoleColor.DarkRed, ConsoleColor.White);
                Console.WriteLine();
            }
            else
            {
                break;
            }
        }

        Manager.MarkComplete(selection);
    }

    private static bool PrintGoals()
    {
        // Check if goal list is empty.
        if (Manager.GetGoals().Count == 0)
        {
            return false;
        }

        int counter = 1;
        foreach (Goal userGoal in Manager.GetGoals())
        {   
            string checkbox;
            if (userGoal.GetCompletionStatus())
            {
                checkbox = "[✔]";
            } else
            {
                checkbox = "[ ]";
            }
            string goalNameType = userGoal.Stringify();
            string goalDescription = userGoal.GetDescription();
            Console.WriteLine($"{checkbox} {counter}. {goalNameType}");
            Console.WriteLine($"       > {goalDescription}");
            Console.WriteLine("");
            counter += 1;
        }

        return true;
    }

    public static void GetGoals()
    {
        Console.Clear();
        SingleLineColor("Created Goals", ConsoleColor.DarkBlue, ConsoleColor.White);
        if (PrintGoals() != true)
        {
            Console.WriteLine("You have no goals.");
        }
        Console.WriteLine();
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
    }

    private static void GetStats()
    {
        Console.Clear();
        SingleLineColor("Statistics", ConsoleColor.DarkMagenta);
        int points = Manager.GetPoints();
        int totalActions = Manager.GetTotalActions();
        int totalGoals = Manager.GetGoals().Count;

        SingleLineColor($"Total Points: {points}", ConsoleColor.DarkBlue, ConsoleColor.White);
        SingleLineColor($"Total Actions: {totalActions}", ConsoleColor.DarkGreen, ConsoleColor.White);
        Console.WriteLine();
        SingleLineColor($"Total Goals: {totalGoals}", ConsoleColor.DarkGray, ConsoleColor.White);
        SingleLineColor($"  Simple Goals: {Manager.GetTotalSimpleGoals()} ({Manager.GetCompletedSimpleGoals()} completed)", ConsoleColor.DarkGray, ConsoleColor.White);
        SingleLineColor($"  Checklist Goals: {Manager.GetTotalChecklistGoals()} ({Manager.GetCompletedChecklistGoals()} completed)", ConsoleColor.Cyan, ConsoleColor.Black);
        SingleLineColor($"  Eternal Goals: {Manager.GetTotalEternalGoals()} ({Manager.GetCompletedEternalGoals()} recorded)", ConsoleColor.Yellow, ConsoleColor.Black);

        Console.WriteLine();
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

    }
}