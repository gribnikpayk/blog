using System;
using System.Linq;
using Blog.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        public IActionResult Index(int id)
        {
            using (var db = new BloggingContext())
            {
                var article = db.Articles.FirstOrDefault(x => x.Id == id && x.IsPublished);
                if (article != null)
                {
                    var articleViewModel = article.ToArticleViewModel();
                    return View("~/Views/Article/Article.cshtml", articleViewModel);
                }
                return View("Error");
            }
        }

        [HttpPost]
        public JsonResult AddComment(Comment model)
        {
            using (var db = new BloggingContext())
            {
                if (string.IsNullOrEmpty(model.Body) || string.IsNullOrEmpty(model.Author))
                {
                    return Json(new {success = false});
                }
                db.Comment.Add(new Comment
                {
                    Body = model.Body,
                    Date = DateTime.UtcNow,
                    Author = model.Author,
                    ArticleId = model.ArticleId,
                    IsPublished = false,
                    Email = model.Email,
                    Site = model.Site
                });
                db.SaveChanges();
            }
            return Json(new {success = true});
        }
    }
}
