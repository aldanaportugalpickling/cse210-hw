using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {

        string answer = "yes";

        while (answer == "yes")
        {
            //Ask the computer a random number.

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guessNumber = -1;

            Console.WriteLine("Guess the magic number between 1 and 100!");

            //Added a loop and if statements:

            while (magicNumber != guessNumber)
            {
                Console.WriteLine("What is your guess ? ");
                guessNumber = int.Parse(Console.ReadLine()); //Convert string to number.


                if (magicNumber > guessNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guessNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it!");
                }
            }

            Console.WriteLine("Do you want to play again? ");
            answer = Console.ReadLine();

        }

        Console.WriteLine("Thanks for playing!");

    }
}