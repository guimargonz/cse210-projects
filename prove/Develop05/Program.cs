// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // --- Start of Exceeding Requirements Section (Example) ---
        // Description of exceeding requirements:
        // 1. Enhanced Animations: The spinner and countdown are slightly more elaborate.
        // 2. More Prompts/Questions: Added a few more diverse prompts and questions to lists.
        // 3. Log Activity Count (Conceptual): If this were extended, one could add a static counter
        //    in Program.cs or a dedicated log class to track how many times each activity is run.
        //    For this submission, the structure is here to show where it could be added,
        //    but full log file saving/loading is not implemented to keep focus on core.
        //    (Actual logging not implemented to keep core simple for this assignment version)
        // --- End of Exceeding Requirements Section ---


        string choice = "";
        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;
                case "2":
                    ReflectionActivity reflecting = new ReflectionActivity();
                    reflecting.Run();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case "4":
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1500); // Pause to see message
                    break;
            }
        }
    }
}