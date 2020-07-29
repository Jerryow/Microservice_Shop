using System;
using Jx_Commerce.DataAccess.DapperAccess.Mapping;
using Dapper;
using Jx_Commerce.Common.CustomAttr;

namespace Jx_Commerce.DataAccess.Models.Sys
{
    [MappingTable("sys_userinfo")]
    public class System_User
    {
        public int PKID { get; set; }

        public string UserName { get; set; }

        public string CellPhone { get; set; }

        public string Password { get; set; }

        public bool Valid { get; set; }

        public DateTime CeatedTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        public string Remark { get; set; }
    }
}
