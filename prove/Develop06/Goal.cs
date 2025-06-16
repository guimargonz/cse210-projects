// Goal.cs
using System;

public abstract class Goal
{
    // Attributes (protected to allow derived classes access if needed for their logic)
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract methods - must be implemented by derived classes
    public abstract int RecordEvent(); // Returns points earned
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation(); // For saving to file

    // Virtual method - can be overridden, but has a default implementation
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    // Getters (if needed by GoalManager or for saving specific parts)
    public string GetName()
    {
        return _shortName;
    }
    // public int GetPoints() // Not strictly needed by current design if RecordEvent returns points
    // {
    //     return _points;
    // }
}