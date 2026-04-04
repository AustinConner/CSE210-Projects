using System;

class Program
{
    static void Main(string[] args)
    {
        // Make a place to actually store people
        People myPeople = new();

        // Create the router to route views
        Router myRouter = new();
        myRouter.Run();
    }
}