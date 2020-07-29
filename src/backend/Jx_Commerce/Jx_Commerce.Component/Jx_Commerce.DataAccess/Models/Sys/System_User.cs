using System;
using Jx_Commerce.DataAccess.DapperAccess.Mapping;
using Dapper;
using Jx_Commerce.Common.CustomAttr;
using System.ComponentModel.DataAnnotations.Schema;
using Kogel.Dapper.Extension.Attributes;
using Jx_Commerce.DataAccess.DapperAccess.Entity;

namespace Jx_Commerce.DataAccess.Models.Sys
{
    [Display(Rename = "sys_userinfo")]
    public class System_User : ModelEntity
    {
        public string UserName { get; set; }

        public string CellPhone { get; set; }

        public string Password { get; set; }

        public bool Valid { get; set; }

        public DateTime CeatedTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        public string Remark { get; set; }
    }
}
