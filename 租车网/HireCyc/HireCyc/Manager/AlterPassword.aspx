<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="AlterPassword.aspx.cs" Inherits="Manager_AlterPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 管理员修改密码CSS文件 --%>
    <link href="../CSS/ManagerAlterPassword.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 
    <script src="../jQuery/jquery-2.1.1.js"></script>--%>
    <%-- 导入密码强度javascript文件 
    <script src="../jQuery/PasswordGrade.js"></script>--%>
    <%-- 导入文本框水印js文件 --%>
    <script src="../jQuery/WaterMarkjs.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="main">
        <label>请妥善保管您的密码！</label>

        <ul>
            <li>
                <span>原 密 码:</span>
                <asp:TextBox ID="TextBox1" placeholder="字母，数字，下划线，最长16位" CssClass="inputFrame" TextMode="Password" MaxLength="16" runat="server" />
            </li>
            <li>
                <span>新 密 码:</span>
                <input type="text"
                    value="字母，数字,最长16位"
                    onblur="PawWMOnBlur(this, '字母，数字,最长16位');"
                    onfocus="PawWMOnfocus(this,'字母，数字,最长16位');"
                    runat="server" id="passwordFrame" class="PawInputFrame" />

                <%-- 显示密码强度 --%>
                <div id="PWIntensityDiv" class="PWIntensity setClose">
                    <div id="IntenContent" class="weak"></div>
                </div>
            </li>
            <li>
                <span>确认密码:</span>
                <asp:TextBox ID="TextBox2" placeholder="字母，数字，下划线，最长16位" CssClass="inputFrame" TextMode="Password" MaxLength="16" runat="server" />
            </li>
        </ul>

        <asp:Button ID="Button1" CssClass="but" OnClick="Button1_Click" runat="server" Text="确定" />
    </div>

</asp:Content>
