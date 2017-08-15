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
    public class AuthorService : BusinessBase<Author>, IAuthorService
    {
        public AuthorService(IRepository<Author> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public IEnumerable<AuthorViewModel> Get()
        {
            var model = _repository.Get("BookAuthors")
                .Select(p => _mapper.Map<AuthorViewModel>(p))
                .ToList();
            return model;
        }

        public AuthorViewModel Get(int id)
        {
            var model = _repository.Get(id, "BookAuthors");
            return _mapper.Map<AuthorViewModel>(model);
        }

        public bool Delete(int id)
        {
            var model = _repository.Get(id);
            if (model != null)
                return _repository.Delete(model);
            return false;
        }

        public AuthorViewModel Create(AuthorViewModel model)
        {
            var entity = _mapper.Map<Author>(model);
            var saved = _repository.Create(entity);
            return _mapper.Map<AuthorViewModel>(saved);
        }

        public bool Update(AuthorViewModel model)
        {
            var entity = _mapper.Map<Author>(model);
            return _repository.Update(entity);
        }
    }
}
