using Jx_Commerce.ConsoleTest.Aop.Attr;
using Jx_Commerce.ConsoleTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.ConsoleTest.Container.Base
{
    public interface ITest
    {
        Sys_Student Get(int id);
    }

    public class Test : ITest
    {
        public Sys_Student Get(int id)
        {
            if (id == 1)
            {
                return new Sys_Student()
                {
                    PKID = 1,
                    Name = "111",
                    UserID = 1
                };
            }

            return new Sys_Student()
            {
                PKID = 2,
                Name = "222",
                UserID = 2
            };
        }
    }

    public interface ITestAop
    {
        [AopAttr]
        BaseModel<Sys_Student> Get(int id);
    }

    public class TestAop : ITestAop
    {
        private readonly ITest _test;
        public TestAop(ITest test)
        {
            this._test = test;
        }
        public BaseModel<Sys_Student> Get(int id)
        {
            Console.WriteLine("搞点事情*************");
            return new BaseModel<Sys_Student>()
            {
                IsValid = true,
                Msg = "",
                Data = this._test.Get(id)
            };
        }
    }
}
