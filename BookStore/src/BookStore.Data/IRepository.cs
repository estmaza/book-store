﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public interface IRepository<T> where T: class
    {
        void Create(T item);
        T Get(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        IEnumerable<T> Get(params string[] navigationProperties);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate, params string[] navigationProperties);
        void Delete(T item);
        void Update(T item);
    }
}