class VideoCallInteraction : Interaction
{
    public void Add()
    {
        SetType("Video Call");

        Console.WriteLine("What platform did your video call take place on?");
        string platform = Console.ReadLine();
        SetLocation(platform);

        BasicInteractionInfo();
    }
}
