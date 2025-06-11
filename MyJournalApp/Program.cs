// Program.cs
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt() ?? "";
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine() ?? "";
                    journal.AddEntry(new Entry(prompt, response));
                    break;
                case "2":
                    journal.Display();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string? saveFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(saveFile))
                    {
                        journal.SaveToFile(saveFile);
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename.");
                    }
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string? loadFile = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(loadFile))
                    {
                        journal.LoadFromFile(loadFile);
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename.");
                    }
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}

class Entry
{
    private string _date;
    public string Date => _date;
    public string Prompt { get; }
    public string Response { get; }

    public Entry(string prompt, string response)
    {
        _date = DateTime.Now.ToShortDateString();
        Prompt = prompt ?? "";
        Response = response ?? "";
    }

    private Entry(string date, string prompt, string response)
    {
        _date = date ?? DateTime.Now.ToShortDateString();
        Prompt = prompt ?? "";
        Response = response ?? "";
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n");
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        if (parts.Length < 3)
        {
            throw new FormatException("Invalid entry format in file.");
        }
        return new Entry(parts[0], parts[1], parts[2]);
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileFormat());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            _entries.Add(Entry.FromFileFormat(line));
        }
    }
}

class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "Did I say my prayers today?",
        "Did I study God's word today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
