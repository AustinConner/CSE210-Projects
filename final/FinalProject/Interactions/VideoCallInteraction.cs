class VideoCallInteraction : Interaction
{
    public void Add()
    {
        SetType("Video Call");

        string platform = InputService.GetString("What platform did your video call take place on? ");
        SetLocation(platform);

        BasicInteractionInfo();
    }
}
