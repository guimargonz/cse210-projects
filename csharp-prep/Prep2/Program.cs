using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string gpa = "";
        string sign = "";

        // Determine the letter grade
        if (grade >= 90)
        {
            gpa = "A";
        }
        else if (grade >= 80)
        {
            gpa = "B";
        }
        else if (grade >= 70)
        {
            gpa = "C";
        }
        else if (grade >= 60)
        {
            gpa = "D";
        }
        else
        {
            gpa = "F";
        }

        // Determine the sign for the grade
        if (gpa != "F")
        {
            int lastDigit = grade % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        //Handle A+ and F+ / F- cases
        if (gpa == "A" && sign == "+")
        {
            sign = ""; // A+ is not a valid variation for A
        }
        else if (gpa == "F")
        {
            sign = ""; // No variations for F
        }

        // Display the grade
        Console.WriteLine($"Your grade is: {gpa}{sign}");

        // Determine pass/fail message
        if (grade >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}
