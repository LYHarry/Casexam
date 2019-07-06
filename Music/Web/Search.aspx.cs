using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string type = Session["type"].ToString();
            string condition = Session["condition"].ToString();

            if (type.Equals("SongName"))
            {
                rp_SongsList.DataSource = Music.BLL.SongBusiness.GetSongsBySongName(condition);
            }
            else
            {
                rp_SongsList.DataSource = Music.BLL.SongBusiness.GetSongsBySinger(condition);
            }
            rp_SongsList.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}