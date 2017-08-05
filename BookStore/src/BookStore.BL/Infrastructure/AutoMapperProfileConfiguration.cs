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
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();
            //CreateMap<AuthorViewModel, Author>();
            CreateMap<AuthorViewModel, Author>().ForMember(s => s.BookAuthors, p => p.MapFrom(src => src.Books)); // May be usefull
            CreateMap<Author, AuthorViewModel>().ForMember(d => d.Books, s => s.MapFrom(src => src.BookAuthors.authorid);
        }
    }
}
