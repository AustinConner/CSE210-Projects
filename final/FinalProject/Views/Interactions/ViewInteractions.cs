class ViewInteractions : View
{
    public override ViewName Show()
    {
        if (State.GetSelectedPerson() == null)
        {
            State.NextView(ViewName.ViewInteractions);
            return ViewName.SelectPerson;   
        }

        Person person = State.GetSelectedPerson();
        Header($"Interactions with {person.GetName()}");

        List<Interaction> interactions = person.GetInteractions();

        if (interactions.Count == 0)
        {
            Console.WriteLine("No interactions logged yet.");
            return ViewName.PersonDetails;
        }
        else
        {
            int counter = 1;
            foreach (Interaction interaction in interactions)
            {
                Console.Write($"{counter}. ");
                interaction.Display();
                Console.WriteLine();
                counter++;
            }
        }

        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
        State.ClearSelectedPerson();

        return ViewName.PersonDetails;
    }
}
