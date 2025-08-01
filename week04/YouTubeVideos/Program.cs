using System;

class Program
{
    static void Main(string[] args)
    {
        Video v1 = new Video("Learn JavaScript", "Aldana Portugal", 120);
        Video v2 = new Video("Learn CSS", "Brenda Portugal", 350);
        Video v3 = new Video("HTML", "Camila Portugal", 560);


        v1.AddComment(new Comment("John", "Amazing tutorial, I finally understand it!"));
        v1.AddComment(new Comment("Travis", "Thank you, this was very helpful!"));
        v1.AddComment(new Comment("Belly", "Looking forward to the next part."));

        v2.AddComment(new Comment("Julio", "Super clear and easy to follow!"));
        v2.AddComment(new Comment("Adrian", "This saved me hours of confusion, great job."));
        v2.AddComment(new Comment("Noah", "I love this tutorial!"));

        v3.AddComment(new Comment("Oliver", "Great explanation of HTML tags! Now I understand how to structure a webpage."));
        v3.AddComment(new Comment("Evelyn", "Can you make a video about forms in HTML next?"));
        v3.AddComment(new Comment("Sophia", "This was so helpful! Now I can build my first website."));


        List<Video> videos = new List<Video>
        {
            v1, v2, v3
        };

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}