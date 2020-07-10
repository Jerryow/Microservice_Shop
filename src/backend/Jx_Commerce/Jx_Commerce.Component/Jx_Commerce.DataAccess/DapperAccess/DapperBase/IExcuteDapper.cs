using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Jx_Commerce.DataAccess.DapperAccess.DapperBase
{
    public interface IExcuteDapper<T>
    {
        //void Excute(Action<IDbConnection> handler);
        //int ExcuteResult(Action<IDbConnection> handler);
        //Task ExcuteAsync(Action<IDbConnection> handler);
        //Task<int> ExcuteAsync(Action<IDbConnection, Task<int>> handler);
        T Excute<T>(Func<IDbConnection, T> handler);
        //Task<T> ExcuteAsync(Action<IDbConnection,Task<T>> handler);
        //void ExecuteTransaction(Action<IDbConnection, IDbTransaction> action);
    }
}
