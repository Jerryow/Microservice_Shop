using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodDentist.Common;
using GoodDentist.Common.Token;

namespace GoodDentist.Common.ExtendHelper
{
    public static class TokenExtend
    {
        /// <summary>
        /// token解密扩展
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static TokenEntity TokenDecrypt(this string token, string privateKey)
        {
            var decrypt = SecurityHelper.AESDecrypt2(token, privateKey);
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TokenEntity>(decrypt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// token是否在有效期
        /// true 有效
        /// false 过期
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static bool TokenValid(this TokenEntity token)
        {
            if (token.ExpireTime > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
