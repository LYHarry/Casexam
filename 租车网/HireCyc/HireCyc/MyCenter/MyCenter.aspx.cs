using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyCenter_MyCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string UserName = Session["username"].ToString();  //获取保存在session中的用户账号
            Repeater1.DataSource = BLL.CycBorrowBusiness.CycBorrowLookBycode(UserName);
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}