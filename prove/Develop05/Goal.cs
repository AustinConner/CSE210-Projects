using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices.Swift;
using Microsoft.VisualBasic;

public class Goal
{
    // Title of the goal
    private string _title;

    // Goal description
    private string _description;

    // How many points when completing goal
    private int _points;

    // Is the goal complete?
    private bool _isComplete;

    // String that gets saved and imported later
    string _saveString;

    // Create a goal
    public Goal()
    {
        // Get the name of the goal from the user.
        _title = Input.ReadString("What is the name of your goal? ");

        // Get short description of the goal
        _description = Input.ReadString("What is a short description of this goal? ");

        // Get total number of points are avaliable for this goal
        _points = Input.ReadInt("How many points are associated with this goal? ");

    }

    // load saved goal
    public Goal(string title, string description, bool isComplete, int points)
    {
        _title = title;
        _description = description;
        _isComplete = isComplete;
        _points = points;
    }

    public void SetComplete()
    {
        _isComplete = true;
    }

    public int GetPoints()
    {
        return _points;
    }

    public bool GetCompletionStatus()
    {
        return _isComplete;
    }

    /// <summary>
    /// Run when user is done with event to award them points.
    /// </summary>
    public virtual int CompletionEvent()
    {
        // Mark the goal as complete
        _isComplete = true;

        Manager.AddRecordAction();

        // Award the user their points.
        return _points;
    }

    public string GetName()
    {
        return _title;
    }

    public string GetDescription()
    {
        return _description;
    }

    public virtual string Stringify()
    {
        string newString = $"{GetName()}";
        return newString;
    }

    // Convert goal to a string so thatConsole.ReadLine(); it can be saved and loaded later.
    public virtual void MakeSaveString()
    {
        // Returned goals should follow this scheme: GoalType>Title>Description>Status>Points
        // Other goals can add on to this, but they all with share this.
        // get the goal type:
        string goalType = this.GetType().ToString();

        // Get the goal title
        string goalTitle = _title;

        // Get description
        string goalDescription = _description;

        // Get completion status
        string completionStatus = _isComplete.ToString();

        // Get points
        string goalPoints = _points.ToString();

        // construct save string
        string saveString = $"{goalType}>{goalTitle}>{goalDescription}>{completionStatus}>{goalPoints}";

        _saveString = saveString;
    }

    // Override an existing SaveString
    public void OverrideSaveString(string newSaveString)
    {
        _saveString = newSaveString;
    }


    // Get the goals save string
    public string GetSaveString()
    {
        return _saveString;
    }
}