using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_AlterPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 更改绑定邮箱
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_alterPaw(object sender, EventArgs e)
    {
        string str1 = Frame.Value.Trim(); //得到邮箱地址
        string str2 = TextBox2.Text.Trim();  //得到验证码

        string UserName = Session["username"].ToString();  //获取保存在session中的用户账号
        string reCode = Session["code"].ToString();   //得到保存在session中的验证码

        #region 栓查输入框是否为空

        if (string.IsNullOrEmpty(str1))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入手机号f!')</script>");
            return;
        }
        if (string.IsNullOrEmpty(str2))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入验证码!')</script>");
            return;
        }
        #endregion

        if (!BasicOperate.EmailIsLegal(str1))
        {
            Common.MessageBox.Show(this.Page, "邮箱地址格式不正确!");
            return;
        }

        if (!BasicOperate.strIsEqual(str2, reCode))
        {
            Common.MessageBox.Show(this.Page, "验证码不正确!");
            return;
        }

        if (BLL.UserInfoBusiness.UpdateEmail(UserName, str1))
        {
            //跳转主页面
            Common.MessageBox.ShowAndRedirect(this.Page, "修改成功", "MyCenter.aspx");
        }
    }
}