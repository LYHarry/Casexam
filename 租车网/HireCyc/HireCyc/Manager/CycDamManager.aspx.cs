using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_CycDamManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Repeater1.DataSource = BLL.CycDamageBusiness.CycDamageLookALL();
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
        Response.Redirect("SelectCycDam.aspx", true);
    }

    //添加
    protected void create_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("AddCycDam.aspx", true);
    }
}