public abstract class Activity
{
    private string _date;
    private double _duration;

    public Activity(string date, double duration)
    {
        _date = date;
        _duration = duration;
    }
    public string GetDate()
    {
        return _date;
    }

    public double GetDuration()
    {
        return _duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{GetDate()} {this.GetType().Name.Replace("Activity", "")} " +
              $"({GetDuration()} Min) - Distance: {GetDistance():F2} km, " +
              $"Speed: {GetSpeed():F2} kph, " +
              $"Pace: {GetPace():F2} min per km";
    }

}
