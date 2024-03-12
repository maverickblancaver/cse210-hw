using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        
        // Prompt user to enter numbers until 0 is entered
        while (true)
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            if (num == 0)
                break;
            numbers.Add(num);
        }
        
        // Calculate sum
        int sum = numbers.Sum();
        Console.WriteLine("The sum is: " + sum);
        
        // Calculate average
        double average = numbers.Average();
        Console.WriteLine("The average is: " + average);
        
        // Find maximum number
        int max = numbers.Max();
        Console.WriteLine("The largest number is: " + max);
        
        // Find smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(0).Min();
        Console.WriteLine("The smallest positive number is: " + smallestPositive);
        
        // Sort and display the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
