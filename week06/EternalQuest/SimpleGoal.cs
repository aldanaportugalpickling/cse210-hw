using System;
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{IsComplete()}";
    }

    public static SimpleGoal CreateFromString(string data)
    {
        string[] parts = data.Split(',');
        string name = parts[0];
        string description = parts[1];
        int points = int.Parse(parts[2]);
        bool isComplete = bool.Parse(parts[3]);

        SimpleGoal goal = new SimpleGoal(name, description, points);

        if (isComplete)
        {
            goal.RecordEvent();
        }

        return goal;
    }
}