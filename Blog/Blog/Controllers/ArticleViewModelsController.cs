using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Blog.Models;
using BusinessLayer;
using BusinessLayer.Models;

namespace Blog.Controllers
{
    public class ArticleViewModelsController : Controller
    {
        private readonly BlogManager _blogManager;
        private readonly Mapper _mapper;
        public ArticleViewModelsController()
        {
            _blogManager = new BlogManager();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleModel, ArticleViewModel>().ReverseMap();
                cfg.CreateMap<AuthorModel, AuthorViewModel>().ReverseMap();
            });
            _mapper = new Mapper(conf);
        }

        // GET: ArticleViewModels
        public ActionResult Index()
        {
            var listArticles = _blogManager.GetAllArticles();
            var listArticlesViewModel = _mapper.Map<IList<ArticleViewModel>>(listArticles);

            return View(listArticlesViewModel);
        }

        // GET: ArticleViewModels/Details/5
        public ActionResult Details(int id)
        {
            var articleModel = _blogManager.GetArticleById(id);
            var articleViewModel = _mapper.Map<ArticleViewModel>(articleModel);

            return View(articleViewModel);
        }

        // GET: ArticleViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Body,PublishDate")] ArticleViewModel articleViewModel)
        {
            if (ModelState.IsValid)
            {
                var articleModel = _mapper.Map<ArticleModel>(articleViewModel);
                _blogManager.AddArticle(articleModel);

                return RedirectToAction("Index");
            }

            return View(articleViewModel);
        }

        // GET: ArticleViewModels/Edit/5
        public ActionResult Edit(int id)
        {
            var articleModel = _blogManager.GetArticleById(id);
            var articleViewModel = _mapper.Map<ArticleViewModel>(articleModel);
            
            return View(articleViewModel);
        }

        // POST: ArticleViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Body,PublishDate")] ArticleViewModel articleViewModel)
        {
            var articleModel = _mapper.Map<ArticleModel>(articleViewModel);
            _blogManager.EditArticle(articleModel);

            return RedirectToAction("Index");
            //return View(articleViewModel);
        }

        // GET: ArticleViewModels/Delete/5
        public ActionResult Delete(int id)
        {
            var articleModel = _blogManager.GetArticleById(id);
            var articleViewModel = _mapper.Map<ArticleViewModel>(articleModel);

            return View(articleViewModel);
        }

        // POST: ArticleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _blogManager.RemoveArticleById(id);

            return RedirectToAction("Index");
        }
    }
}
