using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompting the user for their first name
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();

        // Prompting the user for their last name
        Console.WriteLine("What is your last name?");
        string lastName = Console.ReadLine();

        // Displaying the name in the desired format
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
