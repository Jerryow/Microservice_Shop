using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Jx_Commerce.Common.CustomAttr;
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
        //public ExcuteDapperBase()
        {
            _configuration = configuration;
            _connectionStr = _configuration.GetSection("DataAccess:ConnectionStr:Master").Value;
            //_connectionStr = "";
        }

        private IDbConnection CreateSqlConnection()
        {
            return new MySqlConnection(_connectionStr);
        }


        public void Excute(Action<IDbConnection> handler)
        {
            using (IDbConnection connection = CreateSqlConnection())
            {
                handler(connection);
            }
        }

        public async Task ExcuteAsync(Action<IDbConnection> handler)
        {
            using (IDbConnection connection = CreateSqlConnection())
            {
                await Task.Factory.StartNew(() =>
                {
                    handler(connection);
                });
            }
        }

        public T Excute<T>(Func<IDbConnection, T> handler)
        {
            using (IDbConnection connection = CreateSqlConnection())
            {
                return handler(connection);
            }
        }

        public async Task<T> ExcuteAsync<T>(Func<IDbConnection, Task<T>> handler)
        {
            using (IDbConnection connection = CreateSqlConnection())
            {
               return await handler(connection);
            }
        }

        public void ExcuteTransaction(Action<IDbConnection, IDbTransaction> action)
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

    public class ExcuteDapper<T> : IExcuteDapperInterface<T>
        where T : class
    {
        private readonly IExcuteDapper<T> _excuteEntity;
        public ExcuteDapper(IExcuteDapper<T> excuteEntity)
        {
            _excuteEntity = excuteEntity;
        }
        public T Get(int id)
        {
            return _excuteEntity.Excute(connection =>
            {
                var attrs = typeof(T).GetCustomAttributes(typeof(MappingTableAttribute), true);
                var attr = (MappingTableAttribute)attrs.FirstOrDefault();
                var sql = $"select * from {attr.TableName} where PKID = {id}";
                Console.WriteLine(sql);
                return connection.Query<T>(sql);
            }).FirstOrDefault();
        }

        public Task<T> GetAsync()
        {
            throw new NotImplementedException();
        }

        public List<T> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
