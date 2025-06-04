// ListingActivity.cs
using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    // Attributes
    private List<string> _prompts;
    private List<string> _itemsListed;
    private Random _random;

    // Constructor
    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _itemsListed = new List<string>();
        _random = new Random();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Method
    public void Run()
    {
        DisplayStartingMessage(); // From base class

        string prompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
        Console.Write("You may begin in: ");
        ShowCountdown(5); // Countdown before they start listing
        Console.WriteLine(); // New line

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_durationInSeconds);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item)) // Only add if not empty
            {
                _itemsListed.Add(item);
            }
            // No explicit break needed here if ReadLine is blocking,
            // loop condition handles time.
        }

        Console.WriteLine($"\nYou listed {_itemsListed.Count} items!");
        // _itemsListed.Clear(); // Clear for next run if desired, or manage per instance

        DisplayEndingMessage(); // From base class
    }
}