using System.Collections.Generic;
using System.Linq;
using Blog.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Component
{
    public class CategoryAutocomplete: ViewComponent
    {
        public IViewComponentResult Invoke(string categories)
        {
            using (var db = new BloggingContext())
            {
                var model = new CategoryAutocompleteComponentModel();
                model.AddedCategories = categories;

                List<string> allCategories = db.Category.Select(x => x.Name).ToList();
                model.AllCategories = allCategories;
                return View(model);
            }
        }
    }

    public class CategoryAutocompleteComponentModel
    {
        public List<string> AllCategories { get; set; }
        public string AddedCategories { get; set; }
    }
}
