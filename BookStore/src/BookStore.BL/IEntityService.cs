using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BL
{
    public interface IEntityService<T> where T: class
    {
        IEnumerable<T> Get();
        T Get(int id);
        T Create(T model);
        bool Update(T model);
        bool Delete(int id);
    }
}