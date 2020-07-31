using Dapper;
using Jx_Commerce.Common.CustomAttr;
using Jx_Commerce.ConsoleTest.Container.Base;
using Jx_Commerce.ConsoleTest.Models;
using Jx_Commerce.DataAccess.Models.Sys;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.MySql;
using Jx_Commerce.DataAccess.DapperAccess.DapperBase;

namespace Jx_Commerce.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=123456;database=test"))
                //{

                //    var sql = conn.GetSql<Sys_UserInfo>()
                //                  .GetSqlJoin<Sys_UserInfo, int, Sys_Student, int>(x => x.PKID, x => x.UserID);




                //    ////var data = conn.Query<Dapp>("select a.PKID, a.UserName from sys_userinfo as a").ToList();
                //    //var data = conn.Query<Sys_UserInfo>(sql).ToList();
                //    //data.ForEach(item =>
                //    //{
                //    //    Console.WriteLine("PKID:" + item.PKID);
                //    //    Console.WriteLine("UserName:" + item.UserName);
                //    //    Console.WriteLine("CellPhone:" + item.CellPhone);
                //    //    Console.WriteLine("Password:" + item.Password);
                //    //    Console.WriteLine("Valid:" + item.Valid);
                //    //    Console.WriteLine("CeatedTime:" + item.CeatedTime);
                //    //    Console.WriteLine("LastModifiedTime:" + item.LastModifiedTime);
                //    //    Console.WriteLine("Remark:" + item.Remark);
                //    //    Console.WriteLine("**********************************************************************");
                //    //});

                //    Console.WriteLine(sql);

                //}
                ////var aa = new List<int>() {12,33,2,54 }.AsQueryable().Where(x => x > 10).ToList();
                //Expression<Func<int, bool>> expr = x => x > 10;
                //var a =expr.Compile().Invoke(12);
                //Console.WriteLine(a);

                //var str = "select * from sys_userinfo ";
                //str = str.GetSqlEx<Sys_UserInfo>(x => x.PKID > 3);

                //Expression<Func<Sys_UserInfo, bool>> lmd = x => x.PKID == 1;

                //Visitor visitor = new Visitor();
                //visitor.Visit(lmd);
                //Console.WriteLine(visitor.Condition());

                //Console.WriteLine(str);
            }

            //单表sql测试
            {
                //var sql = "";
                //sql = sql.SingleTranslate<Sys_UserInfo, int>(
                //    x => x.PKID == 1 && x.Valid == true && x.UserName == "admin" && x.UserName.EndsWith("a") && x.CreatedTime == DateTime.Now
                //    );
                //var uu = Guid.NewGuid();
                //var sql = "";
                //sql = sql.SingleTranslate<Sys_UserInfo, int>(x => x.CeatedTime <= DateTime.Now.AddHours(3) && x.UUID == uu);

                //var ss = "DateTime.Now.AddDays(11000)";
                //Console.WriteLine(ss.Split('.').Length);
                //var sql = "";
                //sql = sql.GetSql<Sys_UserInfo>()
                //         .WhereCondition<Sys_UserInfo, bool>(x => x.PKID  ==  1);
                //Console.WriteLine(sql);

                //Console.WriteLine(Convert.ToDateTime("DateTime.Now"));
            }

            //多表join测试
            {

                //var sql = "";
                //sql = sql.GetSql<Sys_UserInfo>()
                //                 .GetSqlJoin<Sys_UserInfo, int, Sys_Student, int>(x => x.PKID, x => x.UserID)
                //                 .GetSqlJoin<Sys_Student, int, Sys_Teacher, int>(x => x.PKID, x => x.StudentID);
                //Console.WriteLine(sql);
            }

            //表达式Visitor测试
            {
                //var a = new {id = 1};
                //var sql = "";
                //var aa = new aa();
                //sql = sql.ExpressionT<Sys_UserInfo>(x => x.UUID== Guid.NewGuid());
                //Console.WriteLine(sql);
            }

            //aop
            {
                //var test = Container.Container.Resolve<ITestAop>();
                //var data = test.Get(12321);
                //Console.WriteLine(data.Msg);
            }

            //Kogel.Dapper
            {
                var getData = Container.Container.Resolve<GetData>();
                var data = getData.GetByID(2).Result;

                //using (var conn = new MySqlConnection(""))
                //{
                //    var user = conn.QuerySet<sys_userinfo>()
                //        .Where(x => x.PKID == 2)
                //        .Get();
                //}
            }

            Console.ReadKey();
        }
    }

    public class GetData
    {
        private readonly IQueryRepository<System_User, int> _service;
        public GetData(IQueryRepository<System_User, int> service)
        {
            _service = service;
        }

        public async Task<System_User> GetByID(int id)
        {
            return await _service.GetByIDAsync(2);
        }
    }

    public static class TransferSql
    {
        public static int getid()
        {
            return 1;
        }
        #region Single
        /// <summary>
        /// 单表完全查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="whereExpression"></param>
        /// <param name="orderByExpression"></param>
        /// <param name="isAsc"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static string SingleTranslate<T, TKey>(this string str, Expression<Func<T, bool>> whereExpression = null, Expression<Func<T, TKey>> orderByExpression = null, bool? isAsc = null, int pageIndex = 0, int pageSize = 0)
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

            if (whereExpression != null)
            {
                sql.Append(" where ");
                Visitor visitor = new Visitor();
                visitor.SetName(whereExpression, type.Name);
                sql.Append(visitor.Condition());
            }

            if (orderByExpression != null)
            {
                sql.Append("\r\n  order by " + type.Name + ".PKID ");
                if (isAsc != null)
                {
                    if (isAsc.Value)
                    {
                        sql.Append(" asc");
                    }
                    else
                    {
                        sql.Append(" desc");
                    }
                }
            }

            return sql.ToString();
        }
        #endregion



        #region dsa

        public static string GetSql<T>(this string str, Expression<Func<T, bool>> expr = null)
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
        #endregion

    }
    public class aa
    {
        public int getid()
        {
            return 1;
        }
    }
    public static class CompareSql
    {
        public static string WhereCondition<T, TKey>(this string originalSql, Func<T, TKey> func)
        {
            StringBuilder whereBuilder = new StringBuilder();
            whereBuilder.Append(" where ");
            whereBuilder.Append($" {typeof(T).Name}.{typeof(TKey).Name} ");
            return originalSql + whereBuilder.ToString();
        }

        public static string EqulsSql(this string left, string right)
        {
            return $" {left} = {right}";
        }

        public static string ExpressionT<T>(this string str, Expression<Func<T, bool>> expr = null)
        {
            StringBuilder sql = new StringBuilder();

            if (expr != null)
            {
                sql.Append($" where ");
                Visitor visitor = new Visitor();
                visitor.SetName(expr, typeof(T).Name);
                sql.Append(visitor.Condition());
            }

            return sql.ToString();
        }
    }
    public class Visitor : ExpressionVisitor
    {
        private Stack<string> _StringStack = new Stack<string>();
        private string TypeName { get; set; }

        public System.Linq.Expressions.Expression SetName(System.Linq.Expressions.Expression node, string name)
        {
            this.TypeName = name;
            return Visit(node);
        }

        public override System.Linq.Expressions.Expression Visit(System.Linq.Expressions.Expression node)
        {
            return base.Visit(node);
        }

        public string Condition()
        {
            string condition = string.Concat(this._StringStack.ToArray());
            this._StringStack.Clear();
            return condition;
        }

        /// <summary>
        /// 二元表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override System.Linq.Expressions.Expression VisitBinary(BinaryExpression node)
        {
            if (node == null) throw new ArgumentNullException("BinaryExpression");


            if (node.Right.ToString().Contains("DateTime.Now"))
            {
                var date = node.Right.ToString().Split('.');
                if (date.Length == 2)
                {
                    this._StringStack.Push(" '" + DateTime.Now.ToString() + "' ");
                }
                else if (date.Length > 2 && date[2].Contains("("))
                {
                    var now = DateTime.Now;
                    var method = date[2].Split('(')[0];
                    var para = date[2].Split('(')[1].Split(')')[0];
                    var type = typeof(DateTime);
                    var data = type.GetMethod(method).Invoke(now, new object[] { Convert.ToInt32(para) });
                    this._StringStack.Push(" '" + data.ToString() + "' ");
                }
            }
            else
            {
                base.Visit(node.Right);//解析右边
            }
            this._StringStack.Push(" " + node.NodeType.ToSqlOperator() + " ");
            base.Visit(node.Left);//解析左边

            return node;
        }

        /// <summary>
        /// 访问成员
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override System.Linq.Expressions.Expression VisitMember(MemberExpression node)
        {
            if (node == null) throw new ArgumentNullException("MemberExpression");
            this._StringStack.Push(TypeName + "." + node.Member.Name + " ");
            return node;
        }

        /// <summary>
        /// 常量表达式
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override System.Linq.Expressions.Expression VisitConstant(ConstantExpression node)
        {
            if (node == null) throw new ArgumentNullException("ConstantExpression");

            if (node.Type == typeof(int))
            {
                this._StringStack.Push(" " + node.Value + " ");
            }
            else if (node.Type == typeof(bool))
            {
                if ((bool)node.Value)
                {
                    this._StringStack.Push(" " + 1 + " ");
                }
                else
                {
                    this._StringStack.Push(" " + 0 + " ");
                }
            }
            else if (node.Type == typeof(DateTime))
            {
                this._StringStack.Push(" " + (DateTime)node.Value + " ");
            }
            else if (node.Type == typeof(string))
            {
                this._StringStack.Push(" '" + node.Value + "' ");
            }
            else if (node.Type == typeof(Guid))
            {
                this._StringStack.Push(" " + node.Value + " ");
            }
            else
            {
                this._StringStack.Push(" '" + node.Value + "' ");
            }
            return node;
        }


        /// <summary>
        /// 方法表达式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        protected override System.Linq.Expressions.Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m == null) throw new ArgumentNullException("MethodCallExpression");

            //var obj = Activator.CreateInstance(type);
            //var val = obj.
            string format;
            switch (m.Method.Name)
            {
                case "StartsWith":
                    format = " {0} LIKE '{1}%' ";
                    break;

                case "Contains":
                    format = " {0} LIKE '%{1}%' ";
                    break;

                case "EndsWith":
                    format = " {0} LIKE '%{1}' ";
                    break;

                default:
                    var cl = MethodInfoExtensions.GetBaseDefinition(m.Method);
                    var type = Type.GetType(cl.DeclaringType.FullName);
                    if (type.IsAbstract)
                    {
                        var me = type.GetMethod(m.Method.Name);
                        var data = me.Invoke(type, null);
                    }
                    else
                    {
                        var obj = Activator.CreateInstance(type);
                        var me = type.GetMethod(m.Method.Name);
                        var data = me.Invoke(obj, null);
                    }

                    format = " {0} = {1} ";
                    break;
            }
            this.Visit(m.Object);
            this.Visit(m.Arguments[0]);
            string right = "";
            right = this._StringStack.Pop().Trim().Substring(1).SubstringLast();
            string left = this._StringStack.Pop();
            this._StringStack.Push(String.Format(format, left, right));

            return m;
        }
    }

}
