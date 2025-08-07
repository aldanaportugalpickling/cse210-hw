public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "-- Think of a time when you stood up for someone else. --",
        "-- Think of a time when you did something really difficult. --",
        "-- Think of a time when you helped someone in need. --",
        "-- Think of a time when you did something truly selfless. --",
    };
    private List<string> _questions = new List<string>
    {
        "> Why was this experience meaningful to you?",
        "> Have you ever done anything like this before?",
        "> How did you get started?",
        "> How did you feel when it was complete?",
        "> What made this time different than other times when you were not as successful?",
        "> What is your favorite thing about this experience?",
        "> What could you learn from this experience that applies to other situations?",
        "> What did you learn about yourself through this experience?",
        "> How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        DisplayPrompt();
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue. ");
        string user = Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this expierence.");
        Console.Write("You may beging in: ");
        ShowCountDown(5);
        Console.Clear();

        DisplayQuestion();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestion()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(10);
        }
    }
}