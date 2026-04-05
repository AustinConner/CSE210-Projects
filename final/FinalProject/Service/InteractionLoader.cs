/// <summary>
/// Creates Interaction objects from saved data.
/// </summary>
static class InteractionLoader
{
    public static Interaction Create(string type, string date, string location, string topic, string futurePlans)
    {
        Interaction interaction;

        switch (type)
        {
            case "In-Person":
                interaction = new InPersonInteraction();
                break;
            case "Video Call":
                interaction = new VideoCallInteraction();
                break;
            default:
                interaction = new TextInteraction();
                break;
        }

        interaction.Load(type, date, location, topic, futurePlans);
        return interaction;
    }
}
