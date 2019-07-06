using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //注册
    protected void btn_Register_Click(object sender, EventArgs e)
    {
        try
        {
            string userName = tb_UserName.Text.Trim();
            string password = tb_Password.Text.Trim();
            int role; //用于保存角色

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "注册", "<script>alert('用户名或密码不能为空!')</script>");
                return;
            }
            if (!password.Equals(tb_RePassword.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "注册", "<script>alert('密码和确定密码不同!')</script>");
                return;
            }
            string Email = tb_Email.Text.Trim();
            DateTime registerTime = DateTime.Now;

            if (rb_Admin.Checked)
                role = 1;
            else
                role = 0;

            Music.Model.Users user = new Music.Model.Users();
            user.UserName = userName;
            user.Password = password;
            user.RegisterTime = registerTime;
            user.Role = role;
            user.Email = Email;

            bool f = Music.BLL.UserBusiness.AddUser(user);
            if (f)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "注册", "<script>alert('注册成功!')</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "注册", "<script>alert('注册失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "注册", "<script>alert('" + ex.Message + "!')</script>");
        }
    }
}