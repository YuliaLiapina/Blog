using AutoMapper;
using BusinessLayer.Models;
using DAL;
using DAL.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class BlogManager
    {
        public readonly BlogRepository _blogRepository;

        private readonly Mapper _mapper;
        public BlogManager()
        {
            _blogRepository = new BlogRepository();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleModel>().ReverseMap();
                cfg.CreateMap<Author, AuthorModel>().ReverseMap();
            });
            _mapper = new Mapper(conf);
        }

        public IList<AuthorModel> GetAllAuthors()
        {
            var listAuthors = _blogRepository.GetAllAuthors();

            var result = _mapper.Map<IList<AuthorModel>>(listAuthors);

            return result;
        }
        public IList<ArticleModel> GetAllArticles()
        {
            var listArticles = _blogRepository.GetAllArticles();

            var result = _mapper.Map<IList<ArticleModel>>(listArticles);

            return result;
        }

        public void AddArticle(ArticleModel article)
        {
            var mapArticle = _mapper.Map<Article>(article);

            _blogRepository.AddArticle(mapArticle);

        }

        public ArticleModel GetArticleById(int id)
        {
            var article = _blogRepository.GetArticleById(id);
            var articleModel= _mapper.Map<ArticleModel>(article);

            return articleModel;
        }

        public void EditArticle(ArticleModel articleModel)
        {
            var articleUpdate = _mapper.Map<Article>(articleModel);
            _blogRepository.UpdateArticle(articleUpdate);
        }

        public void RemoveArticleById(int id)
        {
            _blogRepository.RemoveArticleById(id);
        }

        public void AddAuthor(AuthorModel authorModel)
        {
            var mapAuthor = _mapper.Map<Author>(authorModel);

            _blogRepository.AddAuthor(mapAuthor);
        }

        public AuthorModel GetAuthorById(int id)
        {
            var author = _blogRepository.GetAuthorById(id);
            var authorModel = _mapper.Map<AuthorModel>(author);

            return authorModel;
        }

        public void EditAuthor(AuthorModel authorModel)
        {
            var authorUpdate = _mapper.Map<Author>(authorModel);
            _blogRepository.UpdateAuthor(authorUpdate);
        }

        public void RemoveAuthorById(int id)
        {
            _blogRepository.RemoveAuthorById(id);
        }
    }
}
