public class CyclingActivity : Activity
{
    private  readonly double _speed;
    public CyclingActivity(string date, double duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (GetDuration() / 60.0);
    }
   
    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return GetDistance() > 0 ? GetDuration() / GetDistance() : 0;
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Cycling ({GetDuration()} Min) - Distance: {GetDistance():F2} km, Speed: {GetSpeed()} kph, Pace: {GetPace():F2} min per km";
    }
}
