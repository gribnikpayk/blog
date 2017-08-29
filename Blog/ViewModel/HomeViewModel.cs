using System.Collections.Generic;

namespace Blog.ViewModel
{
    public class HomeViewModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
