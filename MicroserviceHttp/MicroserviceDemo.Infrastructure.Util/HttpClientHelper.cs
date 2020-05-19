using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceDemo.Infrastructure.Util
{
    /// <summary>
    /// HttpClient 帮助类
    /// </summary>
    public class HttpClientHelper
    {
        /// <summary>
        ///     GetAsync
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string GetAsync(string requestUrl)
        {
            using (var client = new HttpClient())
            {
                var rtnResult = client.GetAsync(requestUrl).Result;
                var data = rtnResult.Content.ReadAsStringAsync().Result;
                return data;
            }
        }
    }
}
