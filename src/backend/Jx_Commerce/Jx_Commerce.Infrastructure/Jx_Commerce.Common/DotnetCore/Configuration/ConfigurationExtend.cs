using Microsoft.Extensions.Configuration;
using Jx_Commerce.Common.Extensions.ObjectExtend;
using System.Collections.Generic;

namespace Jx_Commerce.Common.DotnetCore.Configuration
{
    public static class ConfigurationExtend
    {
        /// <summary>
        /// 获取顶级Section
        /// 匹配结果有值则返回,没有则返回空字符串
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static string GetSectionExtend(this IConfiguration configuration, string nodeName)
        {
            var section = configuration.GetSection(nodeName);
            if (section.IsEntityNullOrNot())
            {
                return "";
            }
            return section.Value;
        }

        /// <summary>
        /// 获取多级Section
        /// 如多级名称一样,将从上到家匹配第一个返回
        /// 匹配结果有值则返回,没有则返回空字符串
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="highNodeName">顶级section名称</param>
        /// <param name="targetNodeName">需要找的section名称</param>
        /// <returns></returns>
        //public static string GetSection(this IConfiguration configuration, string highNodeName, string targetNodeName)
        //{
        //    var 
        //}
    }
}
