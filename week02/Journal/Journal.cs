using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> Entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
        Console.WriteLine("Entry saved.");
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.UserResponse}");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        Entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry();
                entry.Date = parts[0];
                entry.Prompt = parts[1];
                entry.UserResponse = parts[2];
                Entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded.");
    }

    public void SearchEntries(string keyword)
    {
        foreach (Entry entry in Entries)
        {
            if (entry.Date.Contains(keyword) || entry.Prompt.Contains(keyword) || entry.UserResponse.Contains(keyword))
            {
                entry.Display();
            }
        }
    }
}
