using System;

namespace Jx_Commerce.SystemService
{
    public interface ITest
    {
        string SaySomething(string msg);
    }
    public class Test : ITest
    {
        public string SaySomething(string msg)
        {
            return msg;
        }
    }
}
