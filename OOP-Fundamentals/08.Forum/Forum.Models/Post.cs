using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public ICollection<int> ReplyIds { get; set; }

        public Post(int id, string title, string content,int catId,int authorId,IEnumerable<int> posts)
        {
            this.Id = id;
            this.Title = title;
            this.Content= content;
            this.CategoryId = catId;
            this.AuthorId = authorId;
            this.ReplyIds = new List<int>(posts);
        }
    }
}
