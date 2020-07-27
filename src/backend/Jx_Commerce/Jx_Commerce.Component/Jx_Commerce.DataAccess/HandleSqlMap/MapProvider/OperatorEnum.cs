using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.DataAccess.HandleSqlMap.MapProvider
{
    public class OperatorEnum
    {
        internal enum EnumOperateType
        {
            Query,
            Command
        }

        public enum EnumOrderBy
        {
            Asc = 1,
            Desc = -1
        }
    }
}
