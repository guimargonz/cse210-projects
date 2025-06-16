// Cycling.cs
using System;

public class Cycling : Activity
{
    // Attributes
    private double _speedKph;

    // Constructor
    public Cycling(DateTime date, int lengthInMinutes, double speedKph)
        : base(date, lengthInMinutes)
    {
        _speedKph = speedKph;
    }

    // Override methods
    public override double GetDistance()
    {
        // Distance (km) = (speedKph / 60) * minutes
        return (_speedKph / 60.0) * GetLengthInMinutes();
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        // Pace (min per km) = 60 / speedKph
        if (_speedKph == 0) return 0; // Avoid division by zero
        return 60.0 / _speedKph;
    }
}