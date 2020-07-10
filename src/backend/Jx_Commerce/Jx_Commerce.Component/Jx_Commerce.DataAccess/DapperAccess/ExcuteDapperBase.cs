using System;
using System.Data;
using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Jx_Commerce.DataAccess.DapperAccess
{
    public class ExcuteDapperBase<T> : IExcuteDapper<T>
    {
        private readonly string _connectionStr;
        private readonly IConfiguration _configuration;
        public ExcuteDapperBase(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionStr = _configuration.GetSection("DataAccess:ConnectionStr:Master").Value;
        }

        private IDbConnection CreateSqlConnection()
        {
            return new MySqlConnection(_connectionStr);
        }

        //public void Excute(Action<IDbConnection> handler)
        //{
        //    using (IDbConnection connection = CreateSqlConnection())
        //    {
        //        handler(connection);
        //    }
        //}

        public T Excute<T>(Func<IDbConnection, T> handler)
        {
            Console.WriteLine(_connectionStr);
            using (IDbConnection connection = CreateSqlConnection())
            {
                Console.WriteLine(connection.State);
                return handler(connection);
            }
        }

        //public async Task ExcuteAsync(Action<IDbConnection> handler)
        //{
        //    var task = Task.Factory.StartNew(() =>
        //    {
        //        using (IDbConnection connection = CreateSqlConnection())
        //        {
        //            handler(connection);
        //        }
        //    });

        //    await task;
        //}

        //public Task<int> ExcuteAsync(Action<IDbConnection, Task<int>> handler)
        //{
        //    throw new NotImplementedException();
        //}


        //public Task<T> ExcuteAsync(Action<IDbConnection, Task<T>> handler)
        //{
        //    throw new NotImplementedException();
        //}

        //public int ExcuteResult(Action<IDbConnection> handler)
        //{
        //    throw new NotImplementedException();
        //}

        //public void ExecuteTransaction(Action<IDbConnection, IDbTransaction> action)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
