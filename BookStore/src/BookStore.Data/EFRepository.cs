using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BookStore.Data
{
  public class EFRepository<T> : IRepository<T> where T : class
  {
    protected readonly ApplicationContext _context;

    public EFRepository(ApplicationContext context)
    {
      _context = context;
    }

    public void Create(T item)
    {
      _context.Set<T>().Add(item);
    }

    public IEnumerable<T> Get()
    {
      return _context.Set<T>().AsNoTracking().ToList();
    }

    public IEnumerable<T> Get(Func<T, bool> predicate)
    {
      return _context.Set<T>().AsNoTracking().Where(predicate).ToList();
    }

    public IEnumerable<T> Get(params string[] navigationProperties)
    {
      List<T> list;
      var query = _context.Set<T>().AsQueryable();

      foreach (string navigationProperty in navigationProperties)
        query = query.Include(navigationProperty);//got to reaffect it.

      list = query.ToList<T>();
      return list;
    }

    public IEnumerable<T> Get(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
    {
      List<T> list;
      var query = _context.Set<T>().AsQueryable();

      foreach (string navigationProperty in navigationProperties)
        query = query.Include(navigationProperty);//got to reaffect it.

      list = query.Where(predicate).ToList<T>();
      return list;
    }

    public T Get(int id)
    {
      return _context.Set<T>().Find(id);
    }

    public void Delete(T item)
    {
      _context.Set<T>().Remove(item);
      _context.SaveChanges();
    }

    public void Update(T item)
    {
      _context.Set<T>().Update(item);
      _context.SaveChanges();
    }
  }
}
