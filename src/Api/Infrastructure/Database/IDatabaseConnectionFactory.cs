using System.Data;

namespace Api.Infrastructure
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}