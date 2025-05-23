using System;

public class Entry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }

    private string _date;

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToShortDateString();
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {GetDate()}\nPrompt: {Prompt}\nResponse: {Response}\n");
    }

    public string ToFileFormat()
    {
        return $"{GetDate()}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        return new Entry(parts[1], parts[2]) { _date = parts[0] };
    }

    public string GetDate() => _date ?? Date;
}
