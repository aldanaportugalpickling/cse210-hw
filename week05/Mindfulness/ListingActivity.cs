public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
        "--Who are people that you appreciate? --",
        "--What are personal strengths of yours?--",
        "--Who are people that you have helped this week?--",
        "--Who are some of your personal heroes?--",
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {

    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine(GetRandomPrompt());
        Console.Write("You may beging in: ");
        ShowCountDown(5);
        GetListFromUser();
        Console.WriteLine($"You listed {_count} items!");
        Console.WriteLine();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> _items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            _items.Add(input);
        }

        _count = _items.Count();

        return _items;
    }

}
