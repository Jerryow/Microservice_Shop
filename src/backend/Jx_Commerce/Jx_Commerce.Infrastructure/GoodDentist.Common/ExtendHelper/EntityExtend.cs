
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodDentist.Common;

namespace GoodDentist.Common.ExtendHelper
{
    public static class EntityExtend
    {
        /// <summary>
        /// class序列化扩展
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string EntitySerialize(this Entity entity)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(entity);
        }

        /// <summary>
        /// class序列化加密扩展
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string EntitySerializeEncript(this Entity entity)
        {
            return SecurityHelper.AESEncrypt2(Newtonsoft.Json.JsonConvert.SerializeObject(entity), System.Configuration.ConfigurationManager.AppSettings["PrivateKey"]);
        }

        /// <summary>
        /// 验证实体null
        /// 是实体  返回  true
        /// 不是实体 返回 false
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullEntity(this Entity source)
        {
            if (source == null)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 验证实体null
        /// 是实体  返回  true
        /// 不是实体 返回 false
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullEntity(this object source)
        {
            if (source == null)
            {
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// class扩展基类
    /// </summary>
    public class Entity
    {

    }
}
