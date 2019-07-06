using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_CycManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            AspNetPager2.RecordCount = BLL.CycInfoBusiness.CycInfoYs();
            GridView1.DataSource = BLL.CycInfoBusiness.CycInfoPage(AspNetPager2.StartRecordIndex, AspNetPager2.EndRecordIndex).Tables["CycHire"];
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //添加
    protected void create_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("AddCyc.aspx", true);
    }

    //查询
    protected void select_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("SelectCyc.aspx", true);
    }

    //页面改变事件
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = BLL.CycInfoBusiness.CycInfoPage(AspNetPager2.StartRecordIndex, AspNetPager2.EndRecordIndex).Tables["CycHire"];
        GridView1.DataBind();
    }
}