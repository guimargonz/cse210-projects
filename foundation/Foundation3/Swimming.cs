// Swimming.cs
using System;

public class Swimming : Activity
{
    // Attributes
    private int _numberOfLaps;
    private const double LapLengthMeters = 50.0; // Lap length is 50 meters

    // Constructor
    public Swimming(DateTime date, int lengthInMinutes, int numberOfLaps)
        : base(date, lengthInMinutes)
    {
        _numberOfLaps = numberOfLaps;
    }

    // Override methods
    public override double GetDistance()
    {
        // Distance (km) = swimming laps * 50 / 1000
        return _numberOfLaps * LapLengthMeters / 1000.0;
    }

    public override double GetSpeed()
    {
        // Speed (kph) = (distance / minutes) * 60
        double distanceKm = GetDistance();
        if (GetLengthInMinutes() == 0) return 0; // Avoid division by zero
        return (distanceKm / GetLengthInMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        // Pace (min per km) = minutes / distance
        double distanceKm = GetDistance();
        if (distanceKm == 0) return 0; // Avoid division by zero
        return GetLengthInMinutes() / distanceKm;
    }
}