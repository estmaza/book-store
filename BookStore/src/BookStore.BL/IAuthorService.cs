using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BL
{
    public interface IAuthorService
    {
        IEnumerable<AuthorViewModel> Get();
        AuthorViewModel Get(int id);
        void Save(AuthorViewModel book);
        void Remove(int id);
    }
}
