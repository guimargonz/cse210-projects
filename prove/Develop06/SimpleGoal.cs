// SimpleGoal.cs
using System;

public class SimpleGoal : Goal
{
    // Attributes
    private bool _isComplete;

    // Constructor
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false; // Simple goals start as not complete
    }

    // Constructor for loading (includes completion status)
    public SimpleGoal(string name, string description, int points, bool isComplete)
    : base(name, description, points)
    {
        _isComplete = isComplete;
    }


    // Methods (Overrides)
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You have completed '{_shortName}' and earned {_points} points.");
            return _points;
        }
        else
        {
            Console.WriteLine($"Goal '{_shortName}' has already been completed.");
            return 0; // No points if already complete
        }
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal:name,description,points,isComplete
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}