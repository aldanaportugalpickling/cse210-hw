using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{ 
    private List<Goal> _goals;

    private int _score;
    private List<string> motivationalMessages = new List<string>()
    {
        "Each day is a new chance to improve.",
        "Don't give up, you're making progress!",
        "Consistency is the key to success.",
        "Every step brings you closer to your goal.",
        "You are stronger than you think!",
        "Keep it up, you're doing great!"
    };

    Random random = new Random();
    private string GetRandomMotivationalMessage()
    {
        int index = random.Next(motivationalMessages.Count);
        return motivationalMessages[index];
    }

       public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int userOption = 0;

        while (userOption != 6)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out userOption))
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
                continue;
            }
            Console.WriteLine();

            switch (userOption)
            {
                case 1:
                    CreateGoal();
                    Console.WriteLine();
                    break;
                case 2:
                    ListGoalDetails();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.Write("What is the filename for the goal file? ");
                    SaveGoals(Console.ReadLine());
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Write("What is the filename for the goal file? ");
                    LoadGoals(Console.ReadLine());
                    Console.WriteLine();
                    break;
                case 5:
                    RecordEvent();
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("Thank you for playing!\n");
                    break;
                default:
                    Console.WriteLine("Please enter a choice from the menu.\n");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.\n");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private int AskGoalType()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create?: ");

        if (int.TryParse(Console.ReadLine(), out int goalType) && goalType >= 1 && goalType <= 3)
        {
            return goalType;
        }

        Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.\n");
        return -1;
    }

    public void CreateGoal()
    {
        int goalType = AskGoalType();
        if (goalType == -1) return;

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid input. Please enter a valid number for points.\n");
            return;
        }

        if (goalType == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            if (!int.TryParse(Console.ReadLine(), out int target))
            {
                Console.WriteLine("Invalid number for target.\n");
                return;
            }

            Console.Write("What is the bonus for accomplishing it that many times? ");
            if (!int.TryParse(Console.ReadLine(), out int bonus))
            {
                Console.WriteLine("Invalid number for bonus.\n");
                return;
            }

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.\n");
            return;
        }

        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        if (!int.TryParse(Console.ReadLine(), out int goalIndex) || goalIndex < 1 || goalIndex > _goals.Count)
        {
            Console.WriteLine("Invalid selection.\n");
            return;
        }

        Goal selectedGoal = _goals[goalIndex - 1];
        selectedGoal.RecordEvent();

        int earnedPoints = selectedGoal.GetPoints();


        if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete() && !checklistGoal.BonusGiven)
        {
            earnedPoints += checklistGoal.Bonus;
            checklistGoal.BonusGiven = true;
        }

        _score += earnedPoints;
        Console.WriteLine($"You earned {earnedPoints} points for: {selectedGoal.GetDetailsString()}");
        DisplayPlayerInfo();

        Console.WriteLine("---------------------------------------------------------------------------------------");
        Console.WriteLine(GetRandomMotivationalMessage());
        Console.WriteLine();
    }

    public void SaveGoals(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("This file does not exist.\n");
            return;
        }

        _goals.Clear();

        using (StreamReader reader = new StreamReader(file))
        {
            string scoreLine = reader.ReadLine();
            if (!int.TryParse(scoreLine, out _score))
            {
                Console.WriteLine("Invalid score data in file.\n");
                return;
            }

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(':', 2);
                if (parts.Length < 2) continue;

                string type = parts[0];
                string data = parts[1];

                if (type == "SimpleGoal")
                    _goals.Add(SimpleGoal.CreateFromString(data));
                else if (type == "EternalGoal")
                    _goals.Add(EternalGoal.CreateFromString(data));
                else if (type == "ChecklistGoal")
                    _goals.Add(ChecklistGoal.CreateFromString(data));
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}
