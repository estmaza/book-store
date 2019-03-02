using AutoMapper;
using BookStore.Data.Entity;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BL.Infrastructure
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("DefaultProfile") { }

        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<Book, BookViewModel>().ForMember(s => s.Authors, p => p.MapFrom(src => src.BookAuthors.Select(c => c.AuthorId)));
            CreateMap<BookViewModel, Book>().ForMember(s => s.BookAuthors, p => p.MapFrom(src => src.Authors.Select(c => new BookAuthor { BookId = src.Id, AuthorId = c })));
            CreateMap<Author, AuthorViewModel>().ForMember(s => s.Books, p => p.MapFrom(src => src.BookAuthors.Select(c => c.BookId)));
            CreateMap<AuthorViewModel, Author>().ForMember(s => s.BookAuthors, p => p.MapFrom(src => src.Books.Select(c => new BookAuthor { AuthorId = src.Id, BookId = c })));
        }
    }
}
