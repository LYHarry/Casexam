<%@ Page Title="" Language="C#" MasterPageFile="~/Master/FootMaster.master" AutoEventWireup="true" CodeFile="AlterPhone.aspx.cs" Inherits="Account_AlterPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入修改密码CSS文件 --%>
    <link href="../CSS/AlterPawSite.css" rel="stylesheet" />
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
                <a href="MyCenter.aspx">首页</a>
                <span id="partLine">></span>
            </li>
            <li>
                <a href="#">更改绑定电话</a>
            </li>
        </ul>
    </div>
    <%-- 输入区域 --%>
    <div id="main">
        <ul>
            <li>
                <span>电话号码:</span>
                <input type="text" runat="server" id="Frame" class="PawInputFrame" />
            </li>
            <li>
                <span>验 证 码:</span>
                <asp:TextBox ID="TextBox2" CssClass="testCode" runat="server" />
                <img src="../Share/IdentifyingCode.aspx" class="randomCodeImg" alt="验证码" />
                <img src="../Images/other/refresh.png" title="点击更改验证码" class="refresh" />
            </li>
        </ul>

        <asp:Button ID="Button1" CssClass="but" runat="server" Text="确定" OnClick="btn_alterPaw" />

    </div>

</asp:Content>

