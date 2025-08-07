//I added a class that is the stretch activity
//When the user enters a number for seconds, that number is divided by the list count, 
//so that each stretch can be displayed in the time required by the user
using System;

class Program
{
    static void Main(string[] args)
    {
        int userChoice = 0;

        while (userChoice != 5)
        {
            Console.WriteLine("Menu Options");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Start stretching activity");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");
            userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1)
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();

            }

            else if (userChoice == 2)
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();

            }

            else if (userChoice == 3)
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();

            }

            else if (userChoice == 4)
            {
                StretchingActivity stretchingActivity = new StretchingActivity();
                stretchingActivity.Run();
            }

            else if (userChoice == 5)
            {
                Console.WriteLine("Thank you for using the program!");
            }

            else
            {
                Console.WriteLine("Please enter a number from the menu");
                Console.WriteLine();
            }

        }
    }
}