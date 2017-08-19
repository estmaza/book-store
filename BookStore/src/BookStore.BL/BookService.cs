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
            var model = _repository.Get("BookAuthors")
                .Select(p => _mapper.Map<BookViewModel>(p))
                .ToList();
            return model;
        }

        public BookViewModel Get(int id)
        {
            var model = _repository.Get(id, "BookAuthors");
            return _mapper.Map<BookViewModel>(model);
        }

        public BookViewModel Create(BookViewModel model)
        {
            var entity = _mapper.Map<Book>(model);
            var saved = _repository.Create(entity);
            return _mapper.Map<BookViewModel>(saved);
        }

        public bool Delete(int id)
        {
            var model = _repository.Get(id);
            if (model != null)
                return _repository.Delete(model);
            return false;
        }

        public bool Update(BookViewModel model)
        {
            var entity = _mapper.Map<Book>(model);
            return _repository.Update(entity);
        }

        public Dictionary<int, string> Options()
        {
            var model = _repository.Get().ToDictionary(k => k.Id, v => v.Name);
            return model;
        }
    }
}
