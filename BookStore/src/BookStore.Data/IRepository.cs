using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public interface IRepository<T> where T: class
    {
        void Create(T item);
        T Get(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);
    }
}
