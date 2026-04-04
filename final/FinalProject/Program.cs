using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the router to route views
        Router myRouter = new();
        myRouter.Run();
    }
}