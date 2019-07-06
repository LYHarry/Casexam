<%@ Page Title="" Language="C#" MasterPageFile="~/MusicMaster.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="login">
        <h4>
            用户登录</h4>
        <p>
            <label>
                用户名:</label><asp:TextBox ID="tb_UserName" runat="server"></asp:TextBox></p>
        <p>
            <label class="lab_password">
                密码:</label><asp:TextBox ID="tb_Password" runat="server" TextMode="Password"></asp:TextBox></p>
        <p>
            <asp:Button Text="登 录" runat="server" Width="80" ID="btn_Login" OnClick="btn_Login_Click" /></p>
    </div>
</asp:Content>
