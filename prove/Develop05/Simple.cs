using System.ComponentModel;

class SimpleGoal : Goal
{
    public SimpleGoal() : base()
    {
        Manager.AddSimpleGoal();
    }

    // load goal
    public SimpleGoal(string title, string description, bool isComplete, int points) : base(title, description, isComplete, points)
    {
        Manager.AddSimpleGoal();
        if (isComplete) Manager.CompleteSimpleGoal();
    }

    public override int CompletionEvent()
    {
        Manager.CompleteSimpleGoal();
        return base.CompletionEvent();
    }

    public override string Stringify()
    {
        string newString = $"{GetName()} (simple)";
        return newString;
    }

    public override void MakeSaveString()
    {
        // Same scheme as what's in the parent class. No additional items needed.
        base.MakeSaveString();
    }

}