using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_AlterPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    List<string> pawKey = null;  //用于保存读取的所有密钥

    /// <summary>
    /// 更改密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_alterPaw(object sender, EventArgs e)
    {
        string str1 = passwordFrame.Value.Trim(); //得到新密码字符串
        string str2 = TextBox2.Text.Trim();  //得到确认密码字符串

        string UserName = Session["Acc"].ToString();  //获取上个页面输入的用户名

        #region 栓查输入框是否为空

        if (str1.Equals("字母，数字,最长16位"))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入新密码!')</script>");
            return;
        }
        #endregion


        if (BasicOperate.strIsEqual(str1, str2))  //判断密码和确认密码是否相同
        {
            try
            {
                pawKey = BLL.PasswordBusiness.PasswordLookALLPaw();  //读取产生的所有密钥
                //判断随机产生的密钥是否唯一
                while (true)
                {
                    string keyt = BasicOperate.SecurityCode(4);  //随机产生四位密钥

                    bool isAdd = BasicOperate.strIsExistList(keyt, pawKey); //判断密钥是否存在

                    if (!isAdd)
                    {
                        //密钥唯一，保存数据库
                        int index = str1.Length / 2;  //把密钥插入到密码字符串的下标
                        str1 = BasicOperate.InsertStr(index, str1, keyt);  //把密钥插入到密码中，形成新密码字符串
                        str1 = FormsAuthentication.HashPasswordForStoringInConfigFile(str1, "MD5");   //把密码加密

                        //写入数据库 事务提交
                        using (TransactionScope trans = new TransactionScope())
                        {
                            BLL.UserInfoBusiness.ChangeUserPassword(UserName, str1);
                            BLL.PasswordBusiness.PasswordUpdateByAccount(UserName, keyt);
                            trans.Complete();
                            Common.MessageBox.ShowAndRedirect(this.Page, "密码修改成功!", "Login.aspx");//跳转到登录页面
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
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('密码和确认密码不一致!')</script>");
            return;
        }
    }
}