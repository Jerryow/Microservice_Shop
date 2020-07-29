using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Jx_Commerce.DataAccess.Models.Sys;
using Kogel.Dapper.Extension.MsSql;
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
            throw new NotImplementedException();
        }

        public Task<System_User> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
