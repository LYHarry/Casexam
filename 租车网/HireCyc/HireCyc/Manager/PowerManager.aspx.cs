using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_PowerManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Repeater1.DataSource = BLL.AdmSetBusiness.AdmSetLookAll();
            Repeater1.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}