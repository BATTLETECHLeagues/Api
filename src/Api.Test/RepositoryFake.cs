using Api.Domain;

namespace Api.Test
{
    public class RepositoryFake : IRepository
    {
        public object InsertedItem { get; set; }
        public long Insert<T>(T item) where T : class
        {
            InsertedItem = item;
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