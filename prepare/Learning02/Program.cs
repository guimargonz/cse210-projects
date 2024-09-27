using System;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of Job and set the attributes
        Job job1 = new Job();
        job1._companyName = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._companyName = "Google";
        job2._jobTitle = "Data Analyst";
        job2._startYear = 2022;
        job2._endYear = 2024;

        // Create an instance of Resume and assign the person’s name
        Resume myResume = new Resume();
        myResume._personName = "Guilherme Gonzaga";

        // Add the jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the resume
        myResume.DisplayResume();
    }
}
