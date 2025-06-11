using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Journal myJournal = new Journal();
        Random random = new Random();
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display entries");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Search entries");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1-6): ");

            string input = Console.ReadLine();
            int.TryParse(input, out choice);

            if (choice == 1)
            {
                string prompt = prompts[random.Next(prompts.Count)];
                Console.WriteLine($"Prompt: {prompt}");
                string answer = Console.ReadLine();

                Entry entry = new Entry();
                entry.Date = DateTime.Now.ToString("yyyy/MM/dd");
                entry.Prompt = prompt;
                entry.UserResponse = answer;

                myJournal.AddEntry(entry);
            }
            else if (choice == 2)
            {
                myJournal.DisplayEntries();
            }
            else if (choice == 3)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
            }
            else if (choice == 4)
            {
                Console.Write("Enter filename: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (choice == 5)
            {
                Console.Write("Enter keyword or date (yyyy/mm/dd): ");
                string search = Console.ReadLine();
                myJournal.SearchEntries(search);
            }
        }
    }
}