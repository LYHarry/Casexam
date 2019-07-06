using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //上传歌曲
    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            Random rd = new Random();
            Music.Model.Songs song = new Music.Model.Songs();
            song.SongName = tb_SongName.Text.Trim();
            song.Singer = tb_Singer.Text.Trim();
            song.UploadTime = DateTime.Now;
            song.UserID = Music.BLL.UserBusiness.GetUserIDByUserName(Session["UserName"].ToString());
            song.Category = tb_Category.Text.Trim();
            song.ClickCount = 0;
            
            string savePath = Server.MapPath("..\\Songs\\");
            string newFileName = tb_SongName.Text.Trim() + Guid.NewGuid().ToString().Substring(rd.Next(0, 30), 5) + ".mp3";
            fu_Upload.SaveAs(savePath + newFileName);
            song.Path = "Songs\\" + newFileName;

            bool f = Music.BLL.SongBusiness.AddSong(song);

            if (f)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "登录", "<script>alert('歌曲上传成功!')</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "登录", "<script>alert('歌曲上传失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}