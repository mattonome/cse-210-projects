using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = LoadRandomScripture("scriptures.txt");

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are now hidden. Good job!");
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 new words each time
        }
    }

    static Scripture LoadRandomScripture(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var entries = new List<(Reference, string)>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Expected format: Reference|Text
            string[] parts = line.Split('|');
            if (parts.Length != 2) continue;

            string refText = parts[0].Trim();
            string text = parts[1].Trim();

            Reference reference = ParseReference(refText);
            entries.Add((reference, text));
        }

        Random rand = new Random();
        var selected = entries[rand.Next(entries.Count)];
        return new Scripture(selected.Item1, selected.Item2);
    }

    static Reference ParseReference(string refText)
    {
        // e.g., John 3:16 or Proverbs 3:5-6
        string[] bookAndRest = refText.Split(' ', 2);
        string book = bookAndRest[0];
        string[] chapterAndVerse = bookAndRest[1].Split(':');
        int chapter = int.Parse(chapterAndVerse[0]);

        string[] verses = chapterAndVerse[1].Split('-');
        int startVerse = int.Parse(verses[0]);
        if (verses.Length > 1)
        {
            int endVerse = int.Parse(verses[1]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            return new Reference(book, chapter, startVerse);
        }
    }
}
