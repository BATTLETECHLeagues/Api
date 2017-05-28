using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Api.Domain;
using Dapper;

namespace Api.Infrastructure
{


    public class FindSessionForUserDapper : FindSessionForUser
    {
        public UserSession Execute(string sessionKey)
        {
            List<UserSession> users;

            var connectionstring = ConfigurationManager.ConnectionStrings["BCDB"];
            using (IDbConnection sqlConnection = new SqlConnection(connectionstring.ConnectionString))
            {
                sqlConnection.Open();

                users = sqlConnection.Query<UserSession>($"Select * from UserSessions where SessionKey='{sessionKey}'").ToList();

                sqlConnection.Close();
            }

            return users.Count != 1 ? null : users.First();
        }

    }
}