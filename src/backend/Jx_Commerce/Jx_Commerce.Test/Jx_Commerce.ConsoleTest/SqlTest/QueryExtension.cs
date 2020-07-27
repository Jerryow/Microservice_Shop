using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;

namespace Jx_Commerce.ConsoleTest.SqlTest
{
    public static class QueryExtension
    {
        public static string GetSql<T>(this IDbConnection dbConnection, Expression<Func<T, bool>> expr = null)
        {
            var type = typeof(T);
            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            var paras = type.GetProperties();
            for (int i = 0; i < paras.Length; i++)
            {
                if (i == paras.Length - 1)
                {
                    sql.Append(type.Name + "." + paras[i].Name + " \r\n");
                }
                else
                {
                    sql.Append(type.Name + "." + paras[i].Name + ", \r\n");
                }
            }
            sql.Append("from " + type.Name + "");

            if (expr != null)
            {
                sql.Append(" where ");
                Visitor visitor = new Visitor();
                visitor.Visit(expr);
                sql.Append(visitor.Condition());
            }

            return sql.ToString();
        }

        public static string GetSqlJoin<TFirst, TFirstKey, TSecond, TSecondKey>(this string str, Expression<Func<TFirst, TFirstKey>> first, Expression<Func<TSecond, TSecondKey>> second)
        {
            var firstEntity = typeof(TFirst);
            var secondEntity = typeof(TSecond);
            StringBuilder sql = new StringBuilder();
            sql.Append(str);
            sql.Append("\r\n join " + secondEntity.Name + " \r\n on");
            sql.Append(" " + firstEntity.Name + ".PKID = " + secondEntity.Name + ".UserID");


            return sql.ToString();
        }

        public static string GetSqlEx<T>(this string str, Expression<Func<T, bool>> expr)
        {
            //ExpressionVisitor visitor = new ExpressionVisitor();
            //var vis = ExpressionVisitor.Visit(expr);
            return "";
        }

        public static string ToSqlOperator(this ExpressionType type)
        {
            switch (type)
            {
                case (ExpressionType.AndAlso):
                case (ExpressionType.And):
                    return "AND";
                case (ExpressionType.OrElse):
                case (ExpressionType.Or):
                    return "OR";
                case (ExpressionType.Not):
                    return "NOT";
                case (ExpressionType.NotEqual):
                    return "<>";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                case (ExpressionType.Equal):
                    return "=";
                default:
                    throw new Exception("不支持该方法");
            }
        }

        /// <summary>
        /// 截图最后一个字符
        /// </summary>
        /// <returns></returns>
        public static string SubstringLast(this string str)
        {
            return str.Substring(0, str.Length - 1);
        }

    }
}
