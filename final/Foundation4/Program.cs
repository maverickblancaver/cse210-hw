using System;

public abstract class Activity
{
    public DateTime Date { get; set; }
    public int LengthInMinutes { get; set; }

    public Activity(DateTime date, int lengthInMinutes)
    {
        Date = date;
        LengthInMinutes = lengthInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} {GetType().Name} ({LengthInMinutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min/mile";
    }
}

public class Running : Activity
{
    public double DistanceInMiles { get; set; }

    public Running(DateTime date, int lengthInMinutes, double distanceInMiles)
        : base(date, lengthInMinutes)
    {
        DistanceInMiles = distanceInMiles;
    }

    public override double GetDistance()
    {
        return DistanceInMiles;
    }

    public override double GetSpeed()
    {
        return DistanceInMiles / (LengthInMinutes / 60.0);
    }

    public override double GetPace()
    {
        return LengthInMinutes / DistanceInMiles;
    }
}

public class Cycling : Activity
{
    public double SpeedInMph { get; set; }

    public Cycling(DateTime date, int lengthInMinutes, double speedInMph)
        : base(date, lengthInMinutes)
    {
        SpeedInMph = speedInMph;
    }

    public override double GetDistance()
    {
        return SpeedInMph * (LengthInMinutes / 60.0);
    }

    public override double GetSpeed()
    {
        return SpeedInMph;
    }

    public override double GetPace()
    {
        return 60 / SpeedInMph;
    }
}

public class Swimming : Activity
{
    public int Laps { get; set; }

    public Swimming(DateTime date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0; // 50 meters per lap, convert to kilometers
    }

    public override double GetSpeed()
    {
        return GetDistance() / (LengthInMinutes / 60.0); // speed in km/h
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance(); // pace in minutes per kilometer
    }
}

class Program
{
    static void Main(string[] args)
    {
        var activities = new Activity[]
        {
            new Running(DateTime.Now, 30, 3.0),
            new Cycling(DateTime.Now, 45, 15.0),
            new Swimming(DateTime.Now, 60, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
