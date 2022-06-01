using System.Data;

namespace NetCore.Domain.Interfaces.Repositories.DataConnector;

public interface IDbConnector : IDisposable
{
    IDbConnection dbConnection { get; }
    IDbTransaction dbTransaction { get; set; }
}