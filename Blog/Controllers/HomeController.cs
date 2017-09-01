using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.ViewModel;
using System.Security.Claims;
using Blog.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int page = 1)
        {
            using (var db = new BloggingContext())
            {
                var articles = db.Articles
                    .Where(x => x.IsPublished)
                    .OrderByDescending(x => x.IsTopPlacement)
                    .ThenByDescending(x => x.Date)
                    .Take(10 * page)
                    .Skip((10 * page) - 10)
                    .ToList();

                var count = db.Articles
                    .Count(x => x.IsPublished);
                var viewModel = new HomeViewModel
                {
                    Articles = articles.Select(x => x.ToArticleViewModel()).ToList(),
                    PageViewModel = new PageViewModel
                    {
                        Action = "Index",
                        Controller = "Home",
                        RowPerPage = 10,
                        RowCount = count,
                        CurrentPage = page
                    }
                };
                return View(viewModel);
            }
        }

        public IActionResult Category(string name, int page = 1)
        {
            using (var db = new BloggingContext())
            {
                var articles = db.Articles
                    .Where(x => x.IsPublished && x.Categories.Contains(name))
                    .OrderByDescending(x => x.IsTopPlacement)
                    .ThenByDescending(x => x.Date)
                    .Take(10 * page)
                    .Skip((10 * page) - 10)
                    .ToList();

                var count = db.Articles
                    .Count(x => x.IsPublished && x.Categories.Contains(name));
                var viewModel = new HomeViewModel
                {
                    Articles = articles.Select(x => x.ToArticleViewModel()).ToList(),
                    PageViewModel = new PageViewModel
                    {
                        Action = "Category",
                        Controller = "Home",
                        RowPerPage = 10,
                        RowCount = count,
                        CurrentPage = page,
                        Params = new Dictionary<string, string> { { "name", name } }
                    }
                };
                return View("~/Views/Home/Index.cshtml", viewModel);
            }
        }

        public IActionResult Tag(string name, int page = 1)
        {
            using (var db = new BloggingContext())
            {
                var articles = db.Articles
                    .Where(x => x.IsPublished && x.Tags.Contains(name))
                    .OrderByDescending(x => x.IsTopPlacement)
                    .ThenByDescending(x => x.Date)
                    .Take(10 * page)
                    .Skip((10 * page) - 10)
                    .ToList();

                var count = db.Articles
                    .Count(x => x.IsPublished && x.Tags.Contains(name));
                var viewModel = new HomeViewModel
                {
                    Articles = articles.Select(x => x.ToArticleViewModel()).ToList(),
                    PageViewModel = new PageViewModel
                    {
                        Action = "Tag",
                        Controller = "Home",
                        RowPerPage = 10,
                        RowCount = count,
                        CurrentPage = page,
                        Params = new Dictionary<string, string> { { "name", name } }
                    }
                };
                return View("~/Views/Home/Index.cshtml", viewModel);
            }
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model.Password == "ibanezrg123mh" && model.Login.ToLower() == "admin")
            {
                await Authenticate(model.Login); // аутентификация
                return RedirectToAction("Index", "Management");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
            new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));
        }
    }
}
