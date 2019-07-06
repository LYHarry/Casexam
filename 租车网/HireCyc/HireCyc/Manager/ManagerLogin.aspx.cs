using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ManagerLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //登录确定按钮
    protected void login_sub_ServerClick(object sender, EventArgs e)
    {
        string username = name.Value.Trim(); //得到账号
        string pasword = pwd.Value.Trim(); //得到密码

        #region 检验输入框是否为空
        if (string.IsNullOrEmpty(username))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入账号!')</script>");
            return;
        }

        if (string.IsNullOrEmpty(pasword))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入密码!')</script>");
            return;
        }
        #endregion

        try
        {
            if (BLL.EmployeeInfoBusiness.EmployeeInfoAccountIsExist(username))  //判断用户名是否存在
            {
                string keyt = BLL.PasswordBusiness.PasswordLookpassByAccount(username);  //查询用户的密钥
                int index = pasword.Length / 2;  //把密钥插入到密码字符串的下标
                pasword = BasicOperate.InsertStr(index, pasword, keyt);  //把密钥插入到密码中，形成新密码字符串
                pasword = FormsAuthentication.HashPasswordForStoringInConfigFile(pasword, "MD5");   //把密码加密

                if (BLL.EmployeeInfoBusiness.EmployeeInfoDengLu(username, pasword))   //判断用户名和密码是否正确
                {
                    Session["ManaAcc"] = username;  //把员工账号保存到session中
                    Thread.Sleep(2000);
                    Response.Redirect("ManagerHome.aspx", true);
                }
                else
                {
                    Common.MessageBox.Show(this.Page, "账号或密码错误!");
                    return;
                }
            }
            else
            {
                Common.MessageBox.Show(this.Page, "该账号不是Cyc员工账号!");
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}