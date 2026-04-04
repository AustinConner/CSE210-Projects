class VideoCallInteraction : Interaction
{
    public VideoCallInteraction()
    {
        SetType("Video-Call");

        Console.WriteLine("What platform did your video call take place?");
        string platform = Console.ReadLine();

        base.BasicInteractionInfo();   
    }
}