using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Jx_Commerce.DataAccess.DapperAccess.Entity;
using Jx_Commerce.DataAccess.Models.Sys;
using Kogel.Dapper.Extension.MySql;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jx_Commerce.ConsoleTest.Container.Base
{
    public interface ISystem_UserService
    {
        System_User GetByID(int id);

        Task<System_User> GetByIDAsync(int id);

        System_User FirstOrDefault(Expression<Func<System_User, bool>> expression);

        Task<System_User> FirstOrDefaultAsync(Expression<Func<System_User, bool>> expression);
    }

    public class System_UserService : ISystem_UserService
    {
        private readonly IExcuteDapper<System_User> _excuteEntity;
        public System_UserService(IExcuteDapper<System_User> excuteEntity)
        {
            _excuteEntity = excuteEntity;
        }
        #region Single
        public System_User FirstOrDefault(Expression<Func<System_User, bool>> expression)
        {
            return _excuteEntity.Excute(connection =>
            {
                return connection.QuerySet<System_User>()
                .Where(expression)
                .Get();
            });
        }

        public async Task<System_User> FirstOrDefaultAsync(Expression<Func<System_User, bool>> expression)
        {
            return await _excuteEntity.ExcuteAsync(async connection =>
            {
                return await connection.QuerySet<System_User>()
                .Where(expression)
                .GetAsync();
            });
        }

        public System_User GetByID(int id)
        {
            return _excuteEntity.Excute(connection =>
            {
                return connection.QuerySet<System_User>()
                .Where(x => x.PKID == id)
                .Get();
            });
        }

        public async Task<System_User> GetByIDAsync(int id)
        {
            return await _excuteEntity.ExcuteAsync(async connection =>
            {
                return await connection.QuerySet<System_User>()
                .Where(x => x.PKID == id)
                .GetAsync();
            });
        }
        #endregion

    }

    public interface ISystem_UserServiceT<T>
        where T : ModelEntity
    {
        #region Query
        T GetByID(int id);

        Task<T> GetByIDAsync(int id);

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

    public class System_UserServiceT<T> : ISystem_UserServiceT<T>
        where T : ModelEntity
    {
        private readonly IExcuteDapper<T> _excuteEntity;
        public System_UserServiceT(IExcuteDapper<T> excuteEntity)
        {
            _excuteEntity = excuteEntity;
        }

        #region Single
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

        public T GetByID(int id)
        {
            return _excuteEntity.Excute(connection =>
            {
                return connection.QuerySet<T>()
                .Where(x => x.PKID == id)
                .Get();
            });
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _excuteEntity.ExcuteAsync(async connection =>
            {
                return await connection.QuerySet<T>()
                .Where(x => x.PKID == id)
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
