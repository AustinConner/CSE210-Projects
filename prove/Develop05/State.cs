using System.Collections;
using System.Diagnostics.Contracts;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;

static class State
{

    private static void Header()
    {
        Console.Clear();
        Tui.SingleLineColor("Session Management", ConsoleColor.DarkBlue, ConsoleColor.White);
        Console.WriteLine();
    }    
    // Save goals 
    public static void Save()
    {
        Header();

        // get the goal list
        List<Goal> goals = Manager.GetGoals();

        // if the list is emtpy, do nothing.
        if (goals.Count == 0)
        {
            Tui.SingleLineColor($" There are no goals to save. Create some goals first. ", ConsoleColor.DarkRed, ConsoleColor.White);
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        Console.Write("What would you like to name your file? ");
        string filename = Console.ReadLine();
        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // get stats
            int totalPoints = Manager.GetPoints();
            int totalActions = Manager.GetTotalActions();
            int totalGoals = Manager.GetGoals().Count;
            int simpleGoalCount = Manager.GetTotalSimpleGoals();
            int checklistGoalCount = Manager.GetTotalChecklistGoals();
            int eternalGoalCount = Manager.GetTotalEternalGoals();
            int completeSimpleGoal = Manager.GetCompletedSimpleGoals();
            int completeChecklistGoal = Manager.GetCompletedChecklistGoals();
            int CompleteEternalGoal = Manager.GetCompletedEternalGoals();

            string stats = string.Join(">",
            "Stats",
            totalPoints,
            totalActions,
            totalGoals,
            simpleGoalCount,
            checklistGoalCount,
            eternalGoalCount,
            completeSimpleGoal,
            completeChecklistGoal,
            CompleteEternalGoal
            );

            // save stats
            outputFile.WriteLine(stats);

            // Loop through each goal
            foreach (Goal goal in goals)
            {
                // make the saveString for the goal
                goal.MakeSaveString();

                // get the newly created string
                string saveString = goal.GetSaveString();

                outputFile.WriteLine(saveString);
            }
        }


    }

    // Load saved goals
    public static void Load()
    {
        Header();

        Console.Write("What is name of your saved goals file? ");
        string filename = Console.ReadLine();

        // reset all state before loading so we don't double-count
        Manager.Reset();

        // load the file that the user specified
        string[] lines = System.IO.File.ReadAllLines(filename);

        // loop through it line for line
        foreach (string line in lines)
        {
            string[] parts = line.Split(">");

            // all goal default scheme: GoalType>Title>Description>Status>Points
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                {
                    string title = parts[1];
                    string description = parts[2];
                    bool status = Convert.ToBoolean(parts[3]);
                    int points = Convert.ToInt32(parts[4]);

                    SimpleGoal mySimpleGoal = new SimpleGoal(title, description, status, points);
                    Manager.AddGoalToList(mySimpleGoal);
                    break;
                }

                case "EternalGoal":
                {
                    string title = parts[1];
                    string description = parts[2];
                    bool status = Convert.ToBoolean(parts[3]);
                    int points = Convert.ToInt32(parts[4]);
                    int completions = Convert.ToInt32(parts[5]);

                    EternalGoal myEternalGoal = new EternalGoal(title, description, status, points, completions);
                    Manager.AddGoalToList(myEternalGoal);
                    break;
                }

                case "ChecklistGoal":
                {
                    string title = parts[1];
                    string description = parts[2];
                    bool status = Convert.ToBoolean(parts[3]);
                    int points = Convert.ToInt32(parts[4]);
                    int totalIterations = Convert.ToInt32(parts[5]);
                    int iterations = Convert.ToInt32(parts[6]);
                    int bonus = Convert.ToInt32(parts[7]);

                    ChecklistGoal myChecklistGoal = new ChecklistGoal(title, description, status, points, totalIterations, iterations, bonus);
                    Manager.AddGoalToList(myChecklistGoal);
                    break;
                }

                case "Stats":
                {
                    int totalPoints = Convert.ToInt32(parts[1]);
                    int totalActions = Convert.ToInt32(parts[2]);

                    Manager.AddPoints(totalPoints);
                    Manager.AddRecordAction(totalActions);
                    break;
                }
            }

            

        }

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
    }
}