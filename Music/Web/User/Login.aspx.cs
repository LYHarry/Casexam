using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //登录
    protected void btn_Login_Click(object sender, EventArgs e)
    {
        string userName = tb_UserName.Text.Trim();
        string password = tb_Password.Text.Trim();

        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "登录", "<script>alert('用户名或密码不能为空!')</script>");
            //Response.Write("<script>alert('用户名和密码不能为空')</script>");
            return;
        }

        if (Music.BLL.UserBusiness.UserLogin(userName, password))
        {
            Session["UserName"] = userName; //保存用户名，方便后面使用
            //给登录成功的用户颁发一个身份凭据
            FormsAuthentication.RedirectFromLoginPage(userName, false);
            Response.Redirect("..\\index.aspx");
          
        }
        else
        {
            //登录失败
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "登录", "<script>alert('用户名或密码不正确!')</script>");
        }
    }
}