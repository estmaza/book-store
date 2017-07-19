using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BL
{
    public interface IBookService
    {
        IEnumerable<BookViewModel> Get();
        BookViewModel Get(int id);
        void Save(BookViewModel book);
        void Remove(int id);
    }
}
