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

        public async Task<IEnumerable<BookViewModel>> Get()
        {
            var model = await _context.Set<Book>()
                .Include(p => p.BookAuthors)
                .Select(p => _mapper.Map<BookViewModel>(p))
                .ToListAsync();

            return model;
        }

        public async Task<BookViewModel> Get(int id)
        {
            var model = await _context.Set<Book>()
                .Include(p => p.BookAuthors)
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<BookViewModel>(model);
        }

        public async Task<BookViewModel> Create(BookViewModel model)
        {
            var entity = _mapper.Map<Book>(model);

            await _context.Set<Book>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookViewModel>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = _context.Set<Book>().FirstOrDefault(p => p.Id == id);

            if (entity == null)
                return false;

            _context.Set<Book>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(BookViewModel model)
        {
            var entity = _context.Set<Book>()
                .Include(p => p.BookAuthors)
                .FirstOrDefault(p => p.Id == model.Id);

            if (entity == null)
                return false;

            _context.Entry(entity).CurrentValues.SetValues(model);

            // delete children
            foreach (var ba in entity.BookAuthors)
            {
                if (!model.Authors.Contains(ba.BookId))
                    _context.Set<BookAuthor>().Remove(ba);
            }

            // add children (no need to update entries in join-table)
            var existedAuthors = entity.BookAuthors.Select(p => p.AuthorId).ToList();
            var bookAuthors = model.Authors.Except(existedAuthors)
                .Select(authorId => new BookAuthor { AuthorId = authorId, BookId = entity.Id });

            await _context.Set<BookAuthor>().AddRangeAsync(bookAuthors);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<SelectOption>> Options()
        {
            var model = await _context.Set<Book>().Select(p => new SelectOption { Id = p.Id, Name = p.Name }).ToListAsync();
            return model;
        }
    }
}
