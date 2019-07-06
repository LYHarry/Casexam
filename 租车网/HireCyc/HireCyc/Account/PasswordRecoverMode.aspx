<%@ Page Title="" Language="C#" MasterPageFile="~/Master/FootMaster.master" AutoEventWireup="true" CodeFile="PasswordRecoverMode.aspx.cs" Inherits="Account_PasswordRecoverMode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入找回密码方式CSS文件 --%>
    <link href="../CSS/PasswordRecoverModeSite.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入修改密码jQuery文件 --%>
    <script src="../jQuery/RecoverPasswordjQuery.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="bodyStyle">
        <img src="../Images/other/CycLogo.png" id="logo" />
        <div id="news1">
            <label id="getPaw">找回密码</label><br />
            <label>为了您的帐号安全，我们为您提供了以下方式修改密码:</label>
        </div>

        <div id="mailGet">
            <ul>
                <li>
                    <img src="../Images/other/mailGet.png" />
                </li>
                <li>
                    <label>用邮箱找回</label>
                </li>
            </ul>
        </div>

        <div id="phoneGet">
            <ul>
                <li>
                    <img src="../Images/other/PhoneGet.png" />
                </li>
                <li>
                    <label>用手机找回</label>
                </li>
            </ul>
        </div>

        <div id="news2">
            <label>找回密码遇到问题？</label><br />
            <label>请联系客服:18227100351</label>
        </div>
    </div>

</asp:Content>

