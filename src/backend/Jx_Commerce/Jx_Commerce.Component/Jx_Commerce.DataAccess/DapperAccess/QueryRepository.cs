using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Jx_Commerce.DataAccess.DapperAccess.Entity;
using Kogel.Dapper.Extension.MySql;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jx_Commerce.DataAccess.DapperAccess
{
    public class QueryRepository<T,TKey> : IQueryRepository<T, TKey>
        where T : ModelEntity<TKey>
    {
        private readonly IExcuteDapper<T> _excuteEntity;
        public QueryRepository(IExcuteDapper<T> excuteEntity)
        {
            _excuteEntity = excuteEntity;
        }

        #region Single

        public T GetByID(TKey id)
        {
            return _excuteEntity.Excute(connection =>
            {
                return connection.QuerySet<T>()
                .Where(x => x.PKID.Equals(id))
                .Get();
            });
        }

        public async Task<T> GetByIDAsync(TKey id)
        {
            return await _excuteEntity.ExcuteAsync(async connection =>
            {
                return await connection.QuerySet<T>()
                .Where(x => x.PKID.Equals(id))
                .GetAsync();
            });
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _excuteEntity.Excute(connection =>
            {
                return connection.QuerySet<T>()
                .Where(expression)
                .Get();
            });
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _excuteEntity.ExcuteAsync(async connection =>
            {
                return await connection.QuerySet<T>()
                .Where(expression)
                .GetAsync();
            });
        }

        #endregion

        #region List

        public List<T> GetAllList()
        {
            return _excuteEntity.Excute(connection =>
            {
                return connection.QuerySet<T>()
                .ToList();
            });
        }

        public async Task<List<T>> GetAllListAsync()
        {
            return await _excuteEntity.ExcuteAsync(async connection =>
            {
                return await connection.QuerySet<T>()
                .ToListAsync();
            });
        }

        public List<T> GetAllList(Expression<Func<T, bool>> expression)
        {
            return _excuteEntity.Excute(connection =>
            {
                return connection.QuerySet<T>()
                .Where(expression)
                .ToList();
            });
        }

        public async Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> expression)
        {
            return await _excuteEntity.ExcuteAsync(async connection =>
            {
                return await connection.QuerySet<T>()
                .Where(expression)
                .ToListAsync();
            });
        }

        #endregion

        #region Count

        public int Count()
        {
            return _excuteEntity.Excute(connection =>
            {
                return connection.QuerySet<T>()
                .Count();
            });
        }

        #endregion
    }
}
