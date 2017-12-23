using BookStore.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using BookStore.Data;
using BookStore.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookStore.BL
{
    public class AuthorService : BusinessBase<Author>, IAuthorService
    {
        public AuthorService(ApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<AuthorViewModel>> Get()
        {
            var model = await _context.Set<Author>()
                .Include(p => p.BookAuthors)
                .Select(p => _mapper.Map<AuthorViewModel>(p))
                .ToListAsync();

            return model;
        }

        public async Task<AuthorViewModel> Get(int id)
        {
            var model = await _context.Set<Author>()
                .Include(p => p.BookAuthors)
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<AuthorViewModel>(model);
        }

        public async Task<AuthorViewModel> Create(AuthorViewModel model)
        {
            var entity = _mapper.Map<Author>(model);

            await _context.Set<Author>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorViewModel>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Set<Author>().FirstOrDefaultAsync(p => p.Id == id);

            if (entity == null)
                return false;

            _context.Set<Author>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(AuthorViewModel model)
        {
            var entity = await _context.Set<Author>()
                .Include(p => p.BookAuthors)
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (entity == null)
                return false;

            _context.Entry(entity).CurrentValues.SetValues(model);

            // delete children
            foreach (var ba in entity.BookAuthors)
            {
                if (!model.Books.Contains(ba.BookId))
                    _context.Set<BookAuthor>().Remove(ba);
            }

            // add children (no need to update entries in join-table)
            var existedBooks = entity.BookAuthors.Select(p => p.BookId).ToList();
            var bookAuthors = model.Books.Except(existedBooks)
                .Select(bookId => new BookAuthor { AuthorId = entity.Id, BookId = bookId });

            await _context.Set<BookAuthor>().AddRangeAsync(bookAuthors);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<SelectOption>> Options()
        {
            var model = await _context.Set<Author>()
                .Select(p => new SelectOption { Id = p.Id, Name = $"{p.FirstName} {p.LastName}" })
                .ToListAsync();

            return model;
        }
    }
}
