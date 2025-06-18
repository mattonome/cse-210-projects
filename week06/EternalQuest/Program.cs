using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

// Base class
abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }
    public abstract bool IsComplete { get; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();
}

// SimpleGoal
class SimpleGoal : Goal
{
    private bool _isComplete;

    public override bool IsComplete => _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return Points;
    }

    public override string GetStatus() => $"[{(IsComplete ? "X" : " ")}] {Name} ({Description})";

    public override string GetStringRepresentation() => $"SimpleGoal:{Name},{Description},{Points},{_isComplete}";
}

// EternalGoal
class EternalGoal : Goal
{
    public override bool IsComplete => false;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => Points;

    public override string GetStatus() => $"[ ] {Name} ({Description})";

    public override string GetStringRepresentation() => $"EternalGoal:{Name},{Description},{Points}";
}

// ChecklistGoal Section
class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public override bool IsComplete => _currentCount >= _targetCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        return IsComplete ? Points + _bonus : Points;
    }

    public override string GetStatus() => $"[{(IsComplete ? "X" : " ")}] {Name} ({Description}) -- Completed {_currentCount}/{_targetCount} times";

    public override string GetStringRepresentation() => $"ChecklistGoal:{Name},{Description},{Points},{_bonus},{_targetCount},{_currentCount}";
}

// Section for Goal Manager 
class GoalManager
{
    private List<Goal> _goals = new();
    private int _score = 0;

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.Clear();
            Console.WriteLine($"\nScore: {_score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Choose Goal Type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");
        Console.Write("Type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            _goals.Add(new SimpleGoal(name, description, points));
        else if (type == "2")
            _goals.Add(new EternalGoal(name, description, points));
        else if (type == "3")
        {
            Console.Write("Target Count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            int points = _goals[index].RecordEvent();
            _score += points;
            Console.WriteLine($"You earned {points} points!");
        }
        else Console.WriteLine("Invalid goal.");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string file = Console.ReadLine();
        using StreamWriter output = new(file);
        output.WriteLine(_score);
        foreach (Goal goal in _goals)
            output.WriteLine(goal.GetStringRepresentation());
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string file = Console.ReadLine();
        string[] lines = File.ReadAllLines(file);
        _score = int.Parse(lines[0]);
        _goals.Clear();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string[] data = parts[1].Split(",");
            switch (parts[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
                    break;
            }
        }
    }
}
