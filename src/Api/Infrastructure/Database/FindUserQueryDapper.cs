using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Api.Domain;
using Dapper;

namespace Api.Infrastructure
{
    public class FindUserQueryDapper :FindUserQuery
    {
        public User Execute(string userName)
        {
            //var dog = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });
            List<User> users;

            using (IDbConnection sqlConnection
    = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=BCAPIDatabase_Dev;Trusted_Connection=True;"))
            {
                sqlConnection.Open();

                users = sqlConnection.Query<User>($"Select * from Users where UserName={userName}").ToList();

                sqlConnection.Close();

               

            }

            if (users.Count() != 1)
                return null;
            else
            {
                return users.First();
            }

            throw new System.NotImplementedException();
        }
    }
}