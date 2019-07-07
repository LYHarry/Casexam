using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace 全国地址
{
    public class Common
    {
        private List<string> result = null;
        private WebClient webclient = new WebClient();
        private ArrayList _NewsUrlList = null;

        /// <summary>
        /// 取得（下载）网页的内容
        /// </summary>
        /// <param name="Url">网络url地址</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>有异常返回false</returns>
        public string DownloadPageContent(string Url, Encoding encoding)
        {
            try
            {
                webclient.Encoding = encoding;
                return webclient.DownloadString(Url);
            }
            catch (Exception) { return ""; }
            finally
            {
                webclient.Dispose();
            }
        }



        /// <summary>
        /// 配置单条地址信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="find"></param>
        /// <returns></returns>
        public List<string> GetMatchContent(string input, string pattern, string find)
        {
            result = new List<string>();
            Match m = MatchContent(input, pattern, find);
            while (m.Success)
            {
                result.Add(m.Groups["TARGET"].Value.Trim());
                m = m.NextMatch();
            }
            return result;
        }


        /// <summary>
        ///  配置下载内容
        ///  过滤出每条地址的代码和名称
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="find"></param>
        /// <returns></returns>
        public string GetMatch(string input, string pattern, string find)
        {
            string result = "";
            Match m = MatchContent(input, pattern, find);
            while (m.Success)
            {
                result += m.Groups["TARGET"].Value;
                m = m.NextMatch();
            }
            return result.Trim();
        }




        /// <summary>
        /// 匹配超级链接地址，得到字符串中的链接地址
        /// </summary>
        /// <param name="input">要检测的字符串</param>
        /// <param name="pattern">正则过滤规则</param>
        /// <param name="find">规则名称</param>
        /// <returns>返回匹配到的链接字符串数组</returns>
        public string[] GetMatchUrl(string input, string pattern, string find)
        {
            _NewsUrlList = new ArrayList();
            _NewsUrlList.Clear();

            Match m = MatchContent(input, pattern, find);
            while (m.Success)
            {
                _NewsUrlList.Add(m.Groups["TARGET"].Value);
                m = m.NextMatch();
            }
            return (string[])_NewsUrlList.ToArray(typeof(string));
        }



        /// <summary>
        /// 私有方法，从字符串中过滤出需要配置的内容
        /// </summary>
        /// <param name="input">基字符串</param>
        /// <param name="pattern">配置正则</param>
        /// <param name="find">需要配置出的内容（查找出的内容）</param>
        /// <returns></returns>
        private Match MatchContent(string input, string pattern, string find)
        {
            string _pattn = Regex.Escape(pattern);
            _pattn = _pattn.Replace(@"\[变量]", @"[\s\S]*?");
            _pattn = Regex.Replace(_pattn, @"((\\r\\n)|(\\ ))+", @"\s*", RegexOptions.Compiled);
            if (Regex.Match(pattern.TrimEnd(), Regex.Escape(find) + "$", RegexOptions.Compiled).Success)
                _pattn = _pattn.Replace(@"\" + find, @"(?<TARGET>[\s\S]+)");
            else
                _pattn = _pattn.Replace(@"\" + find, @"(?<TARGET>[\s\S]+?)");

            Regex r = new Regex(_pattn, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match m = r.Match(input);
            return m;
        }


        /// <summary>
        /// 得到地址信息
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public DataTable GetAddressInfo(string sqlStr)
        {
            DataSet datads = new DataSet();
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                conn.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(sqlStr, conn))
                {
                    sda.Fill(datads, "ds0");
                }
            }
            return datads.Tables[0];
        }




        /// <summary>
        /// 连接数据库，保存数据
        /// </summary>
        /// <param name="sqlStr"></param>
        public void SaveInfo(string sqlStr)
        {
            //Task task = new Task(() =>
            //{
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(sqlStr, conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
            //});
            //task.Start();
        }

        /// <summary>
        /// 得到连接字符串
        /// </summary>
        /// <returns></returns>
        private string GetConnStr()
        {
            //return "Data Source=.;Initial Catalog=.;User ID=sa;Password=123456;";
            return "server=.;database=YB;uid=sa;pwd=123456";
        }


        /// <summary>
        /// 把对象转换为JSON字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string ToJSON(object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }




    }
}