using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MusicMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //搜索
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        Session["type"] = ddl_Search.Text.Trim();
        Session["condition"] = txt_Search.Text.Trim();
        Response.Redirect("Search.aspx");
    }
}
