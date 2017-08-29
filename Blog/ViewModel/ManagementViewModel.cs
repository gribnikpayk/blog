using System.Collections.Generic;
using Blog.Infrastructure;

namespace Blog.ViewModel
{
    public class ManagementViewModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
