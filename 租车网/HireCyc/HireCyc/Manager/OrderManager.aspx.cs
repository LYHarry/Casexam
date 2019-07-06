using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_OrderManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string empAcc =  Session["ManaAcc"].ToString();

        try
        {
            Repeater1.DataSource = BLL.CycBorrowBusiness.CycBorrowLookByEmpcode(empAcc);
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //查询
    protected void select_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("SelectOrder.aspx", true);
    }
}