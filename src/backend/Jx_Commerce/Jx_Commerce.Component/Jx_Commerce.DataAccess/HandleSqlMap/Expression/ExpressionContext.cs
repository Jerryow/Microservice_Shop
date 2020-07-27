using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Jx_Commerce.DataAccess.HandleSqlMap.MapProvider;

namespace Jx_Commerce.DataAccess.HandleSqlMap.Expression
{
    internal class ExpressionContext
    {
        public Type TableType { get; internal set; }

        public LambdaExpression WhereExpression { get; internal set; }

        public LambdaExpression IfNotExistsExpression { get; internal set; }

        public Dictionary<OperatorEnum.EnumOrderBy, LambdaExpression> OrderbyExpressionList { get; internal set; }

        public LambdaExpression SelectExpression { get; internal set; }

        public int? TopNum { get; internal set; }

        public bool NoLock { get; internal set; }
    }
}
