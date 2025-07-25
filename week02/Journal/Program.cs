// Journal Program - CSE 210 
//Added mood (feeling) to each journal entry.
// Added display shows total number of entries.
// Added a blank line has been added before displaying entries for better visualization and understanding.
//Added two ways to save and load the journal in CSV format and TXT format.
using System;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int choice = -1;

        while (choice != 0)

        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save journal to TXT file");
            Console.WriteLine("4. Load journal from TXT file");
            Console.WriteLine("5. Save journal to CSV file (extra)");
            Console.WriteLine("6. Load journal from CSV file (extra)");
            Console.WriteLine("0. Quit");
            Console.Write("what would you like to do? Select an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Console.Write("How do you feel today? ");
                    string mood = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(mood))
                    {
                        mood = "Unspecified";
                    }

                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToString("yyyy-MM-dd"),
                        _promptText = prompt,
                        _entryText = response,
                        _mood = mood
                    };
                    journal.AddEntry(newEntry);
                    break;

                case 2:
                    journal.DisplayAll();
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine(); 
                    break;

                case 3:
                    Console.Write("Enter filename to save (.txt): ");
                    string saveFileTXT = Console.ReadLine();
                    journal.SaveToFileTXT(saveFileTXT);
                    break;

                case 4:
                    Console.Write("Enter filename to load (.txt): ");
                    string loadFileTXT = Console.ReadLine();
                    journal.LoadFromFileTXT(loadFileTXT);
                    break;

                case 5:
                    Console.Write("Enter filename to save (.csv): ");
                    string saveFileCSV = Console.ReadLine();
                    journal.SaveToFileCSV(saveFileCSV);
                    break;

                case 6:
                    Console.Write("Enter filename to load (.csv): ");
                    string loadFileCSV = Console.ReadLine();
                    journal.LoadFromFileCSV(loadFileCSV);
                    break;

                case 0:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

    }
}