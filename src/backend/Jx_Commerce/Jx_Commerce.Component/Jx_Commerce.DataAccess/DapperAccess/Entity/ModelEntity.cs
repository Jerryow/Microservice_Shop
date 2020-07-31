using Kogel.Dapper.Extension.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.DataAccess.DapperAccess.Entity
{
    /// <summary>
    /// 所有
    /// </summary>
    public class ModelEntity<T>
    {
        [Identity(IsIncrease = true)]
        public T PKID { get; set; }
    }
}
