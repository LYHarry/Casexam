using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            rp_HotSongs.DataSource = Music.BLL.SongBusiness.GetHotSongs(10);
            rp_HotSongs.DataBind();
            rp_NewSongs.DataSource = Music.BLL.SongBusiness.GetNewSongs(10);
            rp_NewSongs.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}