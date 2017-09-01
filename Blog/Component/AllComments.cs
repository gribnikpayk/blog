using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infrastructure;
using Jdenticon;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Component
{
    public class AllComments : ViewComponent
    {
        private List<string> _backgroundColours = new List<string> { "B26126", "FFF7F2", "FFE8D8", "74ADB2", "D8FCFF" };
    public IViewComponentResult Invoke(int articleId)
        {
            using (var db = new BloggingContext())
            {
                var comments = db.Comment.Where(x => x.ArticleId == articleId && x.IsPublished)
                    .OrderByDescending(x => x.Date);
                return View(comments.Select(x => new CommentViewModel
                {
                    Body = x.Body,
                    Date = x.Date,
                    Author = x.Author,
                    ArticleId = x.ArticleId,
                    IsPublished = x.IsPublished,
                    Email = x.Email,
                    Site = x.Site
                }).ToList());
            }
        }
    }

    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public int ArticleId { get; set; }
        public bool IsPublished { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
    }
}
