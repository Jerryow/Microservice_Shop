using Dapper;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Jx_Commerce.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=jerryow;database=world"))
            {
                
                var sql = conn.GetSql<Sys_UserInfo>().SubstringLast();
                Console.WriteLine(sql);

                //var data = conn.Query<Dapp>("select a.PKID, a.UserName from sys_userinfo as a").ToList();
                var data = conn.Query<Sys_UserInfo>(sql).ToList();
                data.ForEach(item =>
                {
                    Console.WriteLine("PKID:" + item.PKID);
                    Console.WriteLine("UserName:" + item.UserName);
                    Console.WriteLine("CellPhone:" + item.CellPhone);
                    Console.WriteLine("Password:" + item.Password);
                    Console.WriteLine("Valid:" + item.Valid);
                    Console.WriteLine("CeatedTime:" + item.CeatedTime);
                    Console.WriteLine("LastModifiedTime:" + item.LastModifiedTime);
                    Console.WriteLine("Remark:" + item.Remark);
                    Console.WriteLine("**********************************************************************");
                });

                Console.WriteLine(sql);

            }

            Console.ReadKey();
        }
    }

    public class Sys_UserInfo
    {
        public int PKID { get; set; }

        public string UserName { get; set; }
        public string CellPhone { get; set; }
        public string Password { get; set; }
        public bool Valid { get; set; }
        public DateTime CeatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public string Remark { get; set; }
    }

    public static class QueryExt
    {
        public static string GetSql<T>(this IDbConnection dbConnection)
        {
            var type = typeof(T);
            StringBuilder sql = new StringBuilder();
            sql.Append("select ");
            var paras = type.GetProperties();
            for (int i = 0; i < paras.Length; i++)
            {
                if (i == paras.Length - 1)
                {
                    sql.Append("Extend." + paras[i].Name + " \r\n");
                }
                else
                {
                    sql.Append("Extend." + paras[i].Name + ", \r\n");
                }
            }
            sql.Append("from " + type.Name + " as Extend " );
            return sql.ToString();
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
