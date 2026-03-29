using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.IO;

static class Manager
{
    // Hold all the goals.
    private static List<Goal> _goalList = new();

    // Earned points.
    private static int _totalPoints;

    // Total goal actions
    private static int _totalGoalActions;

    // Goal type counts
    private static int _totalSimpleGoals;
    private static int _totalChecklistGoals;
    private static int _totalEternalGoals;

    // Goal type completions
    private static int _completedSimpleGoals;
    private static int _completedChecklistGoals;
    private static int _completedEternalGoals;

    // Methods //
    // Reset all state (used before loading a file)
    public static void Reset()
    {
        _goalList = new();
        _totalPoints = 0;
        _totalGoalActions = 0;
        _totalSimpleGoals = 0;
        _totalChecklistGoals = 0;
        _totalEternalGoals = 0;
        _completedSimpleGoals = 0;
        _completedChecklistGoals = 0;
        _completedEternalGoals = 0;
    }

    // Add user's goal to list.
    public static void AddGoalToList(Goal userGoal)
    {
        _goalList.Add(userGoal);
    }

    // Keep track of points earned from completing goals.
    public static void AddPoints(int numberOfPoints)
    {
        _totalPoints += numberOfPoints;
    }

    public static void AddRecordAction(int amt = 1)
    {
        _totalGoalActions += amt;
    }

    public static int GetTotalActions()
    {
        return _totalGoalActions;
    }

    public static void AddSimpleGoal(int amt = 1)
    { 
        _totalSimpleGoals += amt;
    }
    public static void AddChecklistGoal(int amt = 1)
    { 
        _totalChecklistGoals += amt;
    }
    public static void AddEternalGoal(int amt = 1)
    { 
        _totalEternalGoals += amt;
    }

    public static int GetTotalSimpleGoals()
    {
        return _totalSimpleGoals; 
    }
    public static int GetTotalChecklistGoals()
    {
        return _totalChecklistGoals; 
    }
    public static int GetTotalEternalGoals()
    {
        return _totalEternalGoals; 
    }

    public static void CompleteSimpleGoal(int amt = 1)
    {
        _completedSimpleGoals += amt; 
    }
    public static void CompleteChecklistGoal(int amt = 1)
    {
        _completedChecklistGoals += amt; 
    }
    public static void CompleteEternalGoal(int amt = 1)
    {
        _completedEternalGoals += amt; 
    }

    public static int GetCompletedSimpleGoals()
    {
        return _completedSimpleGoals; 
    }
    public static int GetCompletedChecklistGoals()
    {
        return _completedChecklistGoals; 
    }
    public static int GetCompletedEternalGoals()
    {
        return _completedEternalGoals; 
    }

    public static int GetPoints()
    {
        return _totalPoints;
    }

    // Get goals from list
    public static List<Goal> GetGoals()
    {
        return _goalList;
    }

    // Mark specified goal as 'complete'.
    public static void MarkComplete(int goalNumber)
    {
        int goalSelection = goalNumber-1; // start counting from 0. Delete one to account for that.
        List<Goal> goalList = GetGoals();
        Goal selectedGoal = goalList[goalSelection];
        
        if (selectedGoal.GetCompletionStatus())
        {
            Tui.SingleLineColor("This goal is already complete!", ConsoleColor.DarkRed, ConsoleColor.White);
            Tui.ShowSpinner(2);
            return;
        }

        int response = selectedGoal.CompletionEvent();
        string message = $"Congratulations! You just earned {response} points!";
        AddPoints(response);
        Tui.PointsCharm(message);
    }
}