using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyCenter_AccountSecure : System.Web.UI.Page
{
    public List<Model.UserInfo> uf;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string UserName = Session["username"].ToString();  //获取保存在session中的用户账号
            uf = BLL.UserInfoBusiness.userInfo(UserName);  //读取用户信息
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}