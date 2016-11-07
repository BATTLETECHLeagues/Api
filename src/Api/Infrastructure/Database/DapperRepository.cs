using System;
using System.Data;
using System.Data.SqlClient;
using Api.Domain;
using Dapper.Contrib.Extensions;

namespace Api.Infrastructure
{
    public class DapperRepository : IRepository
    {
        private long supplierId;
        public long Insert<T>(T item) where T : class
        {
            using (IDbConnection sqlConnection
             = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=BCAPIDatabase_Dev;Trusted_Connection=True;"))
            {
                sqlConnection.Open();

                supplierId = sqlConnection.Insert(item);

                sqlConnection.Close();

            }
            return supplierId;
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