using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("Abstraction Explained", "Emmanuel Ankomah", 900);
        v1.AddComment(new Comment("Grace", "Perfect timing for my assignment."));
        v1.AddComment(new Comment("Henry", "Short and clear."));
        v1.AddComment(new Comment("Ivy", "Liked and shared."));
        videos.Add(v1);

        Video v2 = new Video("Conditionals", "Justice Mensah", 540);
        v2.AddComment(new Comment("Sarah", "If/else finally makes sense."));
        v2.AddComment(new Comment("Noah", "Well explained."));
        v2.AddComment(new Comment("Olivia", "Helpful."));
        videos.Add(v2);

        Video v3 = new Video("Loops", "Amos Wallace", 660);
        v3.AddComment(new Comment("Peter", "For and while loops are clear now."));
        v3.AddComment(new Comment("Mary", "Concise and useful."));
        v3.AddComment(new Comment("Rose", "Bookmarked."));
        videos.Add(v3);

        Video v4 = new Video("Functions", "Dinah Morrison", 780);
        v4.AddComment(new Comment("Victor", "Functions explained well."));
        v4.AddComment(new Comment("Wendy", "Helped a lot."));
        v4.AddComment(new Comment("Grace", "Subscribed."));
        videos.Add(v4);

        Video v5 = new Video("Version Control", "Abraham Osei", 900);
        v5.AddComment(new Comment("Eli", "Git makes sense now."));
        v5.AddComment(new Comment("John", "Great intro to version control."));
        v5.AddComment(new Comment("Mavis", "Thanks."));
        videos.Add(v5);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }

    }
}