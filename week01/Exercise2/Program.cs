using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input); //convert the string to number 

        string letter = "";
        string sign = "";
        //Now type a series of statements to print out the appropriate letter grade. 

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        //Calculate the last digit "+" or "-". 
        int lastDigit = percentage % 10;

        //Assign only the sign "-" for A
        if (letter == "A")
        {
            if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }
        else if (letter == "F")
        {
            // F whitout sign
            sign = "";
        }
        else
        {

            // B, C and D
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        //Separate one statement to determine the grade percentage.
        if (percentage >= 70)
        {
            Console.WriteLine($"Well done, you passed with a {letter}{sign} ¡Keep it up!");
        }
        else
        {
            Console.WriteLine($"Your grade percentaje is {letter}. You did not pass, push yourself just a bit more next time, you've got this!");
        }
            
    }
}
