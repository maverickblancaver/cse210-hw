using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Base class for goals
public abstract class Goal
{
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    // Constructor
    public Goal(string name)
    {
        Name = name;
        IsCompleted = false;
    }

    // Abstract method to record an event
    public abstract int RecordEvent();
}

// Simple goal class
public class SimpleGoal : Goal
{
    public int Points { get; set; }

    // Constructor
    public SimpleGoal(string name, int points) : base(name)
    {
        Points = points;
    }

    // Implementation of RecordEvent method
    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            return Points;
        }
        return 0;
    }
}

// Eternal goal class
public class EternalGoal : Goal
{
    public int Points { get; set; }

    // Constructor
    public EternalGoal(string name, int points) : base(name)
    {
        Points = points;
    }

    // Implementation of RecordEvent method
    public override int RecordEvent()
    {
        return Points;
    }
}

// Checklist goal class
public class ChecklistGoal : Goal
{
    public int PointsPerEvent { get; set; }
    public int TotalEvents { get; set; }
    public int BonusPoints { get; set; }
    public int EventsCompleted { get; set; }

    // Constructor
    public ChecklistGoal(string name, int pointsPerEvent, int totalEvents, int bonusPoints) : base(name)
    {
        PointsPerEvent = pointsPerEvent;
        TotalEvents = totalEvents;
        BonusPoints = bonusPoints;
        EventsCompleted = 0;
    }

    // Implementation of RecordEvent method
    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            EventsCompleted++;
            if (EventsCompleted >= TotalEvents)
            {
                IsCompleted = true;
                return PointsPerEvent * TotalEvents + BonusPoints;
            }
            return PointsPerEvent;
        }
        return 0;
    }
}

// Main program
class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("Eternal Quest Menu");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateNewGoal()
    {
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter the type of goal (1: Simple, 2: Eternal, 3: Checklist): ");
        string typeStr = Console.ReadLine();
        if (!int.TryParse(typeStr, out int type))
        {
            Console.WriteLine("Invalid input for goal type.");
            return;
        }

        switch (type)
        {
            case 1:
                Console.Write("Enter the points for completing the goal: ");
                if (!int.TryParse(Console.ReadLine(), out int points))
                {
                    Console.WriteLine("Invalid input for points.");
                    return;
                }
                goals.Add(new SimpleGoal(name, points));
                Console.WriteLine("Simple goal created successfully.");
                break;
            case 2:
                Console.Write("Enter the points for each event: ");
                if (!int.TryParse(Console.ReadLine(), out int eternalPoints))
                {
                    Console.WriteLine("Invalid input for points.");
                    return;
                }
                goals.Add(new EternalGoal(name, eternalPoints));
                Console.WriteLine("Eternal goal created successfully.");
                break;
            case 3:
                Console.Write("Enter the points per event: ");
                if (!int.TryParse(Console.ReadLine(), out int pointsPerEvent))
                {
                    Console.WriteLine("Invalid input for points.");
                    return;
                }
                Console.Write("Enter the total events required: ");
                if (!int.TryParse(Console.ReadLine(), out int totalEvents))
                {
                    Console.WriteLine("Invalid input for total events.");
                    return;
                }
                Console.Write("Enter the bonus points upon completion: ");
                if (!int.TryParse(Console.ReadLine(), out int bonusPoints))
                {
                    Console.WriteLine("Invalid input for bonus points.");
                    return;
                }
                goals.Add(new ChecklistGoal(name, pointsPerEvent, totalEvents, bonusPoints));
                Console.WriteLine("Checklist goal created successfully.");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    static void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.WriteLine("List of Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name} [{(goals[i].IsCompleted ? "X" : " ")}]");
        }
    }

    static void SaveGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to save.");
            return;
        }

        string json = JsonSerializer.Serialize(goals);
        File.WriteAllText("goals.json", json);
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.json"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        string json = File.ReadAllText("goals.json");
        goals = JsonSerializer.Deserialize<List<Goal>>(json);
        Console.WriteLine("Goals loaded successfully.");
    }

    static void RecordEvent()
    {
        ListGoals();
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available to record event.");
            return;
        }

        Console.Write("Enter the index of the goal to record event: ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > goals.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        int pointsEarned = goals[index - 1].RecordEvent();
        Console.WriteLine($"Event recorded for {goals[index - 1].Name}. Points earned: {pointsEarned}");
    }
}
