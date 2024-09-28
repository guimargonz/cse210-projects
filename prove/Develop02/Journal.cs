using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;  // Add this for JSON functionality

class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void WriteEntry()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        Entry newEntry = new Entry(DateTime.Now.ToShortDateString(), prompt, response);
        _entries.Add(newEntry);
        Console.WriteLine("Entry added!");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt}");
            Console.WriteLine(entry.Response);
            Console.WriteLine();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save (e.g., journal.json): ");
        string filename = Console.ReadLine();

        // Serialize the list of entries into a JSON string
        string jsonString = JsonSerializer.Serialize(_entries);

        // Write the JSON string to the file
        File.WriteAllText(filename, jsonString);
        Console.WriteLine("Journal saved to JSON!");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load (e.g., journal.json): ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            // Read the JSON string from the file
            string jsonString = File.ReadAllText(filename);

            // Deserialize the JSON string back into a list of entries
            _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
            Console.WriteLine("Journal loaded from JSON!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}