using Dapper;
using System.Data;

namespace DapperStoredProcedure.Services
{
    public interface IDapperRepository
    {
        T Execute_sp<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string query, DynamicParameters sp_params, CommandType commandType = CommandType.StoredProcedure);
    }
}
