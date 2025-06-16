// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO; // For file operations

public class GoalManager
{
    // Attributes
    private List<Goal> _goals;
    private int _score;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Methods
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

        public void DisplayPlayerInfo() // Modified for levels
    {
        Console.WriteLine($"\nYou have {_score} points.");
        // Exceeding Requirement: Levels
        int level = (_score / 500) + 1; // Example: New level every 500 points
        Console.WriteLine($"Level: {level}");
    }

    public void ListGoalNames() // Used by RecordEvent
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create some!");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;
        switch (typeChoice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }
        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record. Create some first!");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? (Enter number) ");
        int goalNumber;
        if (int.TryParse(Console.ReadLine(), out goalNumber) && goalNumber > 0 && goalNumber <= _goals.Count)
        {
            int pointsEarned = _goals[goalNumber - 1].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number selected.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score); // Save the current score first
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals and score saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. No goals loaded.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear(); // Clear existing goals before loading

            if (lines.Length > 0)
            {
                _score = int.Parse(lines[0]); // Load the score from the first line
            }

            for (int i = 1; i < lines.Length; i++) // Start from the second line for goals
            {
                string line = lines[i];
                string[] parts = line.Split(':'); // Split "GoalType:details"
                string goalType = parts[0];
                string[] goalDetails = parts[1].Split(',');

                Goal goal = null;
                string name = goalDetails[0];
                string description = goalDetails[1];
                int points = int.Parse(goalDetails[2]);

                switch (goalType)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(goalDetails[3]);
                        goal = new SimpleGoal(name, description, points, isComplete);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int bonus = int.Parse(goalDetails[3]);
                        int target = int.Parse(goalDetails[4]);
                        int amountCompleted = int.Parse(goalDetails[5]);
                        goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                        break;
                }
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
            Console.WriteLine("Goals and score loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
            _goals.Clear(); // Clear potentially partially loaded goals
            _score = 0;     // Reset score on error
        }
    }
}