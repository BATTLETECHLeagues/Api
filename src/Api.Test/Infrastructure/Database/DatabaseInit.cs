using System;
using System.Data.SqlClient;
using System.IO;
using NUnit.Framework;

namespace Api.Test.Infrastructure.Database
{
    public class DatabaseInit
    {
        public static void CreateDatabase(string databaseName)
        {
            var connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB");
            using (connection)
            {
                connection.Open();

                var dataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "Local", "BCPAPI","Data");

                if (!Directory.Exists(dataDirectory))
                    Directory.CreateDirectory(dataDirectory);

                var sql = string.Format(@"
                CREATE DATABASE
                [{1}]
                ON PRIMARY (
                NAME=Test_data,
                FILENAME = '{0}\{1}_data.mdf'
                )
                LOG ON (
                NAME=Test_log,
                FILENAME = '{0}\{1}_log.ldf'
                )", dataDirectory, databaseName);

                var command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteDatabase(string databaseName)
        {
            var connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB");
            using (connection)
            {
                connection.Open();

                var sql = $@"
                    IF EXISTS(select * from sys.databases where name={databaseName})
                    DROP DATABASE Test2";

                var command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public static bool DatabaseExists(string databaseName)
        {
            var connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB");
            using (connection)
            {
                connection.Open();

                var sql = $@"select * from sys.databases where name={databaseName}";

                var command = new SqlCommand(sql, connection);
                var result = command.ExecuteReader();

                if (result.HasRows)
                    return true;
            }

            return false;
        }
    }
}