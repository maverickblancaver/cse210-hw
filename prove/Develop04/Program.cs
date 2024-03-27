using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {name} activity:");
        Console.WriteLine(description);
        SetDuration();
        Console.WriteLine("Please prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
        Execute(); // Call Execute method
    }

    public void End()
    {
        Console.WriteLine($"Good job! You have completed the {name} activity.");
        Console.WriteLine($"You spent {duration} seconds on this activity.");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected abstract void SetDuration();
    protected abstract void Execute();
}

class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description) { }

    protected override void SetDuration()
    {
        Console.WriteLine("Please enter the duration of the activity in seconds:");
        duration = int.Parse(Console.ReadLine());
    }

    protected override void Execute()
    {
        Console.WriteLine("Breathe in...");
        Thread.Sleep(3000); // Pause for 3 seconds
        Console.WriteLine("Breathe out...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(string name, string description) : base(name, description) { }

    protected override void SetDuration()
    {
        Console.WriteLine("Please enter the duration of the activity in seconds:");
        duration = int.Parse(Console.ReadLine());
    }

    protected override void Execute()
    {
        Random rand = new Random();

        foreach (var prompt in prompts)
        {
            Console.WriteLine(prompt);
            Thread.Sleep(3000); // Pause for 3 seconds

            foreach (var question in questions)
            {
                Console.WriteLine(question);
                Thread.Sleep(3000); // Pause for 3 seconds
            }
        }
    }
}

class ListingActivity : Activity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name, string description) : base(name, description) { }

    protected override void SetDuration()
    {
        Console.WriteLine("Please enter the duration of the activity in seconds:");
        duration = int.Parse(Console.ReadLine());
    }

    protected override void Execute()
    {
        Random rand = new Random();
        int itemCount = 0;

        Console.WriteLine(prompts[rand.Next(prompts.Count)]);
        Thread.Sleep(5000); // Pause for 5 seconds

        // Start listing items until duration is reached
        while (duration > 0)
        {
            Console.WriteLine("Keep listing items...");
            Thread.Sleep(1000); // Pause for 1 second
            itemCount++;
            duration--;
        }

        Console.WriteLine($"You listed {itemCount} items.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Activity Program!");

        // Create menu system
        Console.WriteLine("Choose an activity: Type the number");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Reflection");
        Console.WriteLine("3. Listing");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                breathingActivity.Start();
                breathingActivity.End();
                break;
            case 2:
                ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                reflectionActivity.Start();
                reflectionActivity.End();
                break;
            case 3:
                ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                listingActivity.Start();
                listingActivity.End();
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }
}
