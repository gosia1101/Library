namespace Library.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library.Models.ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate(x => x.Id,
                new Models.LibraryModel.Category { Id = 1, Title = "Cat1" },
                new Models.LibraryModel.Category { Id = 2, Title = "Cat2" },
                new Models.LibraryModel.Category { Id = 3, Title = "Cat3" });

            context.Publishers.AddOrUpdate(x => x.Id,
                new Models.LibraryModel.Publisher
                {
                    Id = 1,
                    Address = "asdasd",
                    Name = "Pub 2"
                });

            context.Books.AddOrUpdate(x => x.Id,
                new Models.LibraryModel.Book
                {
                    Id = 1,
                    Title = "Book 1",
                    Isbn = 123213,
                    CategoryId = 1,
                    PublisherId = 1
                },
                new Models.LibraryModel.Book
                {
                    Id = 2,
                    Title = "Book 2",
                    Isbn = 123213,
                    CategoryId = 2,
                    PublisherId = 1
                },
                new Models.LibraryModel.Book
                {
                    Id = 3,
                    Title = "Book 3",
                    Isbn = 123213,
                    CategoryId = 3,
                    PublisherId = 1
                });

            context.BookCopies.AddOrUpdate(x => x.Id,
                new Models.LibraryModel.BookCopy
                {
                    Id = 1,
                    BookId = 1
                },
                new Models.LibraryModel.BookCopy
                {
                    Id = 2,
                    BookId = 2
                },
                new Models.LibraryModel.BookCopy
                {
                    Id = 4,
                    BookId = 2
                },
                new Models.LibraryModel.BookCopy
                {
                    Id = 3,
                    BookId = 3
                });
        }
    }
}
