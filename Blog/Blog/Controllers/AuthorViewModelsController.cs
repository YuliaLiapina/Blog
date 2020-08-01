using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Blog.Models;
using BusinessLayer;
using BusinessLayer.Models;

namespace Blog.Controllers
{
    public class AuthorViewModelsController : Controller
    {
        private readonly BlogManager _blogManager;
        private readonly Mapper _mapper;
        public AuthorViewModelsController()
        {
            _blogManager = new BlogManager();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorModel, AuthorViewModel>().ReverseMap();
                cfg.CreateMap<ArticleModel, ArticleViewModel>().ReverseMap();
            });
            _mapper = new Mapper(conf);
        }

        // GET: AuthorViewModels
        public ActionResult Index()
        {
            var listAuthors = _blogManager.GetAllAuthors();
            var listAuthorsViewModel = _mapper.Map<IList<AuthorViewModel>>(listAuthors);

            return View(listAuthorsViewModel);
        }

        // GET: AuthorViewModels/Details/5
        public ActionResult Details(int id)
        {
            var authorModel = _blogManager.GetAuthorById(id);
            var authorViewModel = _mapper.Map<AuthorViewModel>(authorModel);

            return View(authorViewModel);
        }

        // GET: AuthorViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FIrstName,LastName")] AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                var authorModel = _mapper.Map<AuthorModel>(authorViewModel);
                _blogManager.AddAuthor(authorModel);

                return RedirectToAction("Index");
            }

            return View(authorViewModel);
        }


        // GET: AuthorViewModels/Edit/5
        public ActionResult Edit(int id)
        {
            var authorModel = _blogManager.GetAuthorById(id);
            var authorViewModel = _mapper.Map<AuthorViewModel>(authorModel);

            return View(authorViewModel);
        }

        // POST: AuthorViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FIrstName,LastName")] AuthorViewModel authorViewModel)
        {
            var authorModel = _mapper.Map<AuthorModel>(authorViewModel);
            _blogManager.EditAuthor(authorModel);

            return RedirectToAction("Index");
        }

        // GET: AuthorViewModels/Delete/5
        public ActionResult Delete(int id)
        {
            var authorModel = _blogManager.GetAuthorById(id);
            var authorViewModel = _mapper.Map<AuthorViewModel>(authorModel);

            return View(authorViewModel);
        }

        // POST: AuthorViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _blogManager.RemoveAuthorById(id);

            return RedirectToAction("Index");
        }
    }
}
