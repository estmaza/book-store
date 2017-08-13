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
        int Create(T model);
        void Update(T model);
        void Delete(int id);
    }
}