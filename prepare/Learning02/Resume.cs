using System;
using System.Collections.Generic;

public class Resume
{
    public string _personName;
    public List<Job> _jobs = new List<Job>();

    // Method to display the resume
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_personName}");
        Console.WriteLine("Job Experience:");
        
        // Iterate over the list of jobs and display each one
        foreach (Job job in _jobs)
        {
            job.DisplayJobInfo();
        }
    }
}