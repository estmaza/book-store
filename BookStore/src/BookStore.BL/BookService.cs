using BookStore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStore.BL
{
    public class BookService : BusinessBase<Book>, IBookService
    {
        public BookService(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<BookViewModel> Get()
        {
            var model = _context.Set<Book>()
                .Include(p => p.BookAuthors)
                .Select(p => _mapper.Map<BookViewModel>(p))
                .ToList();
            
            return model;
        }

        public BookViewModel Get(int id)
        {
            var model = _context.Set<Book>()
                .Include(p => p.BookAuthors)
                .FirstOrDefault(p => p.Id == id);
            
            return _mapper.Map<BookViewModel>(model);
        }

        public BookViewModel Create(BookViewModel model)
        {
            var entity = _mapper.Map<Book>(model);

            _context.Set<Book>().Add(entity);
            _context.SaveChanges();
            
            return _mapper.Map<BookViewModel>(entity);
        }

        public bool Delete(int id)
        {
            var entity = _context.Set<Book>().FirstOrDefault(p => p.Id == id);

            if (entity != null) 
            {
                _context.Set<Book>().Remove(entity);
                _context.SaveChanges();
                
                return true;
            }
            return false;
        }

        public bool Update(BookViewModel model)
        {
            var entity = _context.Set<Book>()
                .Include(p => p.BookAuthors)
                .FirstOrDefault(p => p.Id == model.Id);

            if (entity != null)
            {
                _context.Entry(entity).CurrentValues.SetValues(model);

                // delete children
                foreach (var ba in entity.BookAuthors)
                {
                    if (!model.Authors.Contains(ba.BookId))
                        _context.Set<BookAuthor>().Remove(ba);
                }

                // add children (no need to update entries in join-table)
                var existedAuthors = entity.BookAuthors.Select(p => p.AuthorId).ToList();
                var newAuthors = model.Authors.Except(existedAuthors);
                
                foreach (var authorId in newAuthors)
                {
                    _context.Set<BookAuthor>().Add(new BookAuthor { AuthorId = authorId, BookId = entity.Id });
                }

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public IEnumerable<SelectOption> Options()
        {
            var model = _context.Set<Book>().Select(p => new SelectOption { Id = p.Id, Name = p.Name });
            return model;
        }
    }
}
