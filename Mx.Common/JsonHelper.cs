using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Mx.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// JSON序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string JsonSerializer<T>(T entity)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(entity);
        }

        /// <summary>
        /// JSON反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T JsonDeserialize<T>(string jsonString)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(jsonString);
        }
    }
}
