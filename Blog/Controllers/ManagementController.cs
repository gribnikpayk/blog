using System;
using Blog.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infrastructure;

namespace Blog.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        IHostingEnvironment _appEnvironment;
        public ManagementController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            using (var db = new BloggingContext())
            {
                var articles = db.Articles
                    .OrderByDescending(x => x.IsTopPlacement)
                    .ThenByDescending(x => x.Date)
                    .Take(10 * page)
                    .Skip((10 * page) - 10)
                    .ToList();


                var count = db.Articles.Count();
                var viewModel = new ManagementViewModel
                {
                    Articles = articles.Select(x => x.ToArticleViewModel()).ToList(),
                    PageViewModel = new PageViewModel
                    {
                        Action = "Index",
                        Controller = "Management",
                        RowPerPage = 10,
                        RowCount = count
                    }
                };
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult Article(int id)
        {
            using (var db = new BloggingContext())
            {
                var article = db.Articles.Find(id);
                var articleViewModel = article.ToArticleViewModel();
                return View("~/Views/Article/Article.cshtml", articleViewModel);
            }
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateArticle(ArticleViewModel model)
        {
            using (var db = new BloggingContext())
            {
                var article = model.ToArticle();
                article.Date = DateTime.UtcNow;
                article.Author = "Denis";
                db.Articles.Add(article);

                if (!string.IsNullOrEmpty(model.Tags))
                {
                    var tags = model.Tags
                        .Split(',')
                        .Where(x => !string.IsNullOrEmpty(x))
                        .Select(x => x.Trim())
                        .ToList();
                    var tagsFromDB = db.Tag
                        .Select(x => x.Name)
                        .ToList();

                    var newTags = tags.Where(x => !tagsFromDB.Contains(x))
                        .Select(x => new Tag{Name = x});
                    db.Tag.AddRange(newTags);
                }

                if (!string.IsNullOrEmpty(model.Categories))
                {
                    var categories = model.Categories
                        .Split(',')
                        .Where(x => !string.IsNullOrEmpty(x))
                        .Select(x => x.Trim())
                        .ToList();
                    var categoriesFromDB = db.Category
                        .Select(x => x.Name)
                        .ToList();

                    var newCategories = categories.Where(x => !categoriesFromDB.Contains(x))
                        .Select(x => new Category { Name = x });
                    db.Category.AddRange(newCategories);
                }
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateArticle(int id)
        {
            using (var db = new BloggingContext())
            {
                var article = db.Articles.Find(id);
                return View(article.ToArticleViewModel());
            }
        }

        [HttpPost]
        public void UpdateArticle(ArticleViewModel model)
        {
            using (var db = new BloggingContext())
            {
                var date = db.Articles.Where(x => x.Id == model.Id).Select(x => x.Date).FirstOrDefault();
                var article = model.ToArticle();
                article.Date = date;
                db.Update(article);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public void DeleteArticle(int id)
        {
            using (var db = new BloggingContext())
            {
                var entity = db.Articles.Find(id);
                db.Articles.Remove(entity);
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult UploadImage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> UploadImagePost(IFormFile file)
        {

            if (file != null)
            {
                string path = $"/images/ArticleArt/{Guid.NewGuid()}" + file.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                    return Json(path);
                }
            }
            return Json("");
        }

        [HttpGet]
        public IActionResult AllComents()
        {
            return View();
        }
    }
}
