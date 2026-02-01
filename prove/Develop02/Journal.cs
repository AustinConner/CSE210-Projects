using System.Configuration.Assemblies;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.CompilerServices;
public class Journal
{
    public List<string> _journalEntries = new List<string>();

    public string GetPrompt() // Select a random prompt for the entry.
    {
        List<string> prompts =
        [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What are you grateful for today?",
            "How did you see the Lord's hand in your life today?",
            "What is your biggest goal for tomorrow?",
            "How do you feel in this moment?",
            "What is a spiritual prompting you acted on recently?",
            "What is a habit you want to start?",
            "What is a scripture that stood out to you recently?",
            "Who has influenced you the most?",
            "What does your ideal life look like in five years?",
            "What is a lesson you learned recently?",
            "How are you trying to be more like the Savior?",
            "What is your favorite memory from childhood?",
            "How do you handle stress?",
            "What does home mean to you?",
            "What is the best piece of advice you have received?",
            "What did you learn from your scripture study today?",
            "What is one thing you want to accomplish today?",
            "What is your favorite book and why?",
            "How do you define happiness?",
            "What is a tender mercy you experienced this week?",
            "What is a challenge you are currently facing?",
            "What is your favorite hobby?",
            "Describe your dream job.",
            "How do you practice self-care?",
            "What is a quality you admire in others?",
            "What is your favorite Conference talk and why?",
            "What is the most beautiful thing you saw today?",
            "If you could have dinner with anyone who would it be?",
            "What does a productive day look like to you?",
            "How has prayer helped you recently?",
            "What is a mistake you made and what did it teach you?",
            "What is your favorite song right now?",
            "What is one thing you can do to be kinder to yourself?",
            "What are your top three priorities right now?",
            "How can you better minister to those around you?",
            "Describe a time you felt really brave.",
            "What is your favorite way to exercise?",
            "What is a talent you wish you had?",
            "What is the last thing that made you laugh out loud?",
            "How do you want to be remembered?",
            "What is your favorite comfort food?",
            "What is a goal you achieved recently?",
            "What brings you peace in the gospel?",
            "Write about a difficult choice you had to make.",
            "What is your favorite time of day?",
            "What is one thing you wish people knew about you?",
            "What are you most passionate about?",
            "How do you stay motivated?",
            "What is your favorite movie?",
            "What is a boundary you need to set?",
            "Describe your favorite holiday.",
            "What is a risk you are glad you took?",
            "What does friendship mean to you?",
            "What is your favorite way to relax?",
            "What is a dream you have never told anyone?",
            "What is something you take for granted?",
            "How have you grown spiritually in the last year?",
            "What is your favorite quote?",
            "What is one thing you want to say no to?",
            "What is one thing you want to say yes to?",
            "What is your favorite way to spend a weekend?",
            "What is a skill you are currently working on?",
            "What is the most interesting thing you learned today?",
            "How do you deal with failure?",
            "What is your favorite scent?",
            "What is a compliment you received that stuck with you?",
            "What is your favorite thing about your home?",
            "How are you preparing for the Sabbath?",
            "What is a project you want to start?",
            "What is your favorite piece of clothing?",
            "How do you recharge your energy?",
            "What is a memory that always makes you smile?",
            "What is your biggest pet peeve?",
            "What does balance look like in your life?",
            "What is a letter you would write to your younger self?",
            "What is a letter you would write to your future self?",
            "What is something you need to let go of?",
            "What is your favorite way to help others?",
            "What is a topic you could talk about for hours?",
            "What is your favorite outdoor activity?",
            "What is a small win from today?",
            "How do you handle criticism?",
            "What is your favorite way to express creativity?",
            "What is a destination on your bucket list?",
            "What is something you have changed your mind about?",
            "What is your favorite family tradition?",
            "What is one thing you are excited for next month?",
            "How do you want to feel at the end of the day?",
            "What is a personality trait you are proud of?",
            "What is your favorite way to start the morning?",
            "What is a difficult conversation you need to have?",
            "What is your favorite way to spend alone time?",
            "What is a gift you have received that meant a lot?",
            "What is a belief that guides your life?",
            "How do you define inner peace?",
            "What is one thing you can do to help someone today?",
            "What is your earliest memory?",
            "What makes you feel confident?",
            "What is the best gift you have ever given?",
            "What is a song that reminds you of a specific time in your life?",
            "What is one thing you would change about your routine?",
            "Who do you miss right now?",
            "What gospel principle is currently on your mind?"

        ];

        Random randomNumber = new Random();

        // Get random number.sdf
        int randomPromptIndex = randomNumber.Next(prompts.Count);

        return prompts[randomPromptIndex];
    }

    public void Display()
    {
        foreach (string item in _journalEntries)
        {
            Console.WriteLine(item);
        }
    }

    public void Save(string filename) // Save journal entries to text file.
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (string item in _journalEntries)
            {
                outputFile.WriteLine(item);
            }
        }
    }

    public void Load(string filename) // Load previously saved jorunal.
    {
        string[] text = File.ReadAllLines(filename);

        // Clear existing entries
        _journalEntries.Clear();

        foreach (string line in text)
        {
            _journalEntries.Add(line);
        }
    }
}