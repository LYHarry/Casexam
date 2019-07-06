using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_CycTypeManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Repeater1.DataSource = BLL.CycTypeBusiness.CycTypeLookAll();
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //添加
    protected void create_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("AddCycType.aspx", true);
    }
}