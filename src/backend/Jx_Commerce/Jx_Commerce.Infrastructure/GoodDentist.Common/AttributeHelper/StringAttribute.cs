using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common.AttributeHelper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StringAttribute : Attribute
    {
        /// <summary>
        /// 判空及Guid
        /// </summary>
        /// <param name="isGuid">
        /// 是否是Guid
        /// true:默认不可空
        /// </param>
        /// <param name="isRequire">是否要求不为空</param>
        public StringAttribute(bool isGuid, bool isRequire)
        {
            this.IsGuid = isGuid;
            this.IsRequire = isRequire;
            this.ConstractorType = 1;
        }

        /// <summary>
        /// 判字符串长度
        /// </summary>
        /// <param name="min">最小值(可等于/0除外)</param>
        /// <param name="max">最打值(可等于/0除外)</param>
        public StringAttribute(int min, int max)
        {
            this.IsRequire = true;
            this.IsGuid = false;
            this.ConstractorType = 2;

            if (min <= 0)
            {
                this.MinLength = 0;
            }
            else
            {
                this.MinLength = min;
            }

            if (max <= 0)
            {
                this.MaxLength = 0;
            }
            else
            {
                this.MaxLength = max;
            }
        }

        public string ErrorMsg { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public bool IsRequire { get; set; }
        public bool IsGuid { get; set; }

        /// <summary>
        /// 1---> 只判空和guid
        /// 2---> 以非空为基准判断长度是否匹配
        /// </summary>
        public int ConstractorType { get; set; }

        /// <summary>
        /// 内置验证-->提供给验证特性调用
        /// </summary>
        /// <param name="name">验证的参数的名称</param>
        /// <param name="val">当前值</param>
        /// <returns></returns>
        public bool Validate(string name, string val)
        {
            if (this.ConstractorType == 1)
            {
                //判断GUID
                if (this.IsGuid)
                {
                    //判空
                    if (this.IsRequire)
                    {
                        if (string.IsNullOrEmpty(val))
                        {
                            this.ErrorMsg = string.Format("{0}的值不能为空", name);
                            return false;
                        }
                        else
                        {
                            //判断是否是Guid
                            var def = Guid.NewGuid();
                            var res = Guid.TryParse(val, out def);
                            if (!res)
                            {
                                this.ErrorMsg = string.Format("{0}的格式错误", name);
                                return false;
                            }
                            return true;
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(val))
                        {
                            //判断是否是Guid
                            var def = Guid.NewGuid();
                            var res = Guid.TryParse(val, out def);
                            if (!res)
                            {
                                this.ErrorMsg = string.Format("{0}的格式错误", name);
                                return false;
                            }
                            return true;
                        }
                        return true;
                    }

                }
                else
                {
                    if (this.IsRequire)
                    {
                        //判空
                        if (string.IsNullOrEmpty(val))
                        {
                            this.ErrorMsg = string.Format("{0}的值不能为空", name);
                            return false;
                        }
                    }
                    return true;
                }
            }

            //判空
            if (string.IsNullOrEmpty(val))
            {
                this.ErrorMsg = string.Format("{0}的值不能为空", name);
                return false;
            }

            if (this.MinLength >= this.MaxLength)
            {
                this.ErrorMsg = string.Format("{0}设定的最小值不能大于或等于最大值", name);
                return false;
            }


            if (val.Length <= this.MaxLength && val.Length >= this.MinLength)
            {
                return true;
            }

            this.ErrorMsg = string.Format("{0}的值必须大于等于{1}且小于等于{2}", name, this.MinLength, this.MaxLength);
            return false;


        }
    }
}
