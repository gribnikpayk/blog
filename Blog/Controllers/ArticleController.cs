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
    }
}
