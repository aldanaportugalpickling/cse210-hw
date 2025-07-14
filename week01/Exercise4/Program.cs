using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");

            string text = Console.ReadLine();
            userNumber = int.Parse(text);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        //Execute the sum:
        int sum = 0;

        foreach (int number in numbers)
        {
            sum = sum + number;
        }

        Console.WriteLine($"The sum is: {sum}");

        //The average of the numbers in the list:

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        //Find the maximum or largest number in the list.

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");

        //Find the minimum positive number: 
        //Optional
        int minPositive = int.MaxValue;

        foreach (int number in numbers)
        {
            if (number > 0 && number < minPositive)
            {
                minPositive = number;
            }
        }

        Console.WriteLine($"The smallest positive number is: {minPositive}");

        //sorted list.

        numbers.Sort();

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

    }
}