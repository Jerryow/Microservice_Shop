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

        System_User GetSystemUser();
        Task<List<System_User>> GetSystemUserListAsync();
    }
    public class Test : ITest
    {
        private readonly IExcuteDapper<System_User> _systemUser;
        public Test(IExcuteDapper<System_User> systemUser)
        {
            _systemUser = systemUser;
        }
        public System_User GetSystemUser()
        {
            return _systemUser.Excute(connection =>
            {
                var sql = "select * from sys_userinfo where id = 1";
                //return connection.Query<System_User>(sql).Select(x => new System_User()
                //{
                //    PKID = x.id,
                //    UserName = x.name,
                //    CellPhone = x.phone,
                //    Password = x.password,
                //    Valid = x.valid,
                //    CeatedTime = x.createdtime,
                //    LastModifiedTime = x.lastmodifiedtime,
                //    Remark = x.remark
                //});
                return connection.Query<System_User>(sql);
            }).FirstOrDefault();
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
