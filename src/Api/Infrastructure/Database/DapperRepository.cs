using System;
using System.Data;
using System.Data.SqlClient;
using Api.Domain;
using Dapper.Contrib.Extensions;

namespace Api.Infrastructure
{
    public class DapperRepository : IRepository
    {
        public long Insert<T>(T item) where T : class
        {
            long id;
       
            using (IDbConnection sqlConnection
             = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=BCAPIDatabase_Dev;Trusted_Connection=True;"))
            {
                sqlConnection.Open();

                id = sqlConnection.Insert(item);

                sqlConnection.Close();

            }
            return id;
        }

        public void Remove<T>(T item)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T item)
        {
            throw new NotImplementedException();
        }

        public T FindById<T>(int id) where T : class
        {
            T item;
            using (IDbConnection sqlConnection
             = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=BCAPIDatabase_Dev;Trusted_Connection=True;"))
            {
                sqlConnection.Open();

                item = sqlConnection.Get<T>(id);

                sqlConnection.Close();

            }
            return item;
        }
    }
}