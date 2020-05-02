using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace WebSys.APIWork.Common.cls
{
    public static class clsPublic
    {
        #region   Json
        /// <summary>
        /// 将实体类序列化为JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        static public string SerializeJSON<T>(T data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 反序列化JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        static public T DeserializeJSON<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 日期转换为时间戳（时间戳单位秒）
        /// </summary>
        /// <param name="TimeStamp"></param>
        /// <returns></returns>
        public static long ConvertToTimeStamp(DateTime time)
        {
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(time.AddHours(-8) - Jan1st1970).TotalMilliseconds;
        }

        /// <summary>
        /// string 转成JObjict对象
        /// </summary>
        /// <param name="jsonText">json文本</param>
        /// <returns>JObject对象</returns>
        public static JObject StringConvertToJson(string jsonText)
        {
            try {
                JObject jo = (JObject)JsonConvert.DeserializeObject(jsonText);
                //或者JObject jo = JObject.Parse(jsonText);
                return jo;
            }
            catch
            {
                return null;
            }
        }
       
        #endregion


    }
}
