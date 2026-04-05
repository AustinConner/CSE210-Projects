class LogInteraction : View
{
    public override ViewName Show()
    {
        if (State.GetSelectedPerson() == null)
        {
            State.NextView(ViewName.LogInteraction);
            return ViewName.SelectPerson;
        }

        Person person = State.GetSelectedPerson();
        
        Header($"Log Interaction with {person.GetName()}");

        Console.WriteLine("What type of interaction was this?");
        Console.WriteLine("1. In-Person");
        Console.WriteLine("2. Video Call");
        Console.WriteLine("3. Text");

        int choice = InputService.GetMenuChoice(1, 3);

        Interaction interaction;

        switch (choice)
        {
            case 1:
                InPersonInteraction inPerson = new();
                inPerson.Add();
                interaction = inPerson;
                break;

            case 2:
                VideoCallInteraction videoCall = new();
                videoCall.Add();
                interaction = videoCall;
                break;

            default:
                TextInteraction text = new();
                text.Add();
                interaction = text;
                break;
        }

        person.AddInteraction(interaction);

        return ViewName.PersonDetails;
    }
}
