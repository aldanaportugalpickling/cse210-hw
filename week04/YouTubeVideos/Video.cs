public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSec;
    private List<Comment> _commentsList = new List<Comment>();

    public Video(string title, string author, int lengthInSec)
    {
        _title = title;
        _author = author;
        _lengthInSec = lengthInSec;

    }

    public void AddComment(Comment comment)
    {
        _commentsList.Add(comment);
    }

    public int NumberComments()
    {
        return _commentsList.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title} - Author: {_author}");
        Console.WriteLine($"Length: {_lengthInSec} seconds");
        Console.WriteLine($"Number of Comments: {NumberComments()} ");
        Console.WriteLine("Comments: ");

        foreach (Comment comment in _commentsList)
        {
            Console.WriteLine(comment.GetComment());
        }
        Console.WriteLine();

    }
}