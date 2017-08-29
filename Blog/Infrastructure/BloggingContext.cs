using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure
{
    public class BloggingContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Category> Category { get; set; }

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
}