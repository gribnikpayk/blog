using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.ViewModel;

namespace Blog.Infrastructure
{
    public static class BlogExtensions
    {
        public static ArticleViewModel ToArticleViewModel(this Article model)
        {
            return new ArticleViewModel
            {
                Body = model.Body,
                Date = model.Date.ToString("MM dd yyyy HH:mm:ss"),
                Title = model.Title,
                IsPublished = model.IsPublished,
                IsTopPlacement = model.IsTopPlacement,
                Tags = model.Tags,
                Id = model.Id,
                Categories = model.Categories,
                Author = model.Author,
                ShortDescription = model.ShortDescription
            };
        }

        public static Article ToArticle(this ArticleViewModel viewModel)
        {
            return new Article
            {
                Body = viewModel.Body,
                Title = viewModel.Title,
                IsPublished = viewModel.IsPublished,
                IsTopPlacement = viewModel.IsTopPlacement,
                Tags = viewModel.Tags,
                Id = viewModel.Id,
                Categories = viewModel.Categories,
                Author = viewModel.Author,
                ShortDescription = viewModel.ShortDescription
            };
        }
    }
}
