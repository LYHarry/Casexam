<%@ Page Title="" Language="C#" MasterPageFile="../Master/FootMaster.master" AutoEventWireup="true" CodeFile="PhoneMode.aspx.cs" Inherits="Account_ForgetPaw" %>

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
                <a href="ListCyc.aspx">首页</a>
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
                <span>手机号码:</span>
                <asp:TextBox ID="TextBox1" Text="只能是11位手机号码"
                    onblur="WMOnBlur(this,'只能是11位手机号码');" onfocus="WMOnfocus(this,'只能是11位手机号码');"
                    CssClass="inputFrame" runat="server" TextMode="Phone" />
            </li>

            <li>
                <span>验 证 码:</span>
                <asp:TextBox ID="TextBox2" CssClass="testCode" runat="server" />
                <asp:Button ID="Button1" OnClick="Button1_Click" class="GetTestCode" runat="server" Text="获取验证码" />
            </li>
        </ul>
        <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="确定" class="but" />

    </div>


</asp:Content>

