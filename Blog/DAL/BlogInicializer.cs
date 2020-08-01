using DAL.Models;
using System;
using System.Data.Entity;

namespace DAL
{
    public class BlogInicializer: CreateDatabaseIfNotExists<BlogContext>/*DropCreateDatabaseAlways<BlogContext>*/
    {
        protected override void Seed(BlogContext context)
        {
            Article article1 = new Article() { Name = "Article 1", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", PublishDate = DateTime.Now };
            Article article2 = new Article() { Name = "Article 2", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", PublishDate = DateTime.Now };
            Article article3 = new Article() { Name = "Article 3", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", PublishDate = DateTime.Now };
            Article article4 = new Article() { Name = "Article 4", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", PublishDate = DateTime.Now };
            Article article5 = new Article() { Name = "Article 5", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", PublishDate = DateTime.Now };

            Author author1 = new Author() { FIrstName = "Eldar", LastName = "Murtazin" };
            Author author2 = new Author() { FIrstName = "Artur", LastName = "Pirozkov" };

            author1.Articles.Add(article1);
            author1.Articles.Add(article2);
            author1.Articles.Add(article3);

            author2.Articles.Add(article4);
            author2.Articles.Add(article5);

            context.Articles.Add(article1);
            context.Articles.Add(article2);
            context.Articles.Add(article3);
            context.Articles.Add(article4);
            context.Articles.Add(article5);

            context.Authors.Add(author1);
            context.Authors.Add(author2);

            context.SaveChanges();
        }
    }
}
