<%@ Page Title="" Language="C#" MasterPageFile="~/Master/FootMaster.master" AutoEventWireup="true" CodeFile="MailMode.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入修改密码CSS文件 --%>
    <link href="../CSS/AlterPawSite.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入更换验证码图片jQuery文件 --%>
    <script src="../jQuery/ChangeIdentifyCodeImgjQuery.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- LOGO --%>
    <div id="CycLogo">
        <img src="../Images/other/CycLogo.png" />
    </div>

    <%-- 导航条 --%>
    <div id="nav">
        <ul>
            <li>
                <a href="../Home/ListCyc.aspx">首页</a>
                <span id="partLine">></span>
            </li>
            <li>
                <a href="#">找回密码</a>
            </li>
        </ul>
    </div>

    <%-- 输入区域 --%>
    <div id="main">
        <ul>
            <li>
                <span>电子邮箱:</span>
                <asp:TextBox ID="TextBox1" CssClass="inputFrame PawInputFrame" runat="server" TextMode="Email" />
            </li>
            <li>
                <span>验 证 码:</span>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="testCode"></asp:TextBox>
                <img src="../Share/IdentifyingCode.aspx" runat="server"  id="checkCode" class="randomCodeImg" title="验证码" alt="验证码" />
                <img src="../Images/other/refresh.png" class="refresh" />
            </li>
        </ul>
        <asp:Button ID="Button1" runat="server" Text="下一步" CssClass="but" OnClick="Button1_Click" />
     
    </div>

</asp:Content>

