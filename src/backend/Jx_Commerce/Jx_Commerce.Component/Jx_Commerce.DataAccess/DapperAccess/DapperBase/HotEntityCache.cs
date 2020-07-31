using Jx_Commerce.DataAccess.Models.Sys;
using Kogel.Dapper.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.DataAccess.DapperAccess.DapperBase
{
    public static class HotEntityCache
    {
        public static void HotEntity()
        {
            EntityCache.Register(typeof(System_User));
        }
    }
}
