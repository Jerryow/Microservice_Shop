using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Jx_Commerce.ConsoleTest.Aop.Attr
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AopAttrAttribute : Attribute
    {
        //组装管道
        public Action Do(Action action)
        {
            return () =>
            {
                Console.WriteLine("这个是Aop特性1----->前");
                var paras = action.Method.GetGenericArguments();
                for (int i = 0; i < paras.Length; i++)
                {

                }
                action.Invoke();
                Console.WriteLine("这个是Aop特性1----->后");
            };
        }
    }
}
