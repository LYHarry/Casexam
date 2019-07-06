using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SongList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            rp_SongsList.DataSource = Music.BLL.SongBusiness.GetAllSongs();
            rp_SongsList.DataBind();
        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}