using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class MyCenter_PersonData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //基本信息提交按钮
    protected void Button2_Click(object sender, EventArgs e)
    {
        Model.UserInfo user = new Model.UserInfo();

        user.UserAccount = Session["username"].ToString();  //获取保存在session中的用户账号
        user.UserName = TextBox9.Text.Trim();  //用于保存姓名

        if (male.Checked)//用于保存性别
            user.UserSex = "男";
        else if (female.Checked)
            user.UserSex = "女";

        user.UserNickName = TextBox3.Text.Trim();  //得到昵称
        user.UserCertificate = TextBox2.Text.Trim();  //得到身份证号
        user.UserEmail = TextBox4.Text.Trim();  //得到邮箱    
        user.UserTel = TextBox10.Text.Trim();  //得到电话号码
        string address = Request.Form["GetAdd"];  //得到选择的地址
        user.UserAddress = address + TextBox1.Text.Trim();

        #region 判断文本框是否为空

        if (string.IsNullOrEmpty(user.UserName))
        {
            Common.MessageBox.Show(this.Page, "姓名不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(user.UserSex))
        {
            Common.MessageBox.Show(this.Page, "性别不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(user.UserCertificate))
        {
            Common.MessageBox.Show(this.Page, "身份证不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(user.UserAddress))
        {
            Common.MessageBox.Show(this.Page, "联系地址不能为空!");
            return;
        }
        if (string.IsNullOrEmpty(user.UserEmail))
        {
            Common.MessageBox.Show(this.Page, "邮箱不能为空!");
            return;
        }
        if (TextBox1.Text.Trim().Equals("详细地址"))
        {
            Common.MessageBox.Show(this.Page, "详细地址不能为空!");
            return;
        }
        #endregion

        if (!string.IsNullOrEmpty(user.UserEmail))
        {
            if (!BasicOperate.EmailIsLegal(user.UserEmail))
            {
                Common.MessageBox.Show(this.Page, "邮箱格式不正确！");
                return;
            }
        }
        string error = BasicOperate.CardIDIsLegal(user.UserCertificate);
        if (error.Equals("成功"))
        {
            if (BLL.UserInfoBusiness.ChangeAll(user))
            {
                Common.MessageBox.ShowAndRedirect(this.Page, "信息更改成功!", "../Home/ListCyc.aspx");
            }
        }
        else
        {
            Common.MessageBox.Show(this.Page, error);
            return;
        }
    }
    
    //更多信息提交按钮
    protected void Button3_Click(object sender, EventArgs e)
    {
        Common.MessageBox.Show(this.Page, "此模板暂未开发!");
    }
}