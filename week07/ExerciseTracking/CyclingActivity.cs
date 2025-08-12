public class CyclingActivity : Activity
{
    private double _speed;
    public CyclingActivity(string date, double duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (GetDuration() / 60);
    }
    public override double GetPace()
    {
        double pace = GetDuration() / GetDistance();
        return pace;
    }
    public override string GetSummary()
    {
        return $"{GetDate()} Cycling ({GetDuration()} Min) - Distance: {GetDistance():F2} km, Speed: {_speed} kph, Pace: {GetPace():F2} min per km";
    }
}
