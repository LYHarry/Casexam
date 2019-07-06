using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home_PayForStandard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //读取所有自行车毁坏赔偿标准
            Repeater1.DataSource = BLL.CycDamageBusiness.CycDamageLookALL();
            Repeater1.DataBind();
        }
        catch (Exception)
        {            
            throw;
        }
    }
}