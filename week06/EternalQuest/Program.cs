using System;
//This program meets all the requirements of the project, including abstraction, encapsulation, inheritance, polymorphism, and proper functionality for all goal types.
// I added motivational messages that appear each time the user records progress on a goal.

class Program
{
    static void Main(string[] args)
    {
        GoalManager g1 = new GoalManager();
        g1.Start();
    }
}