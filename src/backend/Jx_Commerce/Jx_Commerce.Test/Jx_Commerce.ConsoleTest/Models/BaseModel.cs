using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.ConsoleTest.Models
{
    public class BaseModel<T>
    {
        public bool IsValid { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
    }
}
