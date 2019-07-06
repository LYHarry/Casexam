using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyCenter_MyGrade : System.Web.UI.Page
{
    public string grade = "";  //用于保存我的等级
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string username = Session["username"].ToString();
            //查询我的等级
            grade = BLL.UserCreditBusiness.UserCreditLookGradeByBarcode(username);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}