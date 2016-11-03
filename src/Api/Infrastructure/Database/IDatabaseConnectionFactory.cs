using System.Data;

namespace Api.Infrastructure.Database
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}