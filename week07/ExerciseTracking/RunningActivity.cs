public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(string date, double duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }


    public override double GetSpeed()
    {
        double speed = (_distance / GetDuration()) * 60;
        return speed;
    }

    public override double GetPace()
    {
        double pace = GetDuration() / _distance;
        return pace;
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Running ({GetDuration()} Min) - Distance: {_distance} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}