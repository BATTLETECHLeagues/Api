using System;
using Api.Domain;

namespace Api.Infrastructure
{
    public class DapperRepository : IRepository
    {
        public void Insert<T>(T item)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(T item)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T item)
        {
            throw new NotImplementedException();
        }

        public T FindById<T>(int id)
        {
            throw new NotImplementedException();
        }
    }
}