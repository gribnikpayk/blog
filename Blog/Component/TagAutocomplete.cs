using System.Collections.Generic;
using System.Linq;
using Blog.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Component
{
    public class TagAutocomplete: ViewComponent
    {
        public IViewComponentResult Invoke(string addedTags)
        {
            using (var db = new BloggingContext())
            {
                var model = new TagAutocompleteComponentModel();
                model.AddedTags = addedTags;

                var tags = db.Tag.Select(x => x.Name).ToList();
                model.AllTags = tags;
                return View(model);
            }
        }
    }

    public class TagAutocompleteComponentModel
    {
        public List<string> AllTags { get; set; }
        public string AddedTags { get; set; }
    }

}
