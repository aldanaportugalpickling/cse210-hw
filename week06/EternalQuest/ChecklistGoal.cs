using System;
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    protected int _bonus;
    private bool _bonusGiven; 


    public bool BonusGiven 
    {
        get { return _bonusGiven; }
        set { _bonusGiven = value; }
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
        _bonusGiven = false;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;


            if (_amountCompleted == _target && !_bonusGiven)
            {
              
                Console.WriteLine($"Congratulations! You have completed the checklist goal and earned a bonus of {_bonus} points!");
                _bonusGiven = true;
            }
        }
    }
    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted},{_bonusGiven}";
    }

    public static ChecklistGoal CreateFromString(string data)
    {
        string[] parts = data.Split(',');
        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);
        int bonus = int.Parse(parts[3]);
        int target = int.Parse(parts[4]);
        int amountCompleted = int.Parse(parts[5]);
        bool bonusGiven = parts.Length > 6 && bool.Parse(parts[6]);
       

        ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
        goal._amountCompleted = amountCompleted;
        goal._bonusGiven = bonusGiven;
        return goal;
    }


    public int GetBonus()
    {
        return _bonus;
    }
}