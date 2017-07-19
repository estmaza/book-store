using BookStore.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(t => new { t.BookId, t.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(t => t.Book)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(t => t.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(t => t.Author)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(t => t.AuthorId);
        }
    }
}
