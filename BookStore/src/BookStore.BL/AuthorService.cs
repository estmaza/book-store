using BookStore.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BL
{
  public class AuthorService : BusinessBase<Author>, IAuthorService
    {
        public AuthorService(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<AuthorViewModel> Get()
        {
            var model = _context.Set<Author>()
                .Include(p => p.BookAuthors)
                .Select(p => _mapper.Map<AuthorViewModel>(p))
                .ToList();
            
            return model;
        }

        public AuthorViewModel Get(int id)
        {
            var model = _context.Set<Author>()
                .Include(p => p.BookAuthors)
                .FirstOrDefault(p => p.Id == id);
            
            return _mapper.Map<AuthorViewModel>(model);
        }

        public AuthorViewModel Create(AuthorViewModel model)
        {
            var entity = _mapper.Map<Author>(model);

            _context.Set<Author>().Add(entity);
            _context.SaveChanges();
            
            return _mapper.Map<AuthorViewModel>(entity);
        }

        public bool Delete(int id)
        {
            var entity = _context.Set<Author>().FirstOrDefault(p => p.Id == id);

            if (entity != null) 
            {
                _context.Set<Author>().Remove(entity);
                _context.SaveChanges();
                
                return true;
            }
            return false;
        }

        public bool Update(AuthorViewModel model)
        {
            var entity = _context.Set<Author>()
                .Include(p => p.BookAuthors)
                .FirstOrDefault(p => p.Id == model.Id);

            if (entity != null)
            {
                _context.Entry(entity).CurrentValues.SetValues(model);

                // delete children
                foreach (var ba in entity.BookAuthors)
                {
                    if (!model.Books.Contains(ba.BookId))
                        _context.Set<BookAuthor>().Remove(ba);
                }

                // add children (no need to update entries in join-table)
                var existedBooks = entity.BookAuthors.Select(p => p.BookId).ToList();
                var newBooks = model.Books.Except(existedBooks);
                
                foreach (var bookId in newBooks)
                {
                    _context.Set<BookAuthor>().Add(new BookAuthor { AuthorId = entity.Id, BookId = bookId });
                }

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<SelectOption> Options()
        {
            var model = _context.Set<Author>().Select(p => new SelectOption { Id = p.Id, Name = $"{p.FirstName} {p.LastName}" });
            return model;
        }
    }
}
