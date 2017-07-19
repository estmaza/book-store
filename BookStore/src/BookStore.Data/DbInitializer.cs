using BookStore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return; 
            }

            var books = new List<Book>
            {
                new Book {Name = "ASP.NET MVC", Pages = 282, Rating = 9, Date = "09/03/2015" },
                new Book {Name = "ASP.NET MVD", Pages = 992, Rating = 8, Date = "08/03/2014" },
                new Book {Name = "ASP.NET MVE", Pages = 768, Rating = 7, Date = "07/03/2013" },
                new Book {Name = "ASP.NET MVF", Pages = 512, Rating = 6, Date = "06/03/2012" }
            };

            foreach (var b in books)
                context.Books.Add(b);
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author {FirstName = "Vlad", LastName = "Mazur" },
                new Author {FirstName = "Name1", LastName = "Sname1" },
                new Author {FirstName = "Name2", LastName = "Sname2" }
            };

            foreach (var a in authors)
                context.Authors.Add(a);
            context.SaveChanges();

            var bookAuthors = new List<BookAuthor>
            {
                new BookAuthor { Book = books[0], Author = authors[0] },
                new BookAuthor { Book = books[0], Author = authors[1] },
                new BookAuthor { Book = books[0], Author = authors[2] },
                new BookAuthor { Book = books[1], Author = authors[1] },
                new BookAuthor { Book = books[1], Author = authors[2] },
                new BookAuthor { Book = books[2], Author = authors[2] }
            };

            foreach (var ba in bookAuthors)
                context.BookAuthors.Add(ba);
            context.SaveChanges();
        }
    }
}
