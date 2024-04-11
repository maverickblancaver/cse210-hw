using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var video1 = new Video("Introduction to OOP", "John Doe", 600);
        video1.Comments.Add(new Comment { CommenterName = "Alice", CommentText = "Great video!" });
        video1.Comments.Add(new Comment { CommenterName = "Bob", CommentText = "Very helpful." });

        var video2 = new Video("Advanced C# Programming", "Jane Smith", 1200);
        video2.Comments.Add(new Comment { CommenterName = "Charlie", CommentText = "I didn't understand the last part." });

        var videos = new List<Video> { video1, video2 };

        foreach (var video in videos)
        {
            video.DisplayDetails();
            Console.WriteLine();
        }
    }
}
