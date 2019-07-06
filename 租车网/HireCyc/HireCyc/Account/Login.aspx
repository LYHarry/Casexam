<%@ Page Title="" Language="C#" MasterPageFile="~/Master/FootMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入登陆CSS文件 --%>
    <link href="../CSS/LoginSite.css" rel="stylesheet" />
    <%-- 导入登陆jQuery文件 --%>
    <script src="../jQuery/LoginjQuery.js"></script>
    <%-- 导入文本框水印js文件 --%>
    <script src="../jQuery/WaterMarkjs.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- logo图片 --%>
    <div class="loginLogo">
        <img src="../Images/other/LoginLogo.png" />
        <span>自行车租赁系统</span>
    </div>

    <%-- 大图片 --%>
    <div id="showImage">
        <img src="../Images/other/login1.jpg" />
    </div>

    <%-- 登录区域 --%>
    <div class="login-panel">

        <label>欢迎登陆Cyc账号</label>

        <ul>
            <li>
                <asp:TextBox ID="TextBox1" Text="邮箱/手机号码"
                    onblur="WMOnBlur(this,'邮箱/手机号码');" onfocus="WMOnfocus(this,'邮箱/手机号码');"
                    CssClass="inputFrame" runat="server" />
            </li>
            <li>
                <asp:TextBox ID="TextBox2" Text="密码"
                    onblur="PawWMOnBlur(this,'密码');" onfocus="PawWMOnfocus(this,'密码');"
                    CssClass="inputFrame" runat="server" />
            </li>
            <li>
                <asp:TextBox ID="TextBox3" Text="验证码"
                    onblur="WMOnBlur(this,'验证码');" onfocus="WMOnfocus(this,'验证码');"
                    CssClass="testCode" runat="server" />
                <img src="../Share/IdentifyingCode.aspx" runat="server" id="checkCode" class="randomCodeImg" title="点击更改验证码" alt="验证码" />
            </li>
            <li>
                <asp:Button ID="Button1" runat="server" CssClass="loginSub" Text="登录" OnClick="Button1_Click" />
            </li>
            <li>
                <a href="Register.aspx" target="_self" class="register">注册账号</a>
                <a href="PasswordRecoverMode.aspx" target="_self" class="forgetPaw">忘记密码?</a>
            </li>
        </ul>
    </div>

</asp:Content>

