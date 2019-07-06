using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_Payment : System.Web.UI.Page
{

    string username = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        username = Session["username"].ToString();  //得到保存在session中的用户账号
    }

    //确认支付按钮
    protected void Unnamed_ServerClick(object sender, EventArgs e)
    {
        string Account = TextBox1.Text.Trim();  //得到用户支付账户号
        string paw = TextBox2.Text.Trim();  //得到支付密码
        string Code = TextBox3.Text.Trim();   //得到验证码

        float money = Convert.ToSingle(Session["money"]);   //得到订金

        #region 判断文本框是否为空

        if (string.IsNullOrEmpty(Account))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('支付账号不能为空!')</script>");
            return;
        }
        if (string.IsNullOrEmpty(paw))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('支付密码不能为空!')</script>");
            return;
        }

        if (string.IsNullOrEmpty(Code))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码不能为空!')</script>");
            return;
        }
        #endregion

        if (!BasicOperate.strIsEqual(Code, Session["ramNum"].ToString()))  //判断验证码输入是否正确
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码输入不正确!')</script>");
            return;
        }

        if (BasicOperate.isNum(Account))  //判断支付账号格式是否正确，全为数字
        {
            if (Session["cardType"].ToString().Equals("支付宝"))
            {
                if (Account.Length != 11)
                {
                    Common.MessageBox.Show(this.Page, "支付宝账号长度要为11位!");
                    return;
                }
            }

            if (Session["cardType"].ToString().Equals("银行卡"))
            {
                if (Account.Length != 19)
                {
                    Common.MessageBox.Show(this.Page, "银行卡账号长度要为19位!");
                    return;
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('支付账号格式不正确!')</script>");
            return;
        }
        try
        {
            if (BLL.PayInfoBusiness.payInfoCodeAccIsExist(username))  //判断支付账号是否存在
            {
                string keyt = BLL.PasswordBusiness.PasswordLookpassByAccount(username);
                int index = paw.Length / 2;  //把密钥插入到密码字符串的下标
                paw = BasicOperate.InsertStr(index, paw, keyt);  //把密钥插入到密码中，形成新密码字符串
                paw = FormsAuthentication.HashPasswordForStoringInConfigFile(paw, "MD5");   //把密码加密

                if (BLL.PayInfoBusiness.PayInfoLookUserAccALL(username, Account, paw))  //判断支付账号和密码是否输入正确
                {    //更改用户和员工账户余额
                    if (BLL.PayInfoBusiness.PayInfoUpdateBlackFigurepay(username, Account, "JyEVqzb83924", "18227100351", money))
                        Response.Redirect("BespeakSuccess.aspx", true);
                }
                else
                {
                    int num = Convert.ToInt32(Session["num"]) + 1;
                    Session["num"] = num;  //保存输错次数，三次以上更改支付密码
                    if (num > 2)
                    {
                        Common.MessageBox.ShowAndRedirect(this.Page, "支付账号或密码已输错三次，现请你更改支付密码!", "PhoneMode.aspx");
                        return;
                    }
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('支付账号或密码输入不正确!')</script>");
                }
            }
            else
            {
                string cardType = Session["cardType"].ToString();  //得到支付账号类型

                Model.PayInfo pf = new Model.PayInfo();
                pf.PayInfoUserAcc = username;
                pf.PayInfoCodeAcc = Account;
                pf.PayInfoType = cardType;
                pf.PayInfoBlackFigure = 1000;

                string keyt = BLL.PasswordBusiness.PasswordLookpassByAccount(username);
                int index = paw.Length / 2;  //把密钥插入到密码字符串的下标
                paw = BasicOperate.InsertStr(index, paw, keyt);  //把密钥插入到密码中，形成新密码字符串
                paw = FormsAuthentication.HashPasswordForStoringInConfigFile(paw, "MD5");   //把密码加密
                pf.PayInfoPassw = paw;

                if (BLL.PayInfoBusiness.PayInfoAdd(pf))
                {
                    //更改用户和员工账户余额
                    if (BLL.PayInfoBusiness.PayInfoUpdateBlackFigurepay(username, Account, "JyEVqzb83924", "18227100351", money))
                        Response.Redirect("BespeakSuccess.aspx", true);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //得到验证码，发送短信
    protected void Button1_Click(object sender, EventArgs e)
    {
        string url = "http://utf8.sms.webchinese.cn/?";
        string strUid = "Uid=";
        string strKey = "&key=38b51aacd4406ba40244";
        string strMob = "&smsMob=";
        string strContent = "&smsText=";
        string from = "fb18227101677";   //发送者的账号

        try
        {
            List<Model.UserInfo> ui = BLL.UserInfoBusiness.userInfo(this.username);
            string to = ui[0].UserTel;   //得到接收者的电话

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
        catch (Exception ex)
        {
            throw ex;
        }
    }
}