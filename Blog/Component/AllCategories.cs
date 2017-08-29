using System.Collections.Generic;
using System.Linq;
using Blog.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Component
{
    public class AllCategories: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var db = new BloggingContext())
            { 
                var categoriesModelList = new List<AllCategoriesComponentModel>();
                List<string> allCategories = db.Category.Select(x => x.Name).ToList();
                var allArticlesCategories = db.Articles
                    .Where(x => x.IsPublished && x.Categories != null && x.Categories != string.Empty)
                    .Select(x => x.Categories);

                foreach (var category in allCategories)
                {
                    var model = new AllCategoriesComponentModel();
                    model.Name = category;
                    model.Count = allArticlesCategories.Count(x => x.Contains(category));
                    categoriesModelList.Add(model);
                }
                return View(categoriesModelList);
            }
        }
    }

    public class AllCategoriesComponentModel
    {
        public int Count { get; set; }
        public string Name { get; set; }
    }
}
