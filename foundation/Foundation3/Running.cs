// Running.cs
using System;

public class Running : Activity
{
    // Attributes
    private double _distanceKm;

    // Constructor
    public Running(DateTime date, int lengthInMinutes, double distanceKm)
        : base(date, lengthInMinutes)
    {
        _distanceKm = distanceKm;
    }

    // Override methods
    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        // Speed (kph) = (distance / minutes) * 60
        if (GetLengthInMinutes() == 0) return 0; // Avoid division by zero
        return (_distanceKm / GetLengthInMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        // Pace (min per km) = minutes / distance
        if (_distanceKm == 0) return 0; // Avoid division by zero
        return GetLengthInMinutes() / _distanceKm;
    }
}