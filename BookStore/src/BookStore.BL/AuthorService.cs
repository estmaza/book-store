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

        public void Remove(int id)
        {
            _repository.Remove(_repository.Get(id));
        }

        public void Save(AuthorViewModel book)
        {
            throw new NotImplementedException();
        }
    }
}
