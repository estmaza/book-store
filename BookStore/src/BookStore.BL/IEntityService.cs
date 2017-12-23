using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BL
{
    public interface IEntityService<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(int id);
        Task<IEnumerable<SelectOption>> Options();
    }
}