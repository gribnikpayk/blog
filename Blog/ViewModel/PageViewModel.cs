using System;
using System.Collections.Generic;

namespace Blog.ViewModel
{
    public class PageViewModel
    {
        public double RowCount { get; set; }
        public double RowPerPage { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Dictionary<string,string> Params { get; set; }
        public int CurrentPage { get; set; }

        public int PageCount => (int) Math.Ceiling((double) (RowCount / RowPerPage));
    }
}
