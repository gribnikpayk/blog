using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Blog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Articles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Author = table.Column<string>(type: "TEXT", nullable: true),
            //        Body = table.Column<string>(type: "TEXT", nullable: true),
            //        Categories = table.Column<string>(type: "TEXT", nullable: true),
            //        Date = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
            //        IsTopPlacement = table.Column<bool>(type: "INTEGER", nullable: false),
            //        ShortDescription = table.Column<string>(type: "TEXT", nullable: true),
            //        Tags = table.Column<string>(type: "TEXT", nullable: true),
            //        Title = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Articles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Category",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Name = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Category", x => x.Id);
            //    });

            migrationBuilder.AddColumn<string>(name: "Site", table: "Comment", nullable: true);
            migrationBuilder.AddColumn<string>(name: "Email", table: "Comment", nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Comment",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        ArticleId = table.Column<int>(type: "INTEGER", nullable: false),
            //        Author = table.Column<string>(type: "TEXT", nullable: true),
            //        Body = table.Column<string>(type: "TEXT", nullable: true),
            //        Date = table.Column<DateTime>(type: "TEXT", nullable: false),
            //        Email = table.Column<string>(type: "TEXT", nullable: true),
            //        IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
            //        Site = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comment", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Tag",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "INTEGER", nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Name = table.Column<string>(type: "TEXT", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Tag", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
