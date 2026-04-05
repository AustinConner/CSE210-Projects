using System.Numerics;

class SelectPerson : View
{
    public override ViewName Show()
    {
        People.GetPeopleNumbered();
        int total = People.GetCount();

        int selection = 1;
        if (total > 1)
        {
            selection = InputService.GetMenuChoice(1, total);
        }

        Person selectedPerson = People.GetPeopleAsList()[selection - 1];
        State.SelectPerson(selectedPerson);

        // Next view that needs to be navigated to.
        return State.GetNextView();
    }
}