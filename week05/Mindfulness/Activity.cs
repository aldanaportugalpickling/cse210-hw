public class Activity
{

    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write($"How Long, in seconds would you like for your session?: ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(5);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\", "|", "/", "-", "\\", "|", "/", "-", "\\" };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i > spinner.Count)
            {
                i = 0;
            }
        }

    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }
}