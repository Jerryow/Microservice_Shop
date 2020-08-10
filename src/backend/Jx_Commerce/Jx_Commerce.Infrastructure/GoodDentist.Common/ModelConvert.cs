using GoodDentist.Common.ExtendHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common
{
    /// <summary>
    /// 实体转换
    /// </summary>
    public class ModelConvert
    {
        public static IList<string> Propertys<T>() where T : class
        {
            IList<string> result = new List<string>();
            Type t = typeof(T);
            PropertyInfo[] arypi = t.GetProperties();
            Dictionary<string, Object> hst = new Dictionary<string, Object>();
            foreach (PropertyInfo p in arypi)
            {
                try
                {
                    result.Add(p.Name);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        /// 将一个DataSet数据集 转换成制定list 
        /// </summary>
        /// <typeparam name="T">类</typeparam>k
        /// <param name="ds">数据集</param>
        /// <param name="TopNum">取多少条数据，为空全取</param>
        /// <returns></returns>
        public static List<T> DataSetToModelList<T>(DataSet ds)
        {
            List<T> newList = new List<T>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                T model = FromDataRow<T>(ds.Tables[0].Rows[i]);
                newList.Add(model);
            }
            return newList;
        }
        public static List<T> DataSetToModelListTwo<T>(DataSet ds)
        {
            List<T> newList = new List<T>();
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                T model = FromDataRow<T>(ds.Tables[1].Rows[i]);
                newList.Add(model);
            }
            return newList;
        }
        /// <summary>
        /// 将一个DataSet数据集 转换成键值对list 
        /// </summary>
        /// <param name="ds">数据源</param>
        /// <returns></returns>
        public static List<object> DataSetToObjectList(DataSet ds)
        {
            List<object> newList = new List<object>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                newList.Add(RowToCollection(ds.Tables[0].Rows[i]));
            }
            return newList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <returns></returns>
        public static List<Dictionary<string, object>> DataTableToDicList(DataTable dt)
        {
            List<Dictionary<string, object>> newList = new List<Dictionary<string, object>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                newList.Add(RowToCollection(dt.Rows[i]));
            }
            return newList;
        }
        /// <summary>
        /// 实体属性转换
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="ValidFields">有效字段</param>
        /// <returns></returns>
        public static Dictionary<string, Object> ToCollection(object mod, IList<string> ValidFields = null)
        {
            Type t = mod.GetType();
            PropertyInfo[] arypi = t.GetProperties();
            Dictionary<string, Object> hst = new Dictionary<string, Object>();
            bool isIgnoreNull = true;
            foreach (PropertyInfo p in arypi)
            {
                try
                {
                    if (ValidFields != null && ValidFields.Count > 0)
                    {
                        isIgnoreNull = false;
                        if (!ValidFields.Contains(p.Name))
                        {
                            continue; //不在有效字段列表忽略
                        }

                    }

                    if (p.GetValue(mod, null) == null && isIgnoreNull) continue; //忽略空值
                    hst.Add(p.Name, p.GetValue(mod, null));
                }
                catch (Exception ex)
                {
                    //SysLog.WriteLog(ref ex);
                    throw ex;
                }
            }
            return hst;
        }
        /// <summary>
        /// 实体属性转换
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="ValidFields">有效字段</param>
        /// <returns></returns>
        public static T ToEntity<T>(Dictionary<string, Object> hst)
        {
            Type t = typeof(T);
            object actObj = Activator.CreateInstance(t);
            PropertyInfo[] arypi = t.GetProperties();

            foreach (PropertyInfo p in arypi)
            {
                try
                {
                    if (hst.ContainsKey(p.Name))
                        p.SetValue(actObj, hst[p.Name] is DBNull ? null : hst[p.Name], null);

                }
                catch (Exception ex)
                {
                   // Logger.Error(string.Format("行-》对象转换失败{0}", "FromDataRow"), ex);

                }
            }
            return (T)actObj;
        }

        /// <summary>
        /// 实体转换为Sql参数
        /// </summary>
        /// <typeparam name="entity"></typeparam>
        /// <param name="mod"></param>
        /// <param name="IDIgnore">是否忽略ID,默认false 不忽略ID</param>
        /// <param name="NullValueIgnore">是否忽略为Null的属性,默认True 忽略</param>
        /// <returns></returns>
        public static SqlParameter[] ToSqlParameters(object entity, bool IDIgnore = false, bool NullValueIgnore = true)
        {
            List<SqlParameter> ls = new List<SqlParameter>();
            Type t = entity.GetType();
            PropertyInfo[] arypi = t.GetProperties();
            foreach (PropertyInfo p in arypi)
            {
                try
                {
                    if (p.GetValue(entity, null) != null && NullValueIgnore)
                    {
                        if (p.Name.ToLower() == "id")
                        {
                            if (IDIgnore) continue;
                        }
                        SqlParameter sp = new SqlParameter(p.Name, p.GetValue(entity, null));
                        ls.Add(sp);
                    }
                }
                catch (Exception ex)
                {
                    //Logger.Error("ModelConvert.ToSqlParameters1", ex);
                }
            }
            SqlParameter[] arySp = (SqlParameter[])ls.ToArray<SqlParameter>();
            return arySp;
        }

        /// <summary>
        /// 行数据转换到实体
        /// </summary>
        /// <typeparam name="Entity"></typeparam>
        /// <param name="drv"></param>
        /// <returns></returns>
        public static Entity FromDataRow<Entity>(DataRow drv)
        {
            Type t = typeof(Entity);
            object actObj = Activator.CreateInstance(t);
            PropertyInfo[] arypi = t.GetProperties();

            foreach (PropertyInfo p in arypi)
            {
                try
                {
                    if (drv.Table.Columns.Contains(p.Name))
                    {
                        p.SetValue(actObj, drv[p.Name] is DBNull ? null : drv[p.Name], null);
                    }
                }
                catch (Exception ex)
                {
                    //Logger.Error(string.Format("行-》对象转换失败{0}", "FromDataRow"), ex);

                }
            }
            return (Entity)actObj;
        }
        /// <summary>
        /// 行对象转换
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Dictionary<string, Object> RowToCollection(DataRow row, ColNameFormat ColNameFormat = ColNameFormat.Default)
        {
            return RowToCollection(row, null, ColNameFormat);
        }
        public static Dictionary<string, Object> RowToCollection(DataRow row, Func<string, object, object> ColValFormat, ColNameFormat ColNameFormat = ColNameFormat.Default)
        {
            Dictionary<string, Object> hst = new Dictionary<string, Object>();
            foreach (DataColumn dc in row.Table.Columns)
            {
                if (ColValFormat != null)
                {
                    hst.Add(dc.ColumnName, ColValFormat(dc.ColumnName, row[dc.ColumnName]));
                }
                else
                {
                    hst.Add(dc.ColumnName, row[dc.ColumnName]);
                }
            }
            return hst;
        }

        /// <summary>
        /// 字段，值》序Json队形序列化支持
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static ArrayList TableToList(DataTable table, ColNameFormat ColNameFormat = ColNameFormat.Default)
        {
            return TableToList(table, null, ColNameFormat);
        }
        public static ArrayList TableToList(DataTable table, Func<string, object, object> ColValFormat, ColNameFormat ColNameFormat = ColNameFormat.Default)
        {
            ArrayList al = new ArrayList();
            foreach (DataRow row in table.Rows)
            {
                al.Add(RowToCollection(row, ColValFormat));
            }
            return al;
        }
        public static Entity FormCollection<Entity>(Dictionary<string, Object> dict)
        {
            Type t = typeof(Entity);
            object actObj = Activator.CreateInstance(t);
            PropertyInfo[] arypi = t.GetProperties();

            foreach (PropertyInfo p in arypi)
            {
                try
                {
                    if (dict.ContainsKey(p.Name))
                    {
                        var pt = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                        if (pt.IsNumberType() && dict[p.Name] is string)
                        {
                            if (dict[p.Name].ToString() == "")
                            {
                                p.SetValue(actObj, null, null);
                                continue;
                            }
                        }

                        if (pt == typeof(DateTime) && dict[p.Name].ToString() == "")
                        {
                            p.SetValue(actObj, null, null);
                            continue;
                        }

                        object safeValue = (dict[p.Name].ToString() == null) ? null
                                       : Convert.ChangeType(dict[p.Name], pt);

                        p.SetValue(actObj, safeValue, null);
                    }
                }
                catch (Exception ex)
                {
                    //Logger.Error(string.Format("Dictionary-》对象转换失败{0}", "FormCollection"), ex);

                }
            }
            return (Entity)actObj;
        }
        /// <summary>  
        /// List集合转DataTable  
        /// </summary>  
        /// <typeparam name="T">实体类型</typeparam>  
        /// <param name="list">传入集合</param>  
        /// <param name="isStoreDB">是否存入数据库DateTime字段，date时间范围没事，取出展示不用设置TRUE</param>  
        /// <returns>返回datatable结果</returns>  
        public static DataTable ListToTable<T>(List<T> list, bool isStoreDB = true)
        {
            Type tp = typeof(T);
            PropertyInfo[] proInfos = tp.GetProperties();
            DataTable dt = new DataTable();
            foreach (var item in proInfos)
            {
                dt.Columns.Add(item.Name, item.PropertyType); //添加列明及对应类型  
            }
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (var proInfo in proInfos)
                {
                    object obj = proInfo.GetValue(item);
                    if (obj == null)
                    {
                        continue;
                    }
                    //if (obj != null)  
                    // {  
                    if (isStoreDB && proInfo.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
                    {
                        continue;
                    }
                    // dr[proInfo.Name] = proInfo.GetValue(item);  
                    dr[proInfo.Name] = obj;
                    // }  
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// json字符串反序列化成对象
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="obj">json字符串</param>
        /// <returns></returns>
        public static T JsonToModel<T>(string obj)
        {
            return ConvertToEntity<T>(obj);
        }
        /// <summary>
        /// json字符串反序列化成对象,
        /// 重载，用于更改，传入要更改的对象
        /// </summary>
        /// <typeparam name="T">要修改的对象</typeparam>
        /// <param name="obj">json字符串</param>
        /// <returns></returns>
        public static T JsonToModel<T>(string obj, T m)
        {
            return ConvertToEntity<T>(obj, m);
        }
        /// <summary>
        /// 生产json格式字符串
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="obj">实例对象</param>
        /// <returns></returns>
        public static string ModelToJson<T>(T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        #region Json数据转换为泛型集合(或实体)

        /// <summary>
        /// 单条json数据转换为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">字符窜（格式为{a:'',b:''}）</param>
        /// <returns></returns>
        static T ConvertToEntity<T>(string str)
        {
            Type t = typeof(T);
            object obj = Activator.CreateInstance(t);
            var properties = t.GetProperties();
            string m = str.Trim('[').Trim(']');
            m = m.Trim('{').Trim('}');
            string[] arr = m.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Count(); i++)
            {

                string Name = arr[i].Substring(0, arr[i].IndexOf(":")).Trim(new char[] { '"' }).ToUpper();
                object Value = (object)arr[i].Substring(arr[i].IndexOf(":") + 1).Trim(new char[] { '"' });
                foreach (PropertyInfo p in properties)
                {
                    try
                    {
                        if (Name.Equals(p.Name.ToUpper()))
                        {
                            if (!p.PropertyType.IsGenericType)
                            {
                                //非泛型
                                p.SetValue(obj, string.IsNullOrEmpty(Value.ToString()) || Value.Equals("null") ? null : Convert.ChangeType(Value, (p.PropertyType)), null);
                                break;
                            }
                            else
                            {
                                //泛型Nullable<>
                                Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                {
                                    p.SetValue(obj, string.IsNullOrEmpty(Value.ToString()) ? null : Convert.ChangeType(Value, Nullable.GetUnderlyingType(p.PropertyType)), null);
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.Error(string.Format("行-》对象转换失败{0}", "FromDataRow"), ex);
                    }
                }
            }
            return (T)obj;
        }

        /// <summary>
        /// 单条json数据转换为实体  
        /// 重载：将对象传进方法，将在对象基础上进行序列化，不产生新的对象
        ///            该方法用在编辑一个对象时候使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        static T ConvertToEntity<T>(string str, T model)
        {
            Type t = typeof(T);
            object obj = Activator.CreateInstance(t);
            obj = (object)model;
            var properties = t.GetProperties();
            string m = str.Trim('[').Trim(']');
            m = m.Trim('{').Trim('}');
            string[] arr = m.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Count(); i++)
            {
                string Name = arr[i].Substring(0, arr[i].IndexOf(":")).Trim(new char[] { '"' }).ToUpper();
                object Value = (object)arr[i].Substring(arr[i].IndexOf(":") + 1).Trim(new char[] { '"' });
                foreach (PropertyInfo p in properties)
                {
                    try
                    {
                        if (Name.Equals(p.Name.ToUpper()))
                        {
                            if (!p.PropertyType.IsGenericType)
                            {
                                //非泛型
                                p.SetValue(obj, string.IsNullOrEmpty(Value.ToString()) || Value.Equals("null") ? null : Convert.ChangeType(Value, (p.PropertyType)), null);
                                break;
                            }
                            else
                            {
                                //泛型Nullable<>
                                Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                                if (genericTypeDefinition == typeof(Nullable<>))
                                {
                                    p.SetValue(obj, string.IsNullOrEmpty(Value.ToString()) ? null : Convert.ChangeType(Value, Nullable.GetUnderlyingType(p.PropertyType)), null);
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.Error(string.Format("行-》对象转换失败{0}", "FromDataRow"), ex);

                    }
                }
            }
            return (T)obj;
        }


        /// <summary>
        /// 多条Json数据转换为泛型数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonArr">字符窜（格式为[{a:'',b:''},{a:'',b:''},{a:'',b:''}]）</param>
        /// <returns></returns>
        static List<T> ConvertTolist<T>(string jsonArr)
        {
            if (!string.IsNullOrEmpty(jsonArr) && jsonArr.StartsWith("[") && jsonArr.EndsWith("]"))
            {
                Type t = typeof(T);
                var proPerties = t.GetProperties();
                List<T> list = new List<T>();
                string recive = jsonArr.Trim('[').Trim(']').Replace("'", "").Replace("\"", "");
                string[] reciveArr = recive.Replace("},{", "};{").Split(';');
                foreach (var item in reciveArr)
                {
                    T obj = ConvertToEntity<T>(item);
                    list.Add(obj);
                }
                return list;
            }
            return null;

        }
       
        #endregion
        public enum ColNameFormat
        {
            /// <summary>
            /// 默认
            /// </summary>
            Default,

            /// <summary>
            /// 小写
            /// </summary>
            Lower,

            /// <summary>
            /// 大写
            /// </summary>
            Upper
        }
    }//class
}
