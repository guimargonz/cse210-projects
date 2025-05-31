// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create Video 1
        Video video1 = new Video("C# TuTorial for Beginners", "Tech With Tim", 7200); // 2 hours
        video1.AddComment("Alice", "Great tutorial, very clear!");
        video1.AddComment("Bob", "Helped me a lot, thanks!");
        video1.AddComment("Charlie", "Could you do a video on advanced topics?");
        videos.Add(video1);

        // Create Video 2
        Video video2 = new Video("Funny Cat Compilation", "CutePets", 300); // 5 minutes
        video2.AddComment("Dave", "My cat does the same thing lol!");
        video2.AddComment("Eve", "So adorable!");
        video2.AddComment(new Comment("Frank", "ROFL, best compilation ever.")); // Using the other AddComment overload
        video2.AddComment("Grace", "I needed this today.");
        videos.Add(video2);

        // Create Video 3
        Video video3 = new Video("Learn Python in 10 Hours", "Code Master", 36000); // 10 hours
        video3.AddComment("Heidi", "Very comprehensive, but a bit fast.");
        video3.AddComment("Ivan", "Good starting point for Python.");
        video3.AddComment("Judy", "Amazing content!");
        videos.Add(video3);
        
        // Create Video 4 (optional, as per "3-4 videos")
        Video video4 = new Video("SpaceX Starship Update", "Everyday Astronaut", 1800); // 30 minutes
        video4.AddComment("Mallory", "Incredible engineering!");
        video4.AddComment("Trent", "To the Moon!");
        videos.Add(video4);


        // Iterate through the list of videos and display their details
        Console.WriteLine("--- YouTube Video and Comment Tracker ---");
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }

        Console.WriteLine("\nProgram finished. Press any key to exit if running in a standalone console.");
        // Console.ReadKey(); // Uncomment if you need to pause the console when running directly
    }
}