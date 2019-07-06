using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //添加用户
    protected void btn_AddUser_Click(object sender, EventArgs e)
    {
        bool f = false; ;  //用于保存是否成功添加

        Music.Model.Users user = new Music.Model.Users();
        user.UserName = "tom";
        user.Password = "aaa";
        user.RegisterTime = DateTime.Now;
        user.Email = "tom@163.com";
        user.Role = 0;

        try
        {
            f = Music.BLL.UserBusiness.AddUser(user);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }

        if (f)
        {
            Response.Write("<script>alert('添加用户成功!')</script>");
        }
        else
        {
            Response.Write("<script>alert('添加用户失败!')</script>");
        }
    }

    //显示所有用户
    protected void btn_GetAlUsers_Click(object sender, EventArgs e)
    {
        try
        {
            gv_ShowAllUsers.DataSource = Music.BLL.UserBusiness.GetAllUsers();
            gv_ShowAllUsers.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //判断用户是否存在
    protected void btn_UserIsExist_Click(object sender, EventArgs e)
    {
        bool f = false;
        try
        {
            f = Music.BLL.UserBusiness.UserIsExist("tom");

            if (f)
            {
                Response.Write("<script>alert('存在!')</script>");
            }
            else
            {
                Response.Write("<script>alert('不存在!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //删除用户
    protected void btn_DeleteUser_Click(object sender, EventArgs e)
    {
        bool f = false;
        try
        {
            f = Music.BLL.UserBusiness.DeleteUser(1);

            if (f)
            {
                Response.Write("<script>alert('删除用户成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('删除用户失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //更改密码
    protected void btn_ChangePassword_Click(object sender, EventArgs e)
    {
        bool f = false;
        try
        {
            f = Music.BLL.UserBusiness.ChangePassword(2, "123");

            if (f)
            {
                Response.Write("<script>alert('更改密码成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('更改密码失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //用户登录
    protected void btn_UserLogin_Click(object sender, EventArgs e)
    {
        bool f = false;
        try
        {
            f = Music.BLL.UserBusiness.UserLogin("jack", "123");

            if (f)
            {
                Response.Write("<script>alert('用户登录成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('用户登录失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //添加歌曲
    protected void btn_AddSong_Click(object sender, EventArgs e)
    {
        bool f = false;
        try
        {
            Music.Model.Songs song = new Music.Model.Songs();
            song.SongName = "爱在心口难开";
            song.Singer = "许嵩";
            song.UploadTime = DateTime.Now;
            song.UserID = 4;
            song.Path = @"D:\其他";
            song.Category = "网络";
            song.ClickCount = 0;

            f = Music.BLL.SongBusiness.AddSong(song);

            if (f)
            {
                Response.Write("<script>alert('添加歌曲成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加歌曲失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //删除歌曲
    protected void DeleteSong_Click(object sender, EventArgs e)
    {
        bool f = false;
        try
        {
            f = Music.BLL.SongBusiness.DeleteSong(1);

            if (f)
            {
                Response.Write("<script>alert('删除歌曲成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('删除歌曲失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //获取指定的歌曲
    protected void btn_GetSong_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //添加歌曲的点击次数 
    protected void btn_AddClickCount_Click(object sender, EventArgs e)
    {
        bool f = false;
        try
        {
            f = Music.BLL.SongBusiness.AddClickCount(2);
            if (f)
            {
                Response.Write("<script>alert('增加次数成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('增加次数失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //显示所有歌曲
    protected void btn_ShowAllSongs_Click(object sender, EventArgs e)
    {
        try
        {
            gv_ShowSongs.DataSource = Music.BLL.SongBusiness.GetAllSongs();
            gv_ShowSongs.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //显示最新上传的歌曲
    protected void btn_GetNewSongs_Click(object sender, EventArgs e)
    {
        try
        {
            gv_ShowNewSongs.DataSource = Music.BLL.SongBusiness.GetNewSongs(2);
            gv_ShowNewSongs.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //显示最热门的歌曲
    protected void btn_ShowHotSong_Click(object sender, EventArgs e)
    {
        try
        {
            gv_ShowHotSong.DataSource = Music.BLL.SongBusiness.GetHotSongs(2);
            gv_ShowHotSong.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //显示指定的用户
    protected void btn_ShowUser_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //显示最近注册的用户
    protected void btn_ShowNewUsers_Click(object sender, EventArgs e)
    {
        try
        {
            gv_ShowNewUsers.DataSource = Music.BLL.UserBusiness.GetNewUsers(2);
            gv_ShowNewUsers.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //获取指定用户上传的歌曲
    protected void btn_GetSongsByUser_Click(object sender, EventArgs e)
    {
        try
        {
            gv_GetSongsByUser.DataSource = Music.BLL.SongBusiness.GetSongsByUser(2);
            gv_GetSongsByUser.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //获取歌曲对应的用户
    protected void btn_GetUserBySong_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //按歌曲名查找歌曲
    protected void btn_GetSongsBySongName_Click(object sender, EventArgs e)
    {
        try
        {
            gv_GetSongsBySongName.DataSource = Music.BLL.SongBusiness.GetSongsBySongName("安静");
            gv_GetSongsBySongName.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //按歌手查找歌曲
    protected void btn_GetSongsBySinger_Click(object sender, EventArgs e)
    {
        try
        {
            gv_GetSongsBySinger.DataSource = Music.BLL.SongBusiness.GetSongsBySinger("刘德华");
            gv_GetSongsBySinger.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }

    //修改歌曲
    protected void btn_ChangeSong_Click(object sender, EventArgs e)
    {
        bool f = false;
        try
        {
            Music.Model.Songs song = new Music.Model.Songs();
            song.ID = 2;
            song.SongName = "爱在心口难开";
            song.Singer = "许嵩";
            song.UploadTime = DateTime.Now;
            song.UserID = 4;
            song.Path = @"D:\其他";
            song.Category = "古典";
            song.ClickCount = 0;

            f = Music.BLL.SongBusiness.ChangeSong(song);

            if (f)
            {
                Response.Write("<script>alert('修改歌曲成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('修改歌曲失败!')</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }
    }
}