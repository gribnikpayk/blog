using Microsoft.AspNetCore.Mvc;

namespace Blog.Component
{
    public class AddComment: ViewComponent
    {
        public IViewComponentResult Invoke(int articleId)
        {
            return View(articleId);
        }
    }
}
