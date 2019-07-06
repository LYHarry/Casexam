using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;

namespace UploadingFile
{
    /// <summary>
    /// JSON帮助类
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// 把对象转换为JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// 把JSON格式字符串转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T FromJSON<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(json);
        }


    }
}
