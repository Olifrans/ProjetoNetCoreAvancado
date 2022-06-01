using System.Data;

namespace NetCore.Domain.Interfaces.Repositories.DataConnector;

public interface IDbConnector : IDisposable
{
    IDbConnection bdConnection { get; set; }
    IDbTransaction dbTransaction { get; set; }
}