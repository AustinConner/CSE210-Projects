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
            Console.WriteLine("Are you sure you want to delete this person from relationship manager? You can't undo this!");
            bool yes = InputService.YesNo();
            Console.WriteLine();
            
            if (yes)
            {
                People.RemovePerson(State.GetSelectedPerson());
                State.ClearSelectedPerson();
                State.NextView(ViewName.MainMenu);
            }
            else
            {
                Console.WriteLine("Do you want to select someone else to delete?");
                bool deleteSomeoneElse = InputService.YesNo();
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