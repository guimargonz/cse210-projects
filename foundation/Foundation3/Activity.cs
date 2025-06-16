// Activity.cs
using System;

public abstract class Activity
{
    // Attributes
    private DateTime _date;
    private int _lengthInMinutes;

    // Constructor
    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Getters
    public DateTime GetDate()
    {
        return _date;
    }

    public int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance(); // in km
    public abstract double GetSpeed();    // in kph
    public abstract double GetPace();     // in min per km

    // Virtual method to get the summary
    // Can be overridden if a derived class needs a completely different summary format,
    // but the goal is for this base version to work for all by calling the overridden methods.
    public virtual string GetSummary()
    {
        // Example: 03 Nov 2022 Running (30 min): Distance 4.8 km, Speed: 9.7 kph, Pace: 6.25 min per km
        // We need to know the activity type. We can get it from the object's type itself.
        string activityType = GetType().Name; // Gets "Running", "Cycling", or "Swimming"
        
        return $"{_date.ToString("dd MMM yyyy")} {activityType} ({_lengthInMinutes} min): " +
               $"Distance {GetDistance():F1} km, Speed: {GetSpeed():F1} kph, Pace: {GetPace():F2} min per km";
    }
}