public class SwimmingActivity : Activity
{
    private double _laps;

    public SwimmingActivity(string date, double duration, double laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distance = (_laps * 50) / 1000;
        return distance;
    }

    public override double GetSpeed()
    {
        double speed = (GetDistance() / GetDuration()) * 60;
        return speed;
    }

    public override double GetPace()
    {
        double pace = GetDuration() / GetDistance();
        return pace;
    }
}