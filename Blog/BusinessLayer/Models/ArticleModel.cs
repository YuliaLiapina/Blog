using System;

namespace BusinessLayer.Models
{
   public class ArticleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public AuthorModel Author { get; set; }
    }
}
