// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // --- Start of Exceeding Requirements Section ---
        // Description of exceeding requirements:
        // 1. Levels: The player's score is used to determine a "Level".
        //    This is displayed along with the score. (Simple implementation in DisplayPlayerInfo)
        // 2. Load/Save Feedback: More detailed messages on save/load success or failure.
        // 3. Robust Loading: The LoadGoals method includes basic error handling (try-catch)
        //    and checks if the file exists. It also clears existing goals and score on error.
        // 4. Constructors for Loading: SimpleGoal and ChecklistGoal have additional constructors
        //    that accept their full state (isComplete, amountCompleted) for easier instantiation
        //    when loading from a file.
        // --- End of Exceeding Requirements Section ---

        GoalManager manager = new GoalManager();
        manager.Start(); // This will run the main menu loop
    }
}