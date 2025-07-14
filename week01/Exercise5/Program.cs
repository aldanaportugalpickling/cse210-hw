using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {

        DisplayMessage();
        string name = PromptUserName();
        int number = PromptFavoriteNumber();
        DisplayResult(name, number);

    }


    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name:  ");
        string name = Console.ReadLine();
        return name;
        
    }

    static int PromptFavoriteNumber()
    {
        Console.WriteLine("Please enter your favorite number:  ");
        string text = Console.ReadLine();
        int number = int.Parse(text);
        return number;
    }

    static void DisplayResult(string name, int number)
    {
        int square = number * number;
        Console.WriteLine($"{name}, the square of your name is {square}");
    }
}