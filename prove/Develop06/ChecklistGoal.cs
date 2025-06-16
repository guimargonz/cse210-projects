// ChecklistGoal.cs
using System;

public class ChecklistGoal : Goal
{
    // Attributes
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0; // Starts at 0
    }

    // Constructor for loading (includes amount completed)
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }


    // Methods (Overrides)
    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"You recorded an event for '{_shortName}' and earned {_points} points.");
            int pointsEarned = _points;

            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Congratulations! You completed '{_shortName}' {_target} times and earned a bonus of {_bonus} points!");
                pointsEarned += _bonus;
            }
            return pointsEarned;
        }
        else
        {
            Console.WriteLine($"Goal '{_shortName}' has already been completed {_target} times.");
            return 0; // No points if target already met
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal:name,description,points,bonus,target,amountCompleted
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}