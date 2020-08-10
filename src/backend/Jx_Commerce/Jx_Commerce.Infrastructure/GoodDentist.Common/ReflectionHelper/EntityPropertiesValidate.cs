using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GoodDentist.Common.ExtendHelper;
using GoodDentist.Common.AttributeHelper;

namespace GoodDentist.Common.ReflectionHelper
{
    public static class EntityPropertiesValidate
    {
        /// <summary>
        /// 配合EntityDto特性验证
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ValidateModel EntityValidate<TEntity>(TEntity entity)
        {
            var rtn = new ValidateModel();
            rtn.BoolResult = true;
            rtn.Message = "";
            if (entity == null)
            {
                rtn.BoolResult = false;
                rtn.Message = "实体不能为null";
                return rtn;
            }
            var type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //判断是否Int32
                if (properties[i].PropertyType.ToString().ToLower().IsInt())
                {
                    //判断是否标记有特性
                    if (properties[i].IsDefined(typeof(IntAttribute)))
                    {
                        var attr = properties[i].GetCustomAttribute<IntAttribute>();
                        rtn.BoolResult = attr.Validate(properties[i].Name, (int)properties[i].GetValue(entity));
                        if (!rtn.BoolResult)
                        {
                            rtn.Message = attr.ErrorMsg;
                            return rtn;
                        }
                        continue;
                    }
                }

                //判断是否String
                if (properties[i].PropertyType.ToString().ToLower().IsString())
                {
                    //判断是否标记有特性
                    if (properties[i].IsDefined(typeof(StringAttribute)))
                    {
                        var attr = properties[i].GetCustomAttribute<StringAttribute>();
                        rtn.BoolResult = attr.Validate(properties[i].Name, (string)properties[i].GetValue(entity));
                        if (!rtn.BoolResult)
                        {
                            rtn.Message = attr.ErrorMsg;
                            return rtn;
                        }
                        continue;
                    }
                }

            }

            return rtn;
        }
    }

    public class ValidateModel
    {
        public bool BoolResult { get; set; }

        public string Message { get; set; }
    }
}
