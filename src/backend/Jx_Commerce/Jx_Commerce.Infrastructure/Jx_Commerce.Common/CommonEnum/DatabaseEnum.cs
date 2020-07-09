using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.Common.CommonEnum
{
    public class DatabaseEnum
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public enum DbTypeEnum
        { 
            Mysql = 1,
            SqlServer = 2,
            Oracle = 3
        }

        /// <summary>
        /// 读写分离
        /// </summary>
        public enum ReadWriteDbEnum
        { 
            Read = 1,
            Write = 2
        }
    }
}
