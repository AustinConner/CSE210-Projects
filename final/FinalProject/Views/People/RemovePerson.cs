using System.Numerics;

class RemovePerson : View
{
    public override ViewName Show()
    {

        Header("Delete Person");

        // check if there's someone currently selected
        if (State.GetSelectedPerson() == null)
        {
            Console.WriteLine("Select the person you wish to remove.");
            State.NextView(ViewName.RemovePerson);
            return ViewName.SelectPerson;
        } else
        {
            Console.WriteLine($"{State.GetSelectedPerson().GetName()} > {State.GetSelectedPerson().GetRelationship()}");
            bool yes = InputService.YesNo("Are you sure you want to delete this person from relationship manager? You can't undo this!");
            Console.WriteLine();

            if (yes)
            {
                People.RemovePerson(State.GetSelectedPerson());
                State.ClearSelectedPerson();
                State.NextView(ViewName.MainMenu);
            }
            else
            {
                bool deleteSomeoneElse = InputService.YesNo("Do you want to select someone else to delete?");
                if (deleteSomeoneElse)
                {
                    State.ClearSelectedPerson();
                    State.NextView(ViewName.RemovePerson);
                    return ViewName.SelectPerson;
                } else
                {
                    State.ClearSelectedPerson();
                    State.NextView(ViewName.MainMenu);
                }
            }
        }

        return State.GetNextView();
    }
}