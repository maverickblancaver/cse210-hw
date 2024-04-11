using System;

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

public class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public Address Address { get; set; }

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"{GetType().Name}: {Title}, Date: {Date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

public class Reception : Event
{
    public string RsvpEmail { get; set; }

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nRSVP Email: {RsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nWeather Forecast: {WeatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var lecture = new Lecture("Introduction to OOP", "Learn the basics of Object-Oriented Programming", DateTime.Now.Date, TimeSpan.FromHours(10), new Address("123 Main St", "Anytown", "CA", "USA"), "John Doe", 50);
        Console.WriteLine(lecture.GetFullDetails());

        var reception = new Reception("Company Anniversary Party", "Celebrate our successful year", DateTime.Now.Date, TimeSpan.FromHours(18), new Address("456 Elm St", "Anycity", "NY", "USA"), "rsvp@example.com");
        Console.WriteLine(reception.GetFullDetails());

        var outdoorGathering = new OutdoorGathering("Community Picnic", "Join us for food and fun in the park", DateTime.Now.Date, TimeSpan.FromHours(12), new Address("Park Ave", "Anypark", "WA", "USA"), "Sunny with a chance of clouds");
        Console.WriteLine(outdoorGathering.GetFullDetails());
    }
}
