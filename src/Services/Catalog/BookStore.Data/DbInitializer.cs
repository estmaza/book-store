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
                new Book {Name = "Pro ASP.NET Core MVC", Pages = 1018, Rating = 9, PublishDate = DateTime.Parse("09/06/2016"), Annotation = "Now in its 6th edition, the best selling book on MVC is now updated for ASP.NET Core MVC. It contains detailed explanations of the new Core MVC functionality which enables developers to produce leaner, cloud optimized and mobile-ready applications for the .NET platform." },
                new Book {Name = "Pro Angular", Pages = 778, Rating = 8, PublishDate = DateTime.Parse("08/03/2014"), Annotation = "Get the most from Angular 2, the leading framework for building dynamic JavaScript applications." },
                new Book {Name = "Pro ASP.NET MVC 5", Pages = 832, Rating = 7, PublishDate = DateTime.Parse("07/03/2013"), Annotation = "The ASP.NET MVC 5 Framework is the latest evolution of Microsoft’s ASP.NET web platform. It provides a high-productivity programming model that promotes cleaner code architecture, test-driven development, and powerful extensibility, combined with all the benefits of ASP.NET." },
                new Book {Name = "Pro Asynchronous Programming with .NET", Pages = 352, Rating = 9, PublishDate = DateTime.Parse("06/03/2012"), Annotation = "Pro Asynchronous Programming with .NET teaches the essential skill of asynchronous programming in .NET. It answers critical questions in .NET application development, such as: how do I keep my program responding at all times to keep my users happy?" }
            };

            foreach (var b in books)
                context.Books.Add(b);
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author {FirstName = "Adam", LastName = "Freeman", Biography = "Adam Freeman is an experienced IT professional who has held senior positions in a range of companies, most recently serving as chief technology officer and chief operating officer of a global bank. Now retired, he spends his time writing and long-distance running" },
                new Author {FirstName = "Richard", LastName = "Blewett", Biography = "Richard Blewett is a professional software developer and trainer living in Bristol in the UK. He has been writing software for over 20 years and has spent most of that time building distributed systems of one form or another. He first started writing multithreaded code in C on OS/2 and continued when moving to Windows, COM and .NET." },
                new Author {FirstName = "Stephen", LastName = "Cleary", Biography = "Stephen Cleary has established himself as a key expert on asynchrony and parallelism in C#. This book clearly and concisely conveys the most important points and principles developers need to understand to get started and be successful with these technologies." }
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
