﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using BookStore.Data.Entity;

namespace BookStore.Data
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApplicationContext _context;

        public EFRepository(ApplicationContext context)
        {
            _context = context;
        }

        public T Create(T item)
        {
            var result = _context.Set<T>().Add(item);
            _context.SaveChanges();
            return result.Entity;
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

        public T Get(int id, params string[] navigationProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            return query.FirstOrDefault(p => p.Id == id);
        }

        public bool Delete(T item)
        {
            var result = _context.Set<T>().Remove(item);
            _context.SaveChanges();
            return result.State == EntityState.Deleted;
        }

        public bool Update(T item)
        {
            if (_context.Set<T>().Any(p => p.Id == item.Id))
            {
                _context.Set<T>().Update(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
