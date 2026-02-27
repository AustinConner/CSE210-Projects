using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Transactions;

public class Program
{
    static void Main(string[] args)
    {
        // Create a scripture to hold everyting
        Scripture scripture = new Scripture();

        bool menu = true;
        while (menu)
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("            [ Scripture Memorizer ]          ");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine();
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Use random scripture");
            Console.WriteLine("2. Provide a scripture");
            Console.Write("> ");
            string response = Console.ReadLine();
            int choice;
            bool success = int.TryParse(response, out choice);
            if (!success)
            {
                Console.WriteLine("Invalid selection.");
            }

            if (choice == 1) // random scripture
            {
                Console.Clear();
                Console.WriteLine("How many scriptures do you want to select?");
                Console.Write("> ");
                int selectAmt = int.Parse(Console.ReadLine());

                List<ScriptureJson> randomScriptures = scripture.GetRandomScriptures(selectAmt);

                // get scripture into
                int start = randomScriptures[0].VerseNumber;
                int end = randomScriptures[^1].VerseNumber;
                string book = randomScriptures[0].BookTitle;
                int chapter = randomScriptures[0].ChapterNumber;

                if (end == start)
                {
                    Reference randomScruptureRef = new Reference(book, chapter, start);
                    scripture.SetReference(randomScruptureRef);
                }
                else
                {
                    Reference randomScruptureRef = new Reference(book, chapter, start, end);
                    scripture.SetReference(randomScruptureRef);
                }

                // create verses for each of the scriptures in the list
                foreach (ScriptureJson verse in randomScriptures)
                {
                    int verseNum = verse.VerseNumber;
                    string txt = verse.Text;
                    scripture.AddVerse(verseNum, txt);
                }
            }

            if (choice == 2) // provide scripture
            {
                Console.WriteLine("What is the book name?");
                string bookName = Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"{bookName} [?]");
                Console.WriteLine("What chapter?");
                int chapter = int.Parse(Console.ReadLine());
                Console.Clear();
                
                Console.WriteLine($"{bookName} {chapter}: [?]");
                Console.WriteLine("Starting verse number?");
                int start = int.Parse(Console.ReadLine());
                Console.Clear();

                Console.WriteLine($"{bookName} {chapter}: {start}-[?]");
                Console.WriteLine("End verse number? (if not doing multiple, just use same value used for starting verse number)");
                int end = int.Parse(Console.ReadLine());
                Console.Clear();

                if (start == end)
                {
                    Reference scriptureRef = new Reference(bookName, chapter, start);
                    scripture.SetReference(scriptureRef);
                } else
                {
                    Reference scriptureRef = new Reference(bookName, chapter, start, end);
                    scripture.SetReference(scriptureRef);
                }

                for (int i = start; i <= end; i++)
                {
                    Console.WriteLine($"Enter text for verse {i}");
                    scripture.AddVerse(i, Console.ReadLine());
                }


            }
            Console.Clear();
            break;
        }

        bool running = true;
        while (running)
        {
            scripture.Display();
            scripture.HideRandomWord();

            if (scripture.TotalVerses() == scripture.TotalHiddenVerses())
            {
                break;
            }

            Console.WriteLine("Press ENTER to continue or type 'quit' to finish:");
            string userinput = Console.ReadLine();
            if (userinput == "quit")
            {
                break;
            }

            Console.Clear();
        }
    }
} 