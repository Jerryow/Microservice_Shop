using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common
{
    public static class Tools
    {
        /// <summary>
        /// byte[] 转成stream流结果
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string StreamReaderToString(byte[] buffer)
        {
            StreamReader myStreamReader = new StreamReader(BytesToStream(buffer), Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            return retString;
        }

        /// <summary>
        /// 将 byte[] 转成 Stream
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// 字节数组生成图片
        /// </summary>
        /// <param name="Bytes">字节数组</param>
        /// <returns>图片</returns>
        public static Image ByteArrayToImage(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                Image outputImg = Image.FromStream(ms);
                return outputImg;
            }
        }

        /// <summary>
        /// 数据流转字节组
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] StreamToBytes(Stream stream)
        {
            List<byte> bytes = new List<byte>();
            int temp = stream.ReadByte();
            while (temp != -1)
            {
                bytes.Add((byte)temp);
                temp = stream.ReadByte();
            }
            return bytes.ToArray();
        }

        /// <summary>
        /// 生成随机串    
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <returns></returns>
        public static string GetRandomString(int length)
        {
            const string key = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            if (length < 1)
                return string.Empty;

            Random rnd = new Random();
            byte[] buffer = new byte[8];

            ulong bit = 31;
            ulong result = 0;
            int index = 0;
            StringBuilder sb = new StringBuilder((length / 5 + 1) * 5);

            while (sb.Length < length)
            {
                rnd.NextBytes(buffer);

                buffer[5] = buffer[6] = buffer[7] = 0x00;
                result = BitConverter.ToUInt64(buffer, 0);

                while (result > 0 && sb.Length < length)
                {
                    index = (int)(bit & result);
                    sb.Append(key[index]);
                    result = result >> 5;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成订单号
        /// </summary>
        /// <returns></returns>
        public static string GetRandomTime()
        {
            Random rd = new Random();//用于生成随机数
            string DateStr = DateTime.Now.ToString("yyyyMMddHHmmssMM");//日期
            string str = DateStr + rd.Next(10000).ToString().PadLeft(4, '0');//带日期的随机数
            return str;
        }

        /// <summary>
        /// MD5签名方法  
        /// </summary>  
        /// <param name="inputText">加密参数</param>  
        /// <returns></returns>  
        public static string MD5(string inputText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.UTF8.GetBytes(inputText);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }

            return byte2String;
        }


        public static string GetSignString(Dictionary<string, string> dic, string key)
        {
            dic = dic.OrderBy(d => d.Key).ToDictionary(d => d.Key, d => d.Value);
            //连接字段  
            var sign = dic.Aggregate("", (current, d) => current + (d.Key + "=" + d.Value + "&"));
            sign += "key=" + key;
            //MD5  
            // sign = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sign, "MD5").ToUpper();  
            //System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            //sign = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(sign))).Replace("-", null);
            sign = MD5(sign).ToUpper();
            return sign;
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTime()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);

        }
    }
}
