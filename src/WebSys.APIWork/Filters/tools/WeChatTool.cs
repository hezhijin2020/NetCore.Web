using System.IO;
using System.Net;
using System.Text;

namespace WebSys.APIWork.Filters.tools
{
    public static class WeChatTool
    {
        private static readonly string appid = "wx1fbe11921dd5ccc5";
        private static readonly string appsecret = "77fb8b19961fda452d8726214d406762";

        /// <summary>
        /// 获取微信客户端的在本应用程序中的OpenId(唯一标识串)
        /// </summary>
        /// <param name="Code">微信小程序的请求码（本次有效）</param>
        /// <returns>OpenId</returns>
        public static string GetWeChatOpenIdByCode(string Code)
        {
            string Url = string.Format(" https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code", appid, appsecret, Code);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "textml;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string jsonData = myStreamReader.ReadToEnd();
            response.Close();
            myStreamReader.Close();
            myResponseStream.Close();

            ;

            string key = "\"openid\":\"";
            int startIndex = jsonData.IndexOf(key);
            if (startIndex != -1)
            {
                int endIndex = jsonData.IndexOf("\",", startIndex);
                string openid = jsonData.Substring(startIndex + key.Length, endIndex - startIndex - key.Length);
                return openid;
            }
            else
            {
                return "";
            }
        }
    }
}