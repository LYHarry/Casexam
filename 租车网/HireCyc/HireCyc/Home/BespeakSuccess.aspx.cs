using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_BespeakSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cycName = string.Empty;  //用于保存用户预定的车辆名称

        //用户提交订单，提示管理员，有人订单
        try
        {
            string url = "http://utf8.sms.webchinese.cn/?";
            string strUid = "Uid=";
            string strKey = "&key=7c1a6a07412103a0b11f";
            string strMob = "&smsMob=";
            string strContent = "&smsText=";
            string from = "lh1822";   //发送者的账号
            string to = "18227100351";   //得到接收者的电话

            string username = Session["username"].ToString();   //获取预定车用户账号           

            //得到某用户最新的订单
            Model.CycBorrow cb = BLL.CycBorrowBusiness.CycBorrowLookNewBycode(username);
            //得到某用户最新的车辆租用信息
            List<Model.CycRent> cr = BLL.CycRentBusiness.CycRentLookByBowId(cb.CycBorrowId);
            foreach (Model.CycRent crt in cr)
            {
                cycName += crt.CycRentCycName + "、";
            }
            cycName = cycName.Substring(0, cycName.Length - 1);
            string cycTypeName = Session["cycTypeName"].ToString();  //得到用户租用类型

            string contentBody = username + "用户预定“" + cycTypeName + "”，共“" + cb.CycBorrowCount
                + "”辆，车名为：“" + cycName + "”，用车时间为:" + cr[0].CycRentTime + "，已付订金。";

            url = url + strUid + from + strKey + strMob + to + strContent + contentBody;
            string Result = BasicOperate.GetHtmlFromUrl(url);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}