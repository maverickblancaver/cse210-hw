using System;

class Assignment
{
    protected string studentName;
    protected string subject;

    public Assignment(string studentName, string subject)
    {
        this.studentName = studentName;
        this.subject = subject;
    }

    public virtual string GetSummary()
    {
        return $"Student: {studentName}\nSubject: {subject}";
    }
}

class MathAssignment : Assignment
{
    private string topic;
    private string chapter;

    public MathAssignment(string studentName, string subject, string topic, string chapter)
        : base(studentName, subject)
    {
        this.topic = topic;
        this.chapter = chapter;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $"\nTopic: {topic}\nChapter: {chapter}";
    }

    public string GetHomeworkList()
    {
        return "1. Do exercises on fractions.\n2. Review chapter 7.3.\n3. Complete problems 8-19.";
    }
}

class WritingAssignment : Assignment
{
    private string essayTopic;

    public WritingAssignment(string studentName, string subject, string essayTopic)
        : base(studentName, subject)
    {
        this.essayTopic = essayTopic;
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $"\nEssay Topic: {essayTopic}";
    }

    public string GetWritingInformation()
    {
        return "Research materials: Refer to textbooks and online resources.\nEssay length: Minimum 1000 words.";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a base "Assignment" object
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        // Now create the derived class assignments
        MathAssignment a2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}
