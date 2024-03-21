using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference reference;
    private List<Word> words;
    private List<int> hiddenIndices;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = new List<Word>();
        this.hiddenIndices = new List<int>();

        string[] wordArray = text.Split(new char[] { ' ', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in wordArray)
        {
            words.Add(new Word(wordText));
        }
    }

    public void Display()
    {
        Console.WriteLine(reference.GetDisplayText());
        foreach (var word in words)
        {
            if (hiddenIndices.Contains(words.IndexOf(word)))
                Console.Write("***** ");
            else
                Console.Write(word.Text + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int numberOfWordsToHide = random.Next(1, words.Count / 2); // Hide up to half of the words
        for (int i = 0; i < numberOfWordsToHide; i++)
        {
            int indexToHide = random.Next(words.Count);
            if (!hiddenIndices.Contains(indexToHide))
                hiddenIndices.Add(indexToHide);
        }
    }

    public bool AllWordsHidden()
    {
        return hiddenIndices.Count == words.Count;
    }
}

public class Reference
{
    private string text;

    public Reference(string text)
    {
        this.text = text;
    }

    public string GetDisplayText()
    {
        return text;
    }
}

public class Word
{
    public string Text { get; }

    public Word(string text)
    {
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John 3:16");
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            else
                scripture.HideRandomWords();
        }
    }
}
