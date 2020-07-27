using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.ConsoleTest.Models
{
    public class Sys_UserInfo
    {
        public int PKID { get; set; }
        public Guid UUID { get; set; }

        public string UserName { get; set; }
        public string CellPhone { get; set; }
        public string Password { get; set; }
        public bool Valid { get; set; }
        public DateTime CeatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string Remark { get; set; }
    }
}
