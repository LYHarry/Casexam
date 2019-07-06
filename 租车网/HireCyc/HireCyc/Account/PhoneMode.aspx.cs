using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ForgetPaw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //下一步按钮
    protected void Button2_Click(object sender, EventArgs e)
    {
        string phone = TextBox1.Text.Trim();  //得到手机号
        string Code = TextBox2.Text.Trim();   //得到验证码

        #region 判断文本框是否为空

        if (phone.Equals("只能是11位手机号码"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('手机号码不能为空!')</script>");
            return;
        }

        if (string.IsNullOrEmpty(Code))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码不能为空!')</script>");
            return;
        }
        #endregion

        if (BasicOperate.PhoneIsLegal(phone))  //判断手机号码格式是否正确
        {
            try
            {
                if (BLL.UserInfoBusiness.UserInfoLookAccount(phone))  //判断手机账号是否是Cyc用户账号
                {
                    Session["Acc"] = phone;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('该手机号码不是Cyc用户!')</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('手机号码格式不正确!')</script>");
            return;
        }

        if (!BasicOperate.strIsEqual(Code, Session["ramNum"].ToString()))  //判断验证码输入是否正确
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码输入不正确!')</script>");
            return;
        }

        Response.Redirect("AlterPassword.aspx", true);
    }

    //得到验证码，发送短信
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox1.Text))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入手机号码!')</script>");
            return;
        }

        string url = "http://utf8.sms.webchinese.cn/?";
        string strUid = "Uid=";
        string strKey = "&key=e8d98845eaccc37c9fd0";
        string strMob = "&smsMob=";
        string strContent = "&smsText=";

        string from = "lh1822710";   //发送者的账号
        string to = TextBox1.Text.Trim();   //得到接收者的电话

        Session["ramNum"] = BasicOperate.RanNumCode(6);  //得到验证码

        string contentBody = "密码校验码： " + Session["ramNum"].ToString() + " 请勿向任何人提供您收到的短信校验码！";

        url = url + strUid + from + strKey + strMob + to + strContent + contentBody;
        string Result = BasicOperate.GetHtmlFromUrl(url);

        if (!string.IsNullOrEmpty(Result))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码已发送到您的手机，请注意查收!')</script>");
            return;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码发送失败!')</script>");
            return;
        }
    }

    /// <summary>
    /// 飞信发送短信方式
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void send_Click(object sender, EventArgs e)
    {

        string fno = "18227100371"; //发件人的号码   
        string fp = "yl123456"; //发件人密码   
        string fto = "18227100351";  //收件人号码  
        string fm = "李豪我喜欢你";  //短信内容  
        fm = BasicOperate.BodyEncode(fm);
        string url = "http://quanapi.sinaapp.com/fetion.php?u=" + fno + "&p=" + fp + "&to=" + fto + "&m=" + fm;//破解API  
        string res = BasicOperate.getContent(url);  //为空表示发送成功
    }




}