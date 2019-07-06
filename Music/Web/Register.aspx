<%@ Page Title="" Language="C#" MasterPageFile="~/MusicMaster.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="register">
        <h4>
            用户注册</h4>
        <p>
            <label class="la_user">
                用户名:</label><asp:TextBox ID="tb_UserName" Width="120" runat="server"></asp:TextBox></p>
        <p>
            <label class="lab_password la_user">
                密码:</label><asp:TextBox ID="tb_Password" Width="120" runat="server"></asp:TextBox></p>
        <p>
            <label>
                确定密码:</label><asp:TextBox ID="tb_RePassword" Width="120" runat="server"></asp:TextBox></p>
        <p>
            <label>
                电子邮箱:</label><asp:TextBox ID="tb_Email" Width="120" runat="server"></asp:TextBox></p>
        <p>
            <label>
                注册角色:</label>
            <asp:RadioButton ID="rb_Admin" Text="管理员" runat="server" />
            <asp:RadioButton ID="rb_user" Text="普通" runat="server" />
        </p>
        <p>
            <asp:Button Text="注  册" runat="server" Width="80" ID="btn_Register" OnClick="btn_Register_Click" /></p>
    </div>
</asp:Content>
