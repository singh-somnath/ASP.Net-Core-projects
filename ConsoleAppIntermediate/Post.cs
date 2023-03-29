using System;

namespace ConsoleAppIntermediate
{
    public class Post
    {
        private int Id { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private DateTime CreatedDate { get; set; }
        private int Vote { get; set; }

        public Post(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            Vote = 0;

        }

        public void UpVote()
        {
            Vote++;
        }

        public void DownVote()
        {
            Vote--;
        }

        public void CurrentVoteValue()
        {
            Console.WriteLine("Post Title - " + Title);
            Console.WriteLine("Current Post Vote - " + Vote);
        }
    }
}