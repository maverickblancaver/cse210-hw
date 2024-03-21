using System;
using System.Collections.Generic;
using System.IO;

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

public class ScriptureLibrary
{
    private List<Scripture> scriptures;
    private Random random;

    public ScriptureLibrary()
    {
        scriptures = new List<Scripture>();
        random = new Random();
    }

    public void AddScripture(Scripture scripture)
    {
        scriptures.Add(scripture);
    }

    public Scripture GetRandomScripture()
    {
        if (scriptures.Count == 0)
            return null;
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

       
        library.AddScripture(new Scripture(new Reference("Matthew 11:28"), "Come to me, all you who are weary and burdened, and I will give you rest."));
        library.AddScripture(new Scripture(new Reference("Philippians 4:13"), "I can do all this through him who gives me strength."));
        library.AddScripture(new Scripture(new Reference("Romans 8:28"), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."));
        library.AddScripture(new Scripture(new Reference("Jeremiah 29:11"), "For I know the plans I have for you,” declares the LORD, “plans to prosper you and not to harm you, plans to give you hope and a future."));
        library.AddScripture(new Scripture(new Reference("John 14:6"), "Jesus answered, 'I am the way and the truth and the life. No one comes to the Father except through me.'"));


        while (true)
        {
            Console.Clear();
            Scripture randomScripture = library.GetRandomScripture();
            if (randomScripture == null)
            {
                Console.WriteLine("No scriptures available in the library.");
                break;
            }
            randomScripture.Display();
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            else
                randomScripture.HideRandomWords();
        }
    }
}
