using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scripturesList = new List<Scripture>()
        {
            new Scripture(new Reference ("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths"),
            new Scripture(new Reference ("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            new Scripture(new Reference ("Alma", 8, 12), "And now we know that because we are not of thy church we know that thou hast no power over us; and thou hast delivered up the judgment-seat unto Nephihah; therefore thou art not the chief judge over us."),
            new Scripture(new Reference ("Isaiah", 58, 6, 7), "Is not this the fast that I have chosen? to loose the bands of wickedness, to undo the heavy burdens, and to let the oppressed go free, and that ye break every yoke? Is it not to deal thy bread to the hungry, and that thou bring the poor that are cast out to thy house? when thou seest the naked, that thou cover him; and that thou hide not thyself from thine own flesh?")
        };

        Random randomScripture = new Random();
        Scripture scripture = scripturesList[randomScripture.Next(scripturesList.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("Please enter to continue or type 'quit' to finish: ");
            string user = Console.ReadLine();

            if (user == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("All words are now hidden. The game is over!");
                break;
            }
        }
    }
}