using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Api.Infrastructure.Database
{
    public interface IRepository<T> where T : class 
    {
    void Add(T item);
    void Remove(T item);
    void Update(T item);
    T FindByID(Guid id);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    IEnumerable<T> FindAll();
    }
}
