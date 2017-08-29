using System;

namespace Blog.ViewModel
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Body { get; set; }
        public bool IsPublished { get; set; }
        public bool IsTopPlacement { get; set; }
        public string Tags { get; set; }
        public string Categories { get; set; }
        public string Author { get; set; }
        public string ShortDescription { get; set; }
    }
}
