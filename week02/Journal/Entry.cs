using System;

public class Entry
{
    public string Date;
    public string Prompt;
    public string UserResponse;

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {UserResponse}");
        Console.WriteLine("----------------------------");
    }
}
