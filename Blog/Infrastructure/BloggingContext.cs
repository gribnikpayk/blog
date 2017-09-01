using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure
{
    public class BloggingContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }

    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public bool IsPublished { get; set; }
        public bool IsTopPlacement { get; set; }
        public string Tags { get; set; }
        public string Categories { get; set; }
        public string Author { get; set; }
        public string ShortDescription { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public int ArticleId { get; set; }
        public bool IsPublished { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
    }
}