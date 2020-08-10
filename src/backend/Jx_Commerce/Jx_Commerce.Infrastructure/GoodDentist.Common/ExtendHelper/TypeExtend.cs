using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common.ExtendHelper
{
    public static class TypeExtend
    {
        #region 根据Type的FullName判断具体类型
        /// <summary>
        /// 判断是否是int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(this string str)
        {
            if (str == "system.int32")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否是string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsString(this string str)
        {
            if (str == "system.string")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否是GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsGuid(this string str)
        {
            if (str == "system.guid")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否是datetime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDatetime(this string str)
        {
            if (str == "system.datetime")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否是Bool
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBoolean(this string str)
        {
            if (str == "system.boolean")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否是Decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string str)
        {
            if (str == "system.decimal")
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 根据String的值判断具体类型
        /// <summary>
        /// 判断是否是GUID
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsGuidString(this string str)
        {
            //判断是否是Guid
            var def = Guid.NewGuid();
            var res = Guid.TryParse(str, out def);
            if (!res)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region String类型转换
        /// <summary>
        /// string 转 int32
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StringToInt32(this string str)
        {
            var res = 0;
            var bol = Int32.TryParse(str, out res);
            return res;
        }

        /// <summary>
        /// string 转 guid
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid StringToGuid(this string str)
        {
            //判断是否是Guid
            var def = Guid.NewGuid();
            var res = Guid.TryParse(str, out def);
            return def;
        }

        /// <summary>
        /// string 转 datetime
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime StringToDateTime(this string str)
        {
            //判断是否是Guid
            var def = DateTime.Now;
            var res = DateTime.TryParse(str, out def);
            return def;
        }
        
        /// <summary>
        /// string 转 bool
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StringToBoolean(this string str)
        {
            //判断是否是bool
            var def = false;
            var res = Boolean.TryParse(str, out def);
            return def;
        }

        /// <summary>
        /// string 转 decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal StringToDecimal(this string str)
        {
            //判断是否是decimal
            var def = default(decimal);
            var res = decimal.TryParse(str, out def);
            return def;
        }
        #endregion

        #region 手机号处理
        /// <summary>
        /// 手机号脱敏
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncriptPhone(this string str)
        {
            var front = str.Substring(0, 3);
            var end = str.Substring(str.Length - 4, 4);
            return string.Format("{0}****{1}", front, end);
        }
        #endregion

        #region Guid类型转换
        /// <summary>
        /// 批量Guid转String
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static List<string> GuidTostringList(this List<Guid> source)
        {
            var res = new List<string>();
            if (source.Count > 0)
            {
                source.ForEach(item =>
                {
                    res.Add(item.ToString());
                });
            }
            return res;
        }

        /// <summary>
        /// 判断是否是默认guid
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsDefualtGuid(this Guid source)
        {
            if (source == default(Guid))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// split转guid
        /// </summary>
        /// <param name="source"></param>
        /// <param name="splitSymbol"></param>
        /// <returns></returns>
        public static List<Guid> SplitToGuid(this string source, char splitSymbol)
        {
            try
            {
                if (string.IsNullOrEmpty(source))
                {
                    return null;
                }
                var res = new List<Guid>();
                var ids = source.Split(splitSymbol);
                for (int i = 0; i < ids.Length; i++)
                {
                    if (!string.IsNullOrEmpty(ids[i]))
                    {
                        //判断是否是Guid
                        var def = default(Guid);
                        var idRes = Guid.TryParse(ids[i], out def);
                        if (idRes)
                        {
                            res.Add(def);
                        }
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Decimal类型转换
        /// <summary>
        /// 保留小数后n位
        /// </summary>
        /// <param name="source"></param>
        /// <param name="saveCount">保留位数</param>
        /// <returns></returns>
        public static decimal MatchRound(this decimal source, int saveCount)
        {
            return decimal.Round(source, saveCount);
        }
        #endregion

        #region Split处理
        /// <summary>
        /// 移除空值后split的字符串,如果异常返回原始值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitSymbol"></param>
        /// <returns></returns>
        public static string RemoveNullSplit(this string str, char splitSymbol)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return str;
                }
                var strs = str.Split(splitSymbol);
                var res = "";
                for (int i = 0; i < strs.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strs[i]))
                    {
                        res += strs[i];
                        res += splitSymbol.ToString();
                    }
                }
                //移除最后一个符号
                res = res.Substring(0, res.Length - 1);
                return res;
            }
            catch (Exception ex)
            {
                return str;
            } 
        }
        #endregion

        public static bool IsNumberType(this object value)
        {
            if (value is Type)
            {
                return value == typeof(sbyte)
                    || value == typeof(byte)
                    || value == typeof(short)
                    || value == typeof(ushort)
                    || value == typeof(int)
                    || value == typeof(uint)
                    || value == typeof(long)
                    || value == typeof(ulong)
                    || value == typeof(float)
                    || value == typeof(double)
                    || value == typeof(decimal);
            }

            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}
