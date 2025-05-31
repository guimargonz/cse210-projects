// Program.cs
using System;
using System.Collections.Generic; // For List if using a library of scriptures

class Program
{
    static void Main(string[] args)
    {
        // --- Start of Exceeding Requirements Section ---
        // Description of exceeding requirements:
        // 1. Scripture Library: The program uses a list of scriptures and picks one randomly.
        // 2. Variable Hiding: Hides a variable number of words (1 to 3) each time for variety.
        // 3. Intelligent Hiding: The HideRandomWords method in Scripture.cs attempts to only
        //    hide words that are not already hidden, making the process more efficient.
        // --- End of Exceeding Requirements Section ---

        List<Scripture> scriptureLibrary = InitializeScriptureLibrary();
        Random random = new Random();
        Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        int wordsToHidePerTurn = 3; // Or make this variable, e.g., random.Next(1, 4)

        while (true)
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue, or type 'quit' to finish.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (currentScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText()); // Show final hidden state
                Console.WriteLine("\nAll words are hidden. Well done!");
                break;
            }

            // Exceeding: variable number of words to hide
            wordsToHidePerTurn = random.Next(1, 4); // Hide 1, 2, or 3 words
            currentScripture.HideRandomWords(wordsToHidePerTurn);

            // Check again if all hidden AFTER hiding, to end immediately if so
            if (currentScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText()); // Show final hidden state
                Console.WriteLine("\nAll words are hidden. Well done!");
                break;
            }
        }

        Console.WriteLine("Program ended. Press any key to exit.");
        Console.ReadKey();
    }

    // Helper method for Exceeding Requirement: Scripture Library
    static List<Scripture> InitializeScriptureLibrary()
    {
        List<Scripture> library = new List<Scripture>();

        Reference ref1 = new Reference("John", 3, 16);
        Scripture s1 = new Scripture(ref1, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        library.Add(s1);

        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        Scripture s2 = new Scripture(ref2, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
        library.Add(s2);

        Reference ref3 = new Reference("Philippians", 4, 13);
        Scripture s3 = new Scripture(ref3, "I can do all things through Christ which strengtheneth me.");
        library.Add(s3);
        
        Reference ref4 = new Reference("Alma", 32, 21);
        Scripture s4 = new Scripture(ref4, "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.");
        library.Add(s4);

        // Add more scriptures here
        return library;
    }
}