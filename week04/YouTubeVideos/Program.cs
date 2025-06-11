using System;
using System.Collections.Generic;

// Comment class represents a comment on a video
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Video class represents a YouTube video with comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    // Add a comment to this video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Return the number of comments on this video
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Return the list of comments
    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold videos
        List<Video> videos = new List<Video>();

        // Create first video and add comments
        Video video1 = new Video("Learn to play the Bass Guitar in 2 hours", "MattAcademy", 600);
        video1.AddComment(new Comment("Mike", "Great video, thanks!"));
        video1.AddComment(new Comment("Romeo", "Very helpful for beginners like me."));
        video1.AddComment(new Comment("Jackie", "Could you cover Minors Usage next?"));

        // Create second video and add comments
        Video video2 = new Video("Top 10 Blogging Tips", "TechArena", 900);
        video2.AddComment(new Comment("Dave", "These tips really improved my channel!"));
        video2.AddComment(new Comment("Eva", "Thanks for sharing."));
        video2.AddComment(new Comment("Frank", "I disagree about tip #5."));
        video2.AddComment(new Comment("Grace", "Awesome content as always!"));

        // Create third video and add comments
        Video video3 = new Video("Risk Management Tips", "SafetyHub", 300);
        video3.AddComment(new Comment("Hannah", "Nice Video!"));
        video3.AddComment(new Comment("Mirabel", "Easy to learn."));
        video3.AddComment(new Comment("Jack", "Thanks for the tips!"));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Iterate through each video and display details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthInSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();  // Blank line between videos
        }
    }
}
