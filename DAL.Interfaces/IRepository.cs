using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);

        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T GetFirst(Expression<Func<T, bool>> predicate);
    }
}
