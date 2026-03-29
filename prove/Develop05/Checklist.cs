using System.ComponentModel;

class ChecklistGoal : Goal
{   
    // total bonus points possible after fully completing goal.
    int _bonusAmount; 

    // total times to complete the goal
    int _iterations;

    // total times the goal has been ran.
    int _totalIterations;

    // specify the amount of points to award
    int _awdAmt;

    // Create the goal
    public ChecklistGoal() : base() {
        // total runs
        _iterations = Input.ReadInt("How many times should this goal be completed before you win the bonus? ");

        // bonus for completing
        _bonusAmount = Input.ReadInt("What is the bonus for accomplishing this goal? ");

        Manager.AddChecklistGoal();
    }

    // load goal
    public ChecklistGoal(string title, string description, bool isComplete, int points,
    int totalItterations, int itterations, int bonus) :
    base(title, description, isComplete, points)
    {
        _totalIterations = totalItterations;
        _iterations = itterations;
        _bonusAmount = bonus;
        Manager.AddChecklistGoal();
        if (isComplete) Manager.CompleteChecklistGoal();
    }

    public override int CompletionEvent()
    {  
        _awdAmt = base.GetPoints();
        Console.WriteLine(_awdAmt);

        // mark 1 run of the checklist
       _totalIterations += 1;

       // figure out if bonus should be awarded
       if(_iterations != _totalIterations)
        {
            // points returned to caller to be added
        } else
        {
            SetComplete();
            _awdAmt += _bonusAmount;
            Manager.CompleteChecklistGoal();
            Console.WriteLine("You've completed this goal!");
        }

        Manager.AddRecordAction();

        return _awdAmt;
    }

    public override string Stringify()
    {
        string newString = $"{GetName()} (Checklist) {_totalIterations}/{_iterations}";
        return newString; 
    }


    public override void MakeSaveString()
    {
        // Scheme: base>totalItterantions>itterations>bonus
        base.MakeSaveString();
        string defaultSaveString = this.GetSaveString();
        string totalItterations = _totalIterations.ToString();
        string itterations = _iterations.ToString();
        string bonus = _bonusAmount.ToString();

        string newSaveString = $"{defaultSaveString}>{totalItterations}>{itterations}>{bonus}";

        OverrideSaveString(newSaveString);
    }

}