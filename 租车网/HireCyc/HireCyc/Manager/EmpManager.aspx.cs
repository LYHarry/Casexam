using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_EmpManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Repeater1.DataSource = BLL.EmployeeInfoBusiness.EmployeeInfoLookALLEmp();
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
        Response.Redirect("SelectEmp.aspx", true);
    }
}