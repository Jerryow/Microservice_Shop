using Jx_Commerce.DataAccess.DapperAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jx_Commerce.DataAccess.DapperAccess.DapperBase
{
    public interface IQueryRepository<T,TKey>
        where T : ModelEntity<TKey>
    {
        #region Query
        T GetByID(TKey id);

        Task<T> GetByIDAsync(TKey id);

        T FirstOrDefault(Expression<Func<T, bool>> expression);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);

        List<T> GetAllList();

        Task<List<T>> GetAllListAsync();

        List<T> GetAllList(Expression<Func<T, bool>> expression);

        Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> expression);
        #endregion

        #region Count
        int Count();
        #endregion
    }
}
