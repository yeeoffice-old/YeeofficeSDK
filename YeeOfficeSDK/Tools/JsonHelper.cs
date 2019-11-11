using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YeeOfficeSDK.Tools
{
    public class JsonHelper
    {
        /// <summary>
        /// 序列化对象至Json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializationToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 序列化Json至指定的类型
        /// </summary>
        /// <returns></returns>
        public static T DeserializeJsonTo<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        /// <summary>
        /// 序列化Json至指定数据类型
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static object DeserializeJson(string jsonData, Type t)
        {
            return JsonConvert.DeserializeObject(jsonData, t);
        }

        /// <summary>
        /// 序列化Json字符串至Object对象
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static object DeserializeJsonToObject(string jsonData)
        {
            return JsonConvert.DeserializeObject(jsonData);
        }
    }

    public class Long2StringConverter : JsonConverter
    {
        /// <summary>
        /// 是否允许转换
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            bool canConvert = false;
            switch (objectType.FullName)
            {
                case "System.Int64":
                    canConvert = true;
                    break;
            }
            return canConvert;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long temp = 0;
            long.TryParse(existingValue + "", out temp);
            return temp;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value + "");
        }

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 是否允许转换JSON字符串时调用
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
    }

    public class DateTime2IOSStringConverter : Newtonsoft.Json.JsonConverter
    {
        /// <summary>
        /// 是否允许转换
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            bool canConvert = false;
            switch (objectType.FullName)
            {
                case "System.DateTime":
                    canConvert = true;
                    break;
            }
            return canConvert;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime temp = DateTime.MinValue;
            DateTime.TryParse(existingValue + "", out temp);
            return temp;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(DateTime.Parse(value + "").ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 是否允许转换JSON字符串时调用
        /// </summary>
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
    }
}
