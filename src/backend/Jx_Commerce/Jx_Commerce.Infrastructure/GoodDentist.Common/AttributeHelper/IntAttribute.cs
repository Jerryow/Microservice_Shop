using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common.AttributeHelper
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]
    public class IntAttribute : Attribute
    {
        /// <summary>
        /// 长度构造
        /// </summary>
        /// <param name="min">最小值(参数可等于/0除外)</param>
        /// <param name="max">最大值(参数可等于/0除外)</param>
        public IntAttribute(int min, int max)
        {
            if (min <= 0)
            {
                this.MinValue = 0;
            }
            else
            {
                this.MinValue = min;
            }

            if (max <= 0)
            {
                this.MaxValue = 0;
            }
            else
            {
                this.MaxValue = max;
            }
        }

        public string ErrorMsg { get; set; }

        public int MaxValue { get; set; }

        public int MinValue { get; set; }

        /// <summary>
        /// 内置验证-->提供给验证特性调用
        /// </summary>
        /// <param name="name">验证的参数的名称</param>
        /// <param name="val">当前值</param>
        /// <returns></returns>
        public bool Validate(string name, int val)
        {
            if (this.MinValue >= this.MaxValue)
            {
                this.ErrorMsg = string.Format("{0}设定的最小值不能大于或等于最大值", name);
                return false;
            }

            if (val <= 0)
            {
                this.ErrorMsg = string.Format("{0}的值必须大于0", name);
                return false;
            }

            if (val <= this.MaxValue && val >= this.MinValue)
            {
                return true;
            }

            this.ErrorMsg = string.Format("{0}的值必须大于等于{1}且小于等于{2}", name, this.MinValue, this.MaxValue);
            return false;
        }
    }
}
