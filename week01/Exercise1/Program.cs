using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        //Ask for the user their name

        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        Console.Write($"What is your last name? ");
        string last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}