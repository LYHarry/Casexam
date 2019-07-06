using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_AlterPassword : System.Web.UI.Page
{
    List<string> pawKey = null;  //用于保存读取的所有密钥

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //修改密码确定按钮
    protected void Button1_Click(object sender, EventArgs e)
    {
        string rePaw = TextBox1.Text.Trim();  //得到原密码
        string str1 = passwordFrame.Value.Trim(); //得到新密码字符串
        string str2 = TextBox2.Text.Trim();  //得到确认密码字符串

        string ManUserName = Session["ManaAcc"].ToString();  //获取管理员账号

        #region 栓查输入框是否为空

        if (string.IsNullOrEmpty(rePaw))
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "提示", "<script>alert('请输入原密码!')</script>");
            return;
        }

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
                        //得到原密码的密钥
                        string rekeyt = BLL.PasswordBusiness.PasswordLookpassByAccount(ManUserName);

                        //原密钥唯一，保存数据库
                        int reindex = rePaw.Length / 2;  //把密钥插入到密码字符串的下标
                        rePaw = BasicOperate.InsertStr(reindex, rePaw, rekeyt);  //把密钥插入到密码中，形成新密码字符串
                        rePaw = FormsAuthentication.HashPasswordForStoringInConfigFile(rePaw, "MD5");   //把密码加密

                        //新密钥唯一，保存数据库
                        int index = str1.Length / 2;  //把密钥插入到密码字符串的下标
                        str1 = BasicOperate.InsertStr(index, str1, keyt);  //把密钥插入到密码中，形成新密码字符串
                        str1 = FormsAuthentication.HashPasswordForStoringInConfigFile(str1, "MD5");   //把密码加密

                        //写入数据库 事务提交
                        using (TransactionScope trans = new TransactionScope())
                        {
                            BLL.EmployeeInfoBusiness.EmployeeInfoUpdatePass(ManUserName, rePaw, str1);
                            BLL.PasswordBusiness.PasswordUpdateByAccount(ManUserName, keyt);
                            trans.Complete();
                            Response.Redirect("RegisterSuccess.aspx", true);
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