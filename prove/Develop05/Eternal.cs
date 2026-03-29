class EternalGoal : Goal
{   
    // Track how many times the goal has been completed.
    int _totalCompletions;

    public EternalGoal() : base()
    {
        Manager.AddEternalGoal();
    }

    // load goal
    public EternalGoal(string title, string description, bool isComplete, int points,
    int totalCompletions) :
    base(title, description, isComplete, points)
    {
        _totalCompletions = totalCompletions;
        Manager.AddEternalGoal();
        Manager.CompleteEternalGoal(totalCompletions);
    }

    public override int CompletionEvent()
    {
        _totalCompletions += 1;
        Manager.AddRecordAction();
        Manager.CompleteEternalGoal();
        return GetPoints();
    }

    public override string Stringify()
    {
        string newString = $"{GetName()} (eternal)";
        return newString;
    }

    public override void MakeSaveString()
    {
        // SaveString scheme: defaultSaveString>completions
        base.MakeSaveString();

        string defaultSaveString = this.GetSaveString();

        string completions = _totalCompletions.ToString();

        string newSaveString = $"{defaultSaveString}>{completions}";

        OverrideSaveString(newSaveString);
    }

}