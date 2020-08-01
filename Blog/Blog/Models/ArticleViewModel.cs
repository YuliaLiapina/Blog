using System;

namespace Blog.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public AuthorViewModel Author { get; set; }
    }
}