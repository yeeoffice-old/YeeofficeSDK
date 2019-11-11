using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace YeeOfficeSDK.Tools
{
    public static class ObjectBase
    {
        public static string Convert2Json(this object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return JsonHelper.SerializationToJson(obj);
        }

        public static int Convert2Int32(this object obj)
        {
            int temp;
            int.TryParse(obj + "", out temp);
            return temp;
        }

        public static bool Convert2Boolean(this object obj)
        {
            string str = obj + "";
            return (str == "1" || str.ToLower() == "true");
        }
        private static readonly string[] supportDateTimeFormats = new string[] {
                    "yyyy-MM-dd",
                    "yyyy-MM-dd HH:mm:ss",
                    "yyyy-MM-dd HH:mm",
                    "yyyy-MM-dd HH" };
        private static readonly string[] supportTimeFormats = new string[] { "HH:mm:ss", "HH:mm", "HH" };
        public static DateTime Convert2DateTime(this object obj)
        {
            DateTime temp;
            var str = obj + "";
            if (DateTime.TryParse(str, out temp))
            {
                return temp;
            }
            var provider = CultureInfo.InvariantCulture;
            //带时分秒的转换
            if (DateTime.TryParseExact(str, supportDateTimeFormats, provider, DateTimeStyles.None, out temp))
            {
                return temp;
            }
            //时分秒的转换-1970-01-01 
            if (DateTime.TryParseExact(str, supportTimeFormats, provider, DateTimeStyles.None, out temp))
            {
                temp = new DateTime(1970, 1, 1).Add(temp.TimeOfDay);
            }
            return temp;
        }

        public static long Convert2Int64(this object obj)
        {
            long temp = 0;
            long.TryParse(obj + "", out temp);
            return temp;
        }

        public static decimal Convert2Decimal(this object obj)
        {
            decimal temp = 0;
            decimal.TryParse(obj + "", out temp);
            return temp;
        }

        public static double Convert2Double(this object obj)
        {
            double temp = 0;
            double.TryParse(obj + "", out temp);
            return temp;
        }

        public static DateTime? ConvertDBTime(this DateTime time)
        {
            if (time.Equals(DateTime.MinValue))
            {
                return null;
            }
            else
            {
                return time;
            }
        }
        /// <summary>
        /// 对数字进行强制截取处理，默认保留两位小数
        /// </summary>
        /// <param name="obj">要处理的数字</param>
        /// <param name="point">要保留的位数</param>
        /// <returns></returns>
        public static decimal FloorDecimal(this decimal obj, int point = 2)
        {
            var floorPoint = (int)Math.Pow(10d, point);
            return Math.Floor(obj * floorPoint) / floorPoint;
        }
        /// <summary>
        /// 对数字进行强制进位处理，默认保留两位小数
        /// </summary>
        /// <param name="obj">要处理的数字</param>
        /// <param name="point">需要保留的位数</param>
        /// <returns></returns>
        public static decimal CeilingDecimal(this decimal obj, int point = 2)
        {
            var floorPoint = (int)Math.Pow(10d, point);
            return Math.Ceiling(obj * floorPoint) / floorPoint;
        }

        /// <summary>
        /// 根据枚举值取显示信息
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nameInstead"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum value, Boolean nameInstead = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }
            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute == null && nameInstead == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.Description;
        }

        public static T Convert2Enum<T>(this string str, bool ignoreCase = false)
        {
            return (T)(Enum.Parse(typeof(T), str, ignoreCase));
        }

        public static string ReplaceSql(this string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.Replace("\\", "\\\\").Replace("\'", "\\\'");
            }
            return value;
        }

        public static string ReplaceNoCase(this string replaceValue, string oldValue, string newValue)
        {
            return System.Text.RegularExpressions.Regex.Replace(replaceValue, System.Text.RegularExpressions.Regex.Escape(oldValue), newValue, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 移除小数点末尾的0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecimalRemovePointZero(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            decimal temp;
            if (!decimal.TryParse(str, out temp))
            {
                return str;
            }
            var strArr = str.Split('.');
            var isSub = strArr.Length == 2 ? (decimal.Parse(strArr[1]) > 0) : false;
            if (isSub)
            {
                var arr = str.ToCharArray().ToList();
                while (arr.Count > 0)
                {
                    if (arr.LastOrDefault() != '0')
                    {
                        break;
                    }
                    arr.RemoveAt(arr.Count - 1);
                }

                return string.Join("", arr);
            }
            else
            {
                return strArr[0];
            }
        }

        /// <summary>
        /// 自定义Distinct扩展方法
        /// </summary>
        /// <typeparam name="T">要去重的对象类</typeparam>
        /// <typeparam name="C">自定义去重的字段类型</typeparam>
        /// <param name="source">要去重的对象</param>
        /// <param name="getfield">获取自定义去重字段的委托</param>
        /// <returns></returns>
        public static IEnumerable<T> AkmiiDistinct<T, C>(this IEnumerable<T> source, Func<T, C> getfield)
        {
            return source.Distinct(new AkmiiCompare<T, C>(getfield));
        }

        public static string TemplateReplace(this string template, Dictionary<string, string> dic, string reg = "{\\$(?<Column>[\\w]*?)\\$}")
        {
            if (string.IsNullOrWhiteSpace(template)
                || string.IsNullOrWhiteSpace(reg)
                || dic == null
                || dic.Count == 0)
            {
                return template;
            }

            Regex regex = new Regex(reg, RegexOptions.IgnoreCase);
            var matchs = regex.Matches(template);
            foreach (Match item in matchs)
            {
                var key = item.Groups["Column"].Value;
                var tempValue = "";
                if (dic.ContainsKey(key))
                {
                    tempValue = dic[key];
                }
                template = template.Replace(item.Value, tempValue);
            }
            return template;
        }
    }
}
