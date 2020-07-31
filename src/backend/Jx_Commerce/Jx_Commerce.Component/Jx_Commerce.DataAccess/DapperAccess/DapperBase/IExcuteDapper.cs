using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Jx_Commerce.DataAccess.DapperAccess.DapperBase
{
    public interface IExcuteDapper<T>
    {
        void Excute(Action<IDbConnection> handler);
        Task ExcuteAsync(Action<IDbConnection> handler);
        T Excute<T>(Func<IDbConnection, T> handler);
        Task<T> ExcuteAsync<T>(Func<IDbConnection, Task<T>> handler);
        void ExcuteTransaction(Action<IDbConnection, IDbTransaction> action);
    }

    public interface IExcuteDapperInterface<T>
        where T : class
    {
        T Get(int id);
        Task<T> GetAsync();
        List<T> GetList();
        Task<List<T>> GetListAsync();
    }
}
