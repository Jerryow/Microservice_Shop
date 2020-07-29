using Dapper;
using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Jx_Commerce.DataAccess.Models.Sys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jx_Commerce.SystemService
{
    public interface ITest
    {
        string SaySomething(string msg);
        [AopAttr]
        System_User GetSystemUser(int id);
        Task<List<System_User>> GetSystemUserListAsync();
    }
    public class Test : ITest
    {
        private readonly IExcuteDapperInterface<System_User> _systemUser;
        public Test(IExcuteDapperInterface<System_User> systemUser)
        {
            _systemUser = systemUser;
        }
        public System_User GetSystemUser(int id)
        {
            return _systemUser.Get(id);
        }

        public Task<List<System_User>> GetSystemUserListAsync()
        {
            throw new System.NotImplementedException();
        }

        public string SaySomething(string msg)
        {
            return msg;
        }
    }
}
