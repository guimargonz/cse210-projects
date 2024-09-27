using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold the numbers
        List<int> numbers = new List<int>();

        // Ask the user for numbers and add them to the list
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            // Add the number to the list if it's not zero
            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Core Requirements
        // 1. Compute the sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        // 2. Compute the average
        double average = 0;
        if (numbers.Count > 0)
        {
            average = (double)sum / numbers.Count;
        }
        Console.WriteLine($"The average is: {average}");

        // 3. Find the largest number
        int max = int.MinValue;
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenges
        // 1. Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < smallestPositive)
            {
                smallestPositive = num;
            }
        }
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // 2. Sort the list and display the sorted numbers
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}