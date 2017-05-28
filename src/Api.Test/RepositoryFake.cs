using System.Collections.Generic;
using Api.Domain;

namespace Api.Test
{
    public class RepositoryFake : IRepository
    {
        public RepositoryFake()
        {
            InsertedItem = new List<object>();
        }

        public List<object> InsertedItem { get; set; }
        public long Insert<T>(T item) where T : class
        {
            InsertedItem.Add(item);
            return 1;
        }

        public void Remove<T>(T item)
        {
            throw new global::System.NotImplementedException();
        }

        public void Update<T>(T item)
        {
            throw new global::System.NotImplementedException();
        }

        public T FindById<T>(int id) where T : class
        {
            throw new global::System.NotImplementedException();
        }
    }
}