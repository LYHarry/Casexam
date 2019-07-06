using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services; //需要引用该命名空间
using System.Web.Script.Serialization;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 说明：
    /// 1、所调用的方法必须声明为公共权限且为静态的（public static）
    /// 2、所调用的方法必须指明为[WebMethod] web方法。
    /// </summary>
    /// <returns></returns>
    [WebMethod] //需要引用该特性
    public static string AjaxSortCourse()
    {
        return "AJAX调用无参方法返加结果";
    }

    /// <summary>
    /// AJAX调用有参方法
    /// </summary>
    /// <param name="type"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    [WebMethod]
    public static string AjaxSortCourse(int type, int num)
    {
        return type + "_不是_" + num;
    }

    /// <summary>
    /// 返回数组
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    [WebMethod]
    public static List<int> AjaxSortCourse(int max)
    {
        List<int> list = new List<int>();
        for (int i = 1; i < max; i++)
        {
            list.Add(i);
        }
        return list;
    }

    /// <summary>
    /// 返回对象
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    [WebMethod]
    public static string AjaxCourse(int type)
    {
        Dictionary<string, object> dict = new Dictionary<string, object>();

        for (int i = 1; i < 11; i++)
        {
            dict.Add(i.ToString(), new
            {
                name = "测试1" + i,
                age = 12 + i,
                sex = (i % 2 == 0) ? 0 : 1
            });
        }

        //利用Json帮助类把对象转换为JSON格式字符串
        return ToJSON(dict);
    }

    /// <summary>
    /// 通过系统自带类把对象转换为JSON字符串
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private static string ToJSON(object obj)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return serializer.Serialize(obj);
    }

}