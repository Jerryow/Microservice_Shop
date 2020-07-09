using System;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Jx_Commerce.DataAccess.DapperAccess
{
    public class ExcuteDapperBase
    {
        private readonly string _connectionString;

        public ExcuteDapperBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected void Execute(Action<IDbConnection> handler)
        {
            using (IDbConnection connection = CreateSqlConnection())
            {
                handler(connection);
            }
        }

        protected T Execute<T>(Func<IDbConnection, T> handler)
        {
            using (IDbConnection connection = CreateSqlConnection())
            {
                return handler(connection);
            }
        }

        protected Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> handler)
        {
            using (IDbConnection connection = CreateSqlConnection())
            {
                return handler(connection);
            }
        }

        protected void ExecuteTransaction(Action<IDbConnection, IDbTransaction> action)
        {
            using (IDbConnection connection = CreateSqlConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    action(connection, transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
