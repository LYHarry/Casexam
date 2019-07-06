using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class HomePageMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //读取车辆类型名称 
            Repeater1.DataSource = BLL.CycTypeBusiness.CycTypeLookAllName();
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }     
    }

}
