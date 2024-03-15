using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // Abstraction for Journal
    public class Journal
    {
        private List<Entry> _entries;

        public Journal()
        {
            _entries = new List<Entry>();
        }

        // Functionality: Journal Writing
        public void WriteEntry(string content, string prompt)
        {
            Entry entry = new Entry(content, prompt);
            _entries.Add(entry);
        }

        // Functionality: Journal Display
        public void DisplayEntries()
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Content: {entry.Content}");
            }
        }

        // Functionality: Saving
        public void SaveJournalToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Date,Prompt,Content");
                foreach (var entry in _entries)
                {
                    writer.WriteLine($"\"{entry.Date}\",\"{entry.Prompt}\",\"{entry.Content}\"");
                }
            }
        }

        // Functionality: Loading
        public void LoadJournalFromFile(string filePath)
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool headerSkipped = false;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!headerSkipped)
                    {
                        headerSkipped = true;
                        continue; // Skip the header line
                    }

                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        string date = parts[0].Trim('"');
                        string prompt = parts[1].Trim('"');
                        string content = parts[2].Trim('"');
                        _entries.Add(new Entry(content, date, prompt));
                    }
                }
            }
        }

        // Functionality: Prompt Generation
        public static string GetRandomPrompt()
        {
            string[] prompts = {
                "How is your day?",
                "What was your favorite experience of the day?",
                "What did you learn today?"
            };
            Random rnd = new Random();
            return prompts[rnd.Next(prompts.Length)];
        }
    }

    // Abstraction for Entry
    public class Entry
    {
        public string Date { get; private set; }
        public string Prompt { get; private set; }
        public string Content { get; private set; }

        public Entry(string content, string prompt)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Prompt = prompt;
            Content = content;
        }

        public Entry(string content, string date, string prompt)
        {
            Date = date;
            Prompt = prompt;
            Content = content;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();

            Console.WriteLine("Welcome to your journal!");

            while (true)
            {
                Console.WriteLine("What would you like to do? (type the number)");
                Console.WriteLine("1. Journal Entry (choose by typing the number)");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Choose a prompt (type the number):");
                        Console.WriteLine("\t1. How is your day?");
                        Console.WriteLine("\t2. What was your favorite experience of the day?");
                        Console.WriteLine("\t3. What did you learn today?");
                        string promptChoice = Console.ReadLine();
                        string prompt;
                        switch (promptChoice)
                        {
                            case "1":
                                prompt = "How is your day?";
                                break;
                            case "2":
                                prompt = "What was your favorite experience of the day?";
                                break;
                            case "3":
                                prompt = "What did you learn today?";
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                continue;
                        }
                        Console.WriteLine("Enter your journal entry:");
                        string entryContent = Console.ReadLine();
                        journal.WriteEntry(entryContent, prompt);
                        break;
                    case "2":
                        Console.WriteLine("Your journal entries:");
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.WriteLine("Loading journal from file...");
                        journal.LoadJournalFromFile("journal.csv");
                        Console.WriteLine("Loaded journal entries:");
                        journal.DisplayEntries();
                        break;
                    case "4":
                        Console.WriteLine("Saving journal to file...");
                        journal.SaveJournalToFile("journal.csv");
                        Console.WriteLine("Journal saved successfully.");
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
