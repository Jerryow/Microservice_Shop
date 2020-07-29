using System;
using System.Collections.Generic;
using System.Text;

namespace Jx_Commerce.Common.CustomAttr
{
    public class MappingTableAttribute : Attribute
    {
        public string TableName { get; set; }

        public MappingTableAttribute(string _tableName)
        {
            this.TableName = _tableName;
        }
    }
}
