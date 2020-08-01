using System.Collections.Generic;
namespace Blog.Models
{
    public class AuthorViewModel
    {
        public AuthorViewModel()
        {
            Articles = new List<ArticleViewModel>();
        }
        public int? Id { get; set; }
        public string FIrstName { get; set; }
        public string LastName { get; set; }
        public IList<ArticleViewModel> Articles { get; set; }
    }
}