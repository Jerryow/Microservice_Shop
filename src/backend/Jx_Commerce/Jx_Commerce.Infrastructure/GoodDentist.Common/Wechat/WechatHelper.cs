using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodDentist.Common.Wechat
{
    public static class WechatHelper
    {
        /// <summary>
        /// 获取微信的token
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static WeChatToken GetWechatAccessToken(string appid, string secret)
        {
            var tokenUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret + "";
            var result = HttpHelper.HttpGetRequest(tokenUrl);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<WeChatToken>(result);
        }

        /// <summary>
        /// 获取小程序二维码
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static WechatPicResponse GetMiniPic(MiniWeChatPic pic, string accessToken)
        {
            var oup = new WechatPicResponse();
            var url = string.Format("https://api.weixin.qq.com/wxa/getwxacodeunlimit?access_token={0}", accessToken);
            var postDataStr = Newtonsoft.Json.JsonConvert.SerializeObject(pic);

            var res = HttpHelper.HttpPostRequest(url, postDataStr, "application/json");

            var data = res.GetResponseStream();

            var buffer = HttpHelper.StreamToBytes(data);

            string retString = HttpHelper.StreamReaderToString(buffer);
            data.Close();

            if (retString.ToLower().Contains("errcode"))
            {
                oup.IsOK = false;
                return oup;
            }

            oup.IsOK = true;
            oup.Buffer = buffer;

            return oup;
        }

        ///// <summary>
        ///// 批量获取公众号openid列表
        ///// </summary>
        ///// <param name="accessToken"></param>
        ///// <param name="openid"></param>
        ///// <returns></returns>
        //public static WechatBatchOpenID GetBatchOpenID(string accessToken, string openid)
        //{
        //    var tokenUrl = "https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + accessToken + "&next_openid=" + openid;
        //    var result = Common.Tools.HttpHelper.HttpGetRequest(tokenUrl);

        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<WechatBatchOpenID>(result);
        //}

        ///// <summary>
        ///// 根据openid获取基本信息
        ///// </summary>
        ///// <param name="accessToken"></param>
        ///// <param name="openid"></param>
        ///// <returns></returns>
        //public static OpenBasicInfo GetOpenBasic(string accessToken, string openid)
        //{
        //    var tokenUrl = "https://api.weixin.qq.com/cgi-bin/user/info?access_token=" + accessToken + "&openid=" + openid + "&lang=zh_CN";
        //    var result = Common.Tools.HttpHelper.HttpGetRequest(tokenUrl);

        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<OpenBasicInfo>(result);
        //}
    }
}
