using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Play : System.Web.UI.Page
{
    public string path;  //保存歌曲的路径

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"].ToString()))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);  //得到歌曲的ID

                    path = Music.BLL.SongBusiness.GetSong(id).Path;
                    Page.DataBind();

                    Music.BLL.SongBusiness.AddClickCount(id);  //增加歌曲的点击次数
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}