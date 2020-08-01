using System;

namespace DAL.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public Author Author { get; set; }
    }
}
