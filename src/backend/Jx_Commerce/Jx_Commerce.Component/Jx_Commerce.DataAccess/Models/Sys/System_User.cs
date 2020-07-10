using System;
using Jx_Commerce.DataAccess.DapperAccess.Mapping;
using Dapper;

namespace Jx_Commerce.DataAccess.Models.Sys
{
    //[Table("sys_userinfo")]
    public class System_User
    {
        [Column(Name ="id")]
        public int PKID { get; set; }

        [Column(Name = "name")]
        public string UserName { get; set; }

        [Column(Name = "phone")]
        public string CellPhone { get; set; }

        [Column(Name = "password")]
        public string Password { get; set; }

        [Column(Name = "valid")]
        public bool Valid { get; set; }

        [Column(Name = "createdtime")]
        public DateTime CeatedTime { get; set; }

        [Column(Name = "lastmodifiedtime")]
        public DateTime LastModifiedTime { get; set; }

        [Column(Name = "remark")]
        public string Remark { get; set; }
    }
}
