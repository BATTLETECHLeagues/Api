namespace Api.Domain
{
    public interface IRepository  
    {
    void Insert<T>(T item);
    void Remove<T>(T item);
    void Update<T>(T item);
    T FindById<T>(int id);
    }
}
