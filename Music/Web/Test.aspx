<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            测试页面</h2>
        <hr />
        <asp:Button ID="btn_AddUser" runat="server" Text="添加用户" OnClick="btn_AddUser_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_GetAllUsers" runat="server" Text="显示所有用户" OnClick="btn_GetAlUsers_Click" />
        <asp:GridView ID="gv_ShowAllUsers" runat="server">
        </asp:GridView>
        <br />
        <hr />
        <asp:Button ID="btn_UserIsExist" runat="server" Text="判断用户是否存在" OnClick="btn_UserIsExist_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_DeleteUser" runat="server" Text="删除用户" OnClick="btn_DeleteUser_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_ChangePassword" runat="server" Text="更改密码" OnClick="btn_ChangePassword_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_UserLogin" runat="server" Text="用户登录" OnClick="btn_UserLogin_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_AddSong" runat="server" Text="添加歌曲" OnClick="btn_AddSong_Click" />
        <br />
        <hr />
        <asp:Button ID="DeleteSong" runat="server" Text="删除歌曲" OnClick="DeleteSong_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_GetSong" runat="server" Text="获取指定的歌曲" OnClick="btn_GetSong_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_AddClickCount" runat="server" Text="添加歌曲的点击次数" OnClick="btn_AddClickCount_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_ShowAllSongs" runat="server" Text="显示所有歌曲" OnClick="btn_ShowAllSongs_Click" /><asp:GridView
            ID="gv_ShowSongs" runat="server">
        </asp:GridView>
        <br />
        <hr />
        <asp:Button ID="btn_GetNewSongs" runat="server" Text="显示最新上传的歌曲" OnClick="btn_GetNewSongs_Click" /><asp:GridView
            ID="gv_ShowNewSongs" runat="server">
        </asp:GridView>
        <br />
        <hr />
        <asp:Button ID="btn_ShowHotSong" runat="server" Text="显示最热歌曲" OnClick="btn_ShowHotSong_Click" />
        <asp:GridView ID="gv_ShowHotSong" runat="server">
        </asp:GridView>
        <br />
        <hr />
        <asp:Button ID="btn_ShowUser" runat="server" Text="显示指定用户" OnClick="btn_ShowUser_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_ShowNewUsers" runat="server" Text="显示最近注册的用户" OnClick="btn_ShowNewUsers_Click" /><asp:GridView
            ID="gv_ShowNewUsers" runat="server">
        </asp:GridView>
        <br />
        <hr />
        <asp:Button ID="btn_GetSongsByUser" runat="server" Text="获取指定用户上传的歌曲" OnClick="btn_GetSongsByUser_Click" /><asp:GridView
            ID="gv_GetSongsByUser" runat="server">
        </asp:GridView>
        <br />
        <hr />
        <asp:Button ID="btn_GetUserBySong" runat="server" Text="获取歌曲对应的用户" OnClick="btn_GetUserBySong_Click" />
        <br />
        <hr />
        <asp:Button ID="btn_GetSongsBySongName" runat="server" Text="按歌曲名查询歌曲" OnClick="btn_GetSongsBySongName_Click" />
        <asp:GridView ID="gv_GetSongsBySongName" runat="server">
        </asp:GridView>
        <br />
        <hr />
        <asp:Button ID="btn_GetSongsBySinger" runat="server" Text="按歌手查找歌曲" 
            onclick="btn_GetSongsBySinger_Click" />
        <asp:GridView ID="gv_GetSongsBySinger" runat="server">
        </asp:GridView>

           <br />
        <hr />
        <asp:Button ID="btn_ChangeSong" runat="server" Text="修改歌曲" 
            onclick="btn_ChangeSong_Click" />

    </div>
    </form>
</body>
</html>
