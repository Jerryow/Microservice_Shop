using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common.ExtendHelper
{
    public static class EncryptExtend
    {
        /// <summary>
        /// 加密扩展
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncryptString(this string str)
        {
           return SecurityHelper.AESEncrypt2(str, System.Configuration.ConfigurationManager.AppSettings["PrivateKey"]);
        }

        /// <summary>
        /// 解密扩展
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecryptString(this string str)
        {
            return SecurityHelper.AESDecrypt2(str, System.Configuration.ConfigurationManager.AppSettings["PrivateKey"]);
        }
    }
}
