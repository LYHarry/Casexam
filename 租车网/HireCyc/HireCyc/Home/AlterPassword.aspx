<%@ Page Title="" Language="C#" MasterPageFile="~/Master/FootMaster.master" AutoEventWireup="true" CodeFile="AlterPassword.aspx.cs" Inherits="Account_AlterPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入修改密码CSS文件 --%>
    <link href="../CSS/AlterPawSite.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入密码强度javascript文件 --%>
    <script src="../jQuery/PasswordGrade.js"></script>
    <%-- 导入文本框水印js文件 --%>
    <script src="../jQuery/WaterMarkjs.js"></script>
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
                <a href="QuestionList.aspx">首页</a>
                <span id="partLine">></span>
            </li>
            <li>
                <a href="#">重置密码</a>
            </li>
        </ul>
    </div>

    <%-- 输入区域 --%>
    <div id="main">
        <label>请妥善保管您的密码！</label>
        <ul>
            <li>
                <span>新 密 码:</span>
                <input type="text" maxlength="16" value="字母，数字,最长16位"
                    onblur="PawWMOnBlur(this, '字母，数字,最长16位');"
                    onfocus="PawWMOnfocus(this,'字母，数字,最长16位');"
                    id="passwordFrame" class="inputFrame" runat="server" />
                <%-- 显示密码强度 --%>
                <div id="PWIntensityDiv" class="PWIntensity setClose">
                    <div id="IntenContent" class="weak"></div>
                </div>
            </li>

            <li>
                <span>确认密码:</span>
                <asp:TextBox ID="TextBox2" CssClass="inputFrame PawInputFrame" TextMode="Password" MaxLength="16" runat="server" />
            </li>
        </ul>

        <asp:Button ID="Button1" CssClass="but" runat="server" Text="确定" OnClick="btn_alterPaw" />

    </div>


</asp:Content>

