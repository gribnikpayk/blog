using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Component
{
    public class AllTags:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var db = new BloggingContext())
            {
                List<string> allTags = db.Tag.Select(x => x.Name).ToList();
                return View(allTags);
            }
        }
    }
}
