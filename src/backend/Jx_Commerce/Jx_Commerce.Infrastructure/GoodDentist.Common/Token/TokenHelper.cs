using GoodDentist.Common.ExtendHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodDentist.Common.Token
{
    public static class TokenHelper
    {
        public static string GetToken(Guid key, CommonEnums.ClientType clientType, DateTime expiredTime)
        {
            var token = new TokenEntity();
            token.ClientType = clientType.GetHashCode();
            token.ExpireTime = expiredTime;
            token.KeyCode = key.ToString();

            return token.EntitySerializeEncript();
        }
    }
    
    public class TokenEntity : Entity
    {

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ExpireTime { get; set; }
        /// <summary>
        /// 主键Code
        /// </summary>
        public string KeyCode { get; set; }

        /// <summary>
        /// 有效载荷
        /// </summary>
        public int ClientType { get; set; }
    }
}