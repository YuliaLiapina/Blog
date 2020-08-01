using System.Collections.Generic;

namespace DAL.Models
{
    public class Author
    {
        public Author()
        {
            Articles = new List<Article>();
        }
        public int Id { get; set; }
        public string FIrstName { get; set; }
        public string LastName { get; set; }
        public IList<Article> Articles {get;set;}
    }
}
