using DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL
{
    public class BlogRepository
    {
        public IList<Article> GetAllArticles()
        {
            using (BlogContext context = new BlogContext())
            {
                var listArticles = context.Articles.Include(article => article.Author).ToList();

                return listArticles;
            }
        }

        public void AddArticle(Article article)
        {
            using (BlogContext context = new BlogContext())
            {
                context.Articles.Add(article);

                context.SaveChanges();
            }
        }
        public Article GetArticleById(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Articles.
                    Include(article => article.Author).
                    First(article => article.Id == id);
            }
        }

        public void UpdateArticle(Article article)
        {
            using (var context = new BlogContext())
            {
                var newArticle = context.Articles.Include(a => a.Author).FirstOrDefault(a => a.Id == article.Id);

                context.Articles.Attach(newArticle);
                newArticle.Name = article.Name;
                newArticle.Body = article.Body;
                newArticle.PublishDate = article.PublishDate;

                context.Entry(newArticle).State = EntityState.Modified;

                context.Articles.AddOrUpdate(article);

                context.SaveChanges();
            }

        }

        public void RemoveArticleById(int id)
        {
            using (var context = new BlogContext())
            {
                context.Articles.Remove(context.Articles.First(a => a.Id == id));

                context.SaveChanges();
            }
        }


        public IList<Author> GetAllAuthors()
        {
            using (BlogContext context = new BlogContext())
            {
                var listAuthors = context.Authors.Include(author => author.Articles).ToList();

                return listAuthors;
            }
        }

        public void AddAuthor(Author author)
        {
            using (BlogContext context = new BlogContext())
            {
                context.Authors.Add(author);

                context.SaveChanges();
            }
        }
        public Author GetAuthorById(int id)
        {
            using (var context = new BlogContext())
            {
                return context.Authors.Include(author => author.Articles).First(author => author.Id == id);
            }
        }

        public void UpdateAuthor(Author author)
        {
            using (var context = new BlogContext())
            {
                var newAuthor = context.Authors.Include(a => a.Articles).FirstOrDefault(a => a.Id == author.Id);

                context.Authors.Attach(newAuthor);
                newAuthor.FIrstName = author.FIrstName;
                newAuthor.LastName = author.LastName;

                context.Entry(newAuthor).State = EntityState.Modified;

                context.Authors.AddOrUpdate(author);

                context.SaveChanges();
            }
        }

        public void RemoveAuthorById(int id)
        {
            using (var context = new BlogContext())
            {
                var author = context.Authors.FirstOrDefault(a => a.Id == id);

                if (author != null)
                {
                    context.Authors.Remove(author);
                    context.SaveChanges();
                }
            }
        }
    }
}
