using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
  
    }

    /// <summary>
    /// 点击确定，检证输入是否正确，登录主界面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = TextBox1.Text.Trim();  //得到账号
        string pasword = TextBox2.Text.Trim(); //得到密码
        string Code = TextBox3.Text.Trim();  //得到验证码

        string code = Session["code"].ToString();  //获取保存随机验证码字符串

        #region 检验输入框是否为空
        if (username.Equals("邮箱/手机号码"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入账号!')</script>");
            return;
        }

        if (pasword.Equals("密码"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入密码!')</script>");
            return;
        }

        if (code.Equals("验证码"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入验证码!')</script>");
            return;
        }
        #endregion

        try
        {
            if (BasicOperate.strIsEqual(Code, code))  //判断验证码是否正确
            {
                if (BLL.UserInfoBusiness.UserInfoLookAccount(username))  //判断用户名是否存在
                {
                    string keyt = BLL.PasswordBusiness.PasswordLookpassByAccount(username);  //查询用户的密钥
                    int index = pasword.Length / 2;  //把密钥插入到密码字符串的下标
                    pasword = BasicOperate.InsertStr(index, pasword, keyt);  //把密钥插入到密码中，形成新密码字符串
                    pasword = FormsAuthentication.HashPasswordForStoringInConfigFile(pasword, "MD5");   //把密码加密
                    
                    if (BLL.UserInfoBusiness.UserLogin(username, pasword))   //判断用户名和密码是否正确
                    {
                        Session["username"] = username;  //把用户名保存到session中
                        Response.Redirect("../Home/ListCyc.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('账号或密码错误!')</script>");
                        return;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('该账号不是Cyc用户!')</script>");
                    return;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码输入不正确!')</script>");
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}