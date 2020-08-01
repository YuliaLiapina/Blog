using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class AuthorModel
    {
        public AuthorModel()
        {
            Articles = new List<ArticleModel>();
        }
        public int Id { get; set; }
        public string FIrstName { get; set; }
        public string LastName { get; set; }
        public IList<ArticleModel> Articles { get; set; }
    }
}
