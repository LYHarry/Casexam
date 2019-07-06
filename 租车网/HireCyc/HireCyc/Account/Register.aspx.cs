using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;

public partial class Account_Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    List<string> pawKey = null;  //用于保存读取的所有密钥

    //邮箱注册确认按钮
    protected void Button2_Click(object sender, EventArgs e)
    {
        string email = TextBox5.Text.Trim();  //得到邮箱号
        string paw = password1.Value.Trim();   //得到密码
        string rePaw = TextBox7.Text.Trim();   //得到确认密码
        string code = TextBox8.Text.Trim();   //得到验证码
        string reCode = Session["code"].ToString();   //得到保存在session中的验证码

        #region 判断文本框是否为空

        if (string.IsNullOrEmpty(email))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('账号不能为空!')</script>");
            return;
        }
        if (paw.Equals("字母，数字,最长16位"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('密码不能为空!')</script>");
            return;
        }
        if (string.IsNullOrEmpty(rePaw))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('确认密码不能为空!')</script>");
            return;
        }
        if (string.IsNullOrEmpty(code))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码不能为空!')</script>");
            return;
        }
        #endregion

        if (!cb2.Checked)
        {
            Common.MessageBox.Show(this.Page, "请勾选同意服务条款!");
            return;
        }

        if (!(BasicOperate.EmailIsLegal(email)))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('邮箱格式不正确!')</script>");
            return;
        }

        if (!(BasicOperate.strIsEqual(code, reCode)))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码不正确!')</script>");
            return;
        }

        try
        {
            if (BLL.UserInfoBusiness.UserInfoLookAccount(email))
            {
                Common.MessageBox.Show(this.Page, "该邮箱已注册Cyc账号，请输入其他邮箱!");
                return;
            }

            pawKey = BLL.PasswordBusiness.PasswordLookALLPaw();  //读取产生的所有密钥
            //判断随机产生的密钥是否唯一
            while (true)
            {
                string keyt = BasicOperate.SecurityCode(4);  //随机产生四位密钥

                bool isAdd = BasicOperate.strIsExistList(keyt, pawKey);//判断密钥是否存在

                if (!isAdd)
                {
                    //密钥唯一，保存数据库
                    int index = paw.Length / 2;  //把密钥插入到密码字符串的下标
                    paw = BasicOperate.InsertStr(index, paw, keyt);  //把密钥插入到密码中，形成新密码字符串
                    paw = FormsAuthentication.HashPasswordForStoringInConfigFile(paw, "MD5");   //把密码加密

                    //写入数据库 事务提交
                    using (TransactionScope trans = new TransactionScope())
                    {
                        BLL.UserInfoBusiness.AddUserInfo(email, paw);
                        BLL.PasswordBusiness.PasswordAdd(email, keyt);
                        BLL.UserCreditBusiness.UserCreditAdd(email);
                        trans.Complete();
                        Common.MessageBox.ShowAndRedirect(this.Page, "注册成功!", "Login.aspx");
                    }
                }
                break;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //手机注册确认按钮
    protected void Button3_Click(object sender, EventArgs e)
    {
        string phone = TextBox1.Text.Trim();  //得到手机号
        string paw = passwordFrame.Value.Trim();   //得到密码
        string rePaw = TextBox3.Text.Trim();   //得到确认密码
        string code = TextBox4.Text.Trim();   //得到输入验证码

        #region 判断文本框是否为空

        if (phone.Equals("只能是11位手机号码"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('账号不能为空!')</script>");
            return;
        }
        if (paw.Equals("字母，数字,最长16位"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('密码不能为空!')</script>");
            return;
        }
        if (string.IsNullOrEmpty(rePaw))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('确认密码不能为空!')</script>");
            return;
        }
        if (string.IsNullOrEmpty(code))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码不能为空!')</script>");
            return;
        }
        #endregion

        if (!cb1.Checked)
        {
            Common.MessageBox.Show(this.Page, "请勾选同意服务条款!");
            return;
        }

        if (!(BasicOperate.PhoneIsLegal(phone)))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('手机号码格式不正确!')</script>");
            return;
        }

        if (!(BasicOperate.strIsEqual(code, Session["ramNum"].ToString())))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('验证码不正确!')</script>");
            return;
        }

        try
        {
            if (BLL.UserInfoBusiness.UserInfoLookAccount(phone))
            {
                Common.MessageBox.Show(this.Page, "该手机已注册Cyc账号，请输入其他手机号!");
                return;
            }

            pawKey = BLL.PasswordBusiness.PasswordLookALLPaw();  //读取产生的所有密钥
            //判断随机产生的密钥是否唯一
            while (true)
            {
                string keyt = BasicOperate.SecurityCode(4);  //随机产生四位密钥

                bool isAdd = BasicOperate.strIsExistList(keyt, pawKey);//判断密钥是否存在

                if (!isAdd)
                {
                    //密钥唯一，保存数据库
                    int index = paw.Length / 2;  //把密钥插入到密码字符串的下标
                    paw = BasicOperate.InsertStr(index, paw, keyt);  //把密钥插入到密码中，形成新密码字符串
                    paw = FormsAuthentication.HashPasswordForStoringInConfigFile(paw, "MD5");   //把密码加密

                    //写入数据库 事务提交
                    using (TransactionScope trans = new TransactionScope())
                    {
                        BLL.UserInfoBusiness.AddUserInfo(phone, paw);
                        BLL.PasswordBusiness.PasswordAdd(phone, keyt);
                        BLL.UserCreditBusiness.UserCreditAdd(phone);
                        trans.Complete();
                        Common.MessageBox.ShowAndRedirect(this.Page, "注册成功!", "Login.aspx");
                    }
                }
                break;
            }
        }
        catch (Exception ex)  //出错跳转到错误页面
        {
            throw ex;
        }
    }

    //获取验证码按钮，发送短信
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

}