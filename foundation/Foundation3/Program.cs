// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Exercise Tracking Program ---");

        // Create a list to hold activities
        List<Activity> activities = new List<Activity>();

        // Create at least one activity of each type
        Running runningActivity = new Running(new DateTime(2022, 11, 3), 30, 4.8); // 4.8 km
        Cycling cyclingActivity = new Cycling(new DateTime(2022, 11, 4), 60, 20.0); // 20 kph
        Swimming swimmingActivity = new Swimming(new DateTime(2022, 11, 5), 45, 30); // 30 laps

        // Add activities to the list
        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        // Create another set of activities for variety
        Running runningActivity2 = new Running(new DateTime(2023, 7, 20), 45, 7.5); // 7.5 km
        Cycling cyclingActivity2 = new Cycling(new DateTime(2023, 7, 21), 90, 25.5); // 25.5 kph
        Swimming swimmingActivity2 = new Swimming(new DateTime(2023, 7, 22), 60, 40); // 40 laps

        activities.Add(runningActivity2);
        activities.Add(cyclingActivity2);
        activities.Add(swimmingActivity2);


        // Iterate through the list and display summaries
        Console.WriteLine("\n--- Activity Summaries ---");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nProgram finished. Press any key to exit if running in a standalone console.");
        // Console.ReadKey(); // Uncomment if running directly and want to pause
    }
}