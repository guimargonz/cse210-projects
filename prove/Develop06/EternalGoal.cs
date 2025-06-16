// EternalGoal.cs
using System;

public class EternalGoal : Goal
{
    // No additional attributes needed beyond the base class

    // Constructor
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        // No extra initialization needed
    }

    // Methods (Overrides)
    public override int RecordEvent()
    {
        Console.WriteLine($"You recorded an event for '{_shortName}' and earned {_points} points.");
        return _points; // Always award points, as it's never "complete"
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never considered "complete"
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal:name,description,points
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}