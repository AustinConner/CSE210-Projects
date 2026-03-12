using System;

class Program
{
    static void Main(string[] args)
    {
        // Breathing //
        BreathingActivity breathing = new BreathingActivity("Breathing",
        "This activity will help you relax by walking your through breathing in and out slowly. " + 
        "Clear your mind and focus on your breathing.");
        
        breathing.Start();

        // Reflecting //
        List<string> prompts = new();
        string[] pastedPrompts = 
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        prompts.AddRange(pastedPrompts);

        List<string> questions = new();
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
            "How can you keep this experience in mind in the future?"
        };

        questions.AddRange(pastedQuestions);

        ReflectingActivity reflecting = new ReflectingActivity("Reflecting", "This activity will help you reflect on" +
        "times in your life when you have shown strength and resilience. \nThis will help you recognize" + 
        "the power you have and how you can use it in other aspects of your life.", prompts, questions);

        reflecting.Start();
    }
}