using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //下一步按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        string email = TextBox1.Text.Trim();  //得到邮箱
        string Code = TextBox2.Text.Trim();   //得到验证码
        string code = Session["code"].ToString();   //获取保存在session中的验证码

        #region 判断文本框是否为空

        if (string.IsNullOrEmpty(email))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('邮箱不能为空!')</script>");
            return;
        }

        if (string.IsNullOrEmpty(Code))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码不能为空!')</script>");
            return;
        }
        #endregion

        if (BasicOperate.EmailIsLegal(email))  //判断邮箱格式是否正确
        {
            try
            {
                if (BLL.UserInfoBusiness.UserInfoLookAccount(email))  //判断邮箱账号是否是Cyc用户账号
                {
                    Session["Acc"] = email;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('该邮箱不是Cyc用户!')</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "")
                    Response.Redirect("../Share/Error.aspx");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('邮箱格式不正确!')</script>");
            return;
        }

        if (!BasicOperate.strIsEqual(Code, code))  //判断验证码输入是否正确
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码输入不正确!')</script>");
            return;
        }

        //发送者邮件地址
        string form = "919793260@qq.com";
        //发送者邮件密码
        string password = "lihao123";
        //接受者邮箱地址
        string to = email;
        //SMTP服务器的主机名
        string host = "smtp.qq.com";
        //邮件标题
        string subject = "Cyc账户修改密码";
        //邮件发送的主题内容
        StringBuilder sb = new StringBuilder();

        string key = BasicOperate.SecurityCode(10) + "base";
        int time = 5000;

        sb.Append("亲爱的" + to + "您好：<br/><br/>");
        sb.Append("点击以下链接设置新密码。<br/><br/>");
        sb.Append("<a href =\"http://localhost:3821/Account/AlterPassword.aspx?key=" + key + "&time=" + time + "\">http://localhost:3821/Account/AlterPassword.aspx?key=" + key + "&time=" + time + " </a><br/><br/>");
        sb.Append("(如果无法点击该URL链接地址，请将它复制并粘帖到浏览器的地址输入框，然后单击回车即可。)<br/><br/>");
        sb.Append("注意:请您在收到邮件2分钟内使用，否则该链接将会失效。<br/><br/>");
        sb.Append("我们将一如既往、热忱的为您服务！<br/><br/>");
        string body = sb.ToString();

        //调用方法，发送邮件
        string er = BasicOperate.Send(form, password, to, host, subject, body);  //er为空表示发送成功

        if (string.IsNullOrEmpty(er))
        {
            Common.MessageBox.ShowAndRedirect(this.Page, "邮件已发送到你邮箱，请注意查收！", "../Home/ListCyc.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('邮件发送失败！')</script>");
            return;
        }
    }
}