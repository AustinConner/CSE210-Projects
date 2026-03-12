using System;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;

class Program
{
    static void Main(string[] args)
    {
                               

        // Selection Menu
        void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("           ┌───────────────────────┐");
            Console.WriteLine("┌──────────┤ M I N D F U L N E S S ├─────────┐");
            Console.WriteLine("│          └───────────────────────┘         │");
            Console.WriteLine("│ Main Menu:                                 │");
            Console.WriteLine("╞════════════════════════════════════════════╡");
            Console.WriteLine("│ Select the activity you wish to complete.  │");
            Console.WriteLine("├────────────────────────────────────────────┤");
            Console.WriteLine("│ Options:                                   │");
            Console.WriteLine("│     1. Start breathing activity            │");
            Console.WriteLine("│     2. Start reflecting activity           │");
            Console.WriteLine("│     3. Start listing activity              │");
            Console.WriteLine("│     4. Quit                                │");
            Console.WriteLine("└────────────────────────────────────────────┘");
        }


        // Breathing //
        void Breathing()
        {
            BreathingActivity breathing = new BreathingActivity("Breathing",
            "This activity will help you relax by walking your through breathing in and out slowly. " + 
            "Clear your mind and focus on your breathing.");
            breathing.Start();
        }

        // Reflecting //
        void Reflecting(){
        List<string> reflectingPrompts = new();
        string[] pastedPrompts = 
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you went out of your way to make someone feel included.",
            "Think of a time when you successfully learned a skill that originally felt impossible.",
            "Think of a time when you stayed late or worked extra hard to finish a project you cared about.",
            "Think of a time when you received feedback that was hard to hear but used it to improve significantly.",
            "Think of a time when you admitted you were wrong and worked to make it right.",
            "Think of a time when you listened to someone deeply without interrupting or judging them.",
            "Think of a time when you chose to be kind to someone who was being unkind to you.",
            "Think of a time when you forgave someone and let go of a grudge.",
            "Think of a time when you spent hours practicing something just to get it right.",
            "Think of a time when you resisted a temptation that would have held you back.",
            "Think of a time when you made a significant personal sacrifice for your education or career.",
            "Think of a time when you volunteered your time for a cause you believe in.",
            "Think of a time when you finished a grueling physical or mental challenge.",
            "Think of a time when you kept a secret or protected someone's privacy.",
            "Think of a time when you chose to be patient when everything was going wrong."
        };
        reflectingPrompts.AddRange(pastedPrompts);

        List<string> reflectionQuestions = new();
        string[] pastedQuestions =
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
            "What was the most challenging part of the process, and how did you push through it?",
            "What would you say to someone else who is currently facing a similar challenge?",
            "How does it feel to look back on this version of yourself today?",
            "What specific strength or character trait did you rely on most during this time?",
            "What gave you the courage or motivation to act in that specific moment?",
            "What part of this experience makes you feel the most at peace when you remember it?",
            "How did this moment change the way you see your own potential?",
            "In what ways did this experience surprise you?",
            "What values of yours were being put into practice during this time?",
            "How did your perspective on the situation change from the beginning to the end?",
            "If you could relive one specific minute of that experience, which one would it be and why?"
        };
        reflectionQuestions.AddRange(pastedQuestions);

        ReflectingActivity reflecting = new ReflectingActivity("Reflecting", "This activity will help you reflect on" +
            "times in your life when you have shown strength and resilience. \nThis will help you recognize" + 
            "the power you have and how you can use it in other aspects of your life.", reflectingPrompts, reflectionQuestions);
        
        reflecting.Start();    
        }

        // listing
        void Listing(){
        List<string> listQuestions = new List<string>();
        string[] pastedListQuestions =
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are the different 'small wins' or tasks I’ve completed that gave me a sense of accomplishment?",
            "What are the various parts of my daily routine that consistently make my life easier or more pleasant?",
            "What are the various ways I’ve taken care of my own physical or mental well-being this week?",
            "What are the specific ways my teachers, professors, or mentors have been helpful or inspiring?",
            "What are the various skills I’m developing now that I’m excited to use in my future career?",
            "What are some prayers—large or small—that you have seen answered recently?",
            "Who are the people in your life who make you feel the most understood?",
            "When have you felt a sense of peace or clarity during a busy day?",
            "What are the various things about your current living situation that you are grateful for?",
            "What are the specific ways you have been able to share your knowledge with someone else?",
            "What are the different moments this week where you felt a deep sense of gratitude?",
            "What are the specific ways you have seen your hard work pay off this month?",
            "Who are the people you can always count on when things get difficult?",
            "What are the specific aspects of your current responsibilities that bring you fulfillment?",
            "What are the various small miracles or 'tender mercies' you have witnessed lately?"
        };
        listQuestions.AddRange(pastedListQuestions);

        ListingActivity listing = new ListingActivity("Listing", "This activity will help you reflect on the good things " +
        "in your life by having you list as many things as you can in a certain area.", listQuestions);


        listing.Start();
        }

        // program start
        bool running = true;
        while (running)
        {
            ShowMenu();
            // get user input
            string userInput = Console.ReadLine();
            Console.Clear();

            if (userInput == "1")
            {
                Breathing();
            } 
            else if (userInput == "2")
            {
                Reflecting();   
            }
            else if(userInput == "3")
            {
                Listing();
            } else if (userInput == "4") {
                break;
            } else
            {
                Console.WriteLine($"`{userInput}` is not a valid entry.");
                Activity.ShowSpinner(3);
                Console.WriteLine("Valid choices are: `1`, `2`, `3`, `4`");
                Activity.ShowSpinner(3);
                Console.WriteLine("Please try again with a valid choice.");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
        }

        ShowMenu();
        Console.WriteLine("See you next time!");
    }
}