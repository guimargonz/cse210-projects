// Activity.cs
using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity // Making it abstract as Run() will be specific
{
    // Attributes
    protected string _name;
    protected string _description;
    protected int _durationInSeconds;

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        // _durationInSeconds will be set by DisplayStartingMessage
    }

    // Methods
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine($"\n{_description}");
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _durationInSeconds = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5); // Pause for 5 seconds
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3); // Short pause
        Console.WriteLine($"\nYou have completed another {_durationInSeconds} seconds of the {_name}.");
        ShowSpinner(5); // Pause for 5 seconds
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250); // Control speed of spinner
            Console.Write("\b \b"); // Erase the character

            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
        Console.Write(" "); // Clear the last spinner character
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            if (i >= 10) // For two-digit numbers
            {
                Console.Write("\b\b  \b\b");
            }
            else // For one-digit numbers
            {
                Console.Write("\b \b");
            }
        }
        Console.Write("  "); // Clear the countdown area
    }

    // Each derived class will implement its own specific run logic
    // This could be an abstract method if Activity is abstract,
    // or a virtual method if a default (empty) behavior is desired.
    // For this project, specific Run methods in derived classes are fine.
    // public abstract void Run();
}