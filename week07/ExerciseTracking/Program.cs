using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        DateTime theCurrentTime = DateTime.Now;
        string date = DateTime.Now.ToString("dd MMM yyyy");

        List<Activity> activities = new List<Activity>();

        RunningActivity a1 = new RunningActivity(date, 30, 4.8);
        activities.Add(a1);

        RunningActivity a2 = new RunningActivity(date, 40, 5.3);
        activities.Add(a2);

        CyclingActivity a3 = new CyclingActivity(date, 30, 6.9);
        activities.Add(a3);

        CyclingActivity a4 = new CyclingActivity(date, 20, 2.8);
        activities.Add(a4);

        SwimmingActivity a5 = new SwimmingActivity(date, 60, 15);
        activities.Add(a5);

        SwimmingActivity a6 = new SwimmingActivity(date, 40, 7);
        activities.Add(a6);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine();
    }
}