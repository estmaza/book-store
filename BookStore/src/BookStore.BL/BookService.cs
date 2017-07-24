using BookStore.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.ViewModels;
using AutoMapper;

namespace BookStore.BL
{
    public class BookService : BusinessBase<Book>, IBookService
    {
        public BookService(IRepository<Book> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public IEnumerable<BookViewModel> Get()
        {
            return _repository.Get().Select(p => _mapper.Map<BookViewModel>(p)).ToList();
        }

        public BookViewModel Get(int id)
        {
            return _mapper.Map<BookViewModel>(_repository.Get(id));
        }

        public void Create(BookViewModel model)
        {
            var entity = _mapper.Map<Book>(model);
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                _repository.Delete(_repository.Get(id));
            }
        }

        public void Update(BookViewModel model)
        {
            var entity = _mapper.Map<Book>(model);
            _repository.Update(entity);
        }
    }
}
