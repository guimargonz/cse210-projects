// BreathingActivity.cs
using System;
using System.Threading;

public class BreathingActivity : Activity
{
    // Constructor
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Method
    public void Run()
    {
        DisplayStartingMessage(); // From base class

        DateTime endTime = DateTime.Now.AddSeconds(_durationInSeconds);
        int breathCycleSeconds = 10; // e.g., 5 in, 5 out, adjust as needed

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(breathCycleSeconds / 2); // Half time for breathe in
            if (DateTime.Now >= endTime) break;

            Console.Write("\nNow breathe out... ");
            ShowCountdown(breathCycleSeconds / 2); // Half time for breathe out
            Console.WriteLine(); // New line for next cycle
        }

        DisplayEndingMessage(); // From base class
    }
}