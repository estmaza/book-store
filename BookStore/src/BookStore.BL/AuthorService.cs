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
            return _repository.Get().Select(p => _mapper.Map<AuthorViewModel>(p)).ToList();
        }

        public AuthorViewModel Get(int id)
        {
            return _mapper.Map<AuthorViewModel>(_repository.Get(id));
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                _repository.Delete(_repository.Get(id));
            }
        }

        public void Create(AuthorViewModel model)
        {
            var entity = _mapper.Map<Author>(model);
            _repository.Create(entity);
        }

        public void Update(AuthorViewModel model)
        {
            var entity = _mapper.Map<Author>(model);
            _repository.Update(entity);
        }
    }
}
