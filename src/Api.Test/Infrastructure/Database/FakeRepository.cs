using Api.Domain;

namespace Api.Test.Infrastructure.Database
{
    public class FakeRepository : IRepository
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

        public T FindById<T>(int id)
        {
            throw new global::System.NotImplementedException();
        }
    }
}