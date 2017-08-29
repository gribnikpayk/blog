using Blog.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Blog.Component
{
    public class Paginator: ViewComponent
    {
        public Paginator()
        {
            
        }
        public IViewComponentResult Invoke(PageViewModel pageViewModel)
        {
            return View(pageViewModel);
        }
    }
}
