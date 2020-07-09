using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.Common.Extensions.ObjectExtend
{
    public static class ObjectCompareExtend
    {
        #region 判Null
        /// <summary>
        /// 验证对象null
        /// 是Null  返回  true
        /// 不是Null 返回 false
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsEntityNullOrNot(this object source)
        {
            if (source == null)
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}
