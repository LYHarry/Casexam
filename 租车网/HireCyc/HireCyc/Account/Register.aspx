<%@ Page Title="" Language="C#" MasterPageFile="~/Master/FootMaster.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入注册CSS文件 --%>
    <link href="../CSS/RegisterSite.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入jQuery选项卡管理文件 --%>
    <script src="../jQuery/jquery.idTabs.min.js"></script>
    <%-- 导入更换验证码图片jQuery文件 --%>
    <script src="../jQuery/ChangeIdentifyCodeImgjQuery.js"></script>
    <%-- 导入密码强度javascript文件 --%>
    <script src="../jQuery/PasswordGrade.js"></script>
    <%-- 导入文本框水印js文件 --%>
    <script src="../jQuery/WaterMarkjs.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- logo --%>
    <img src="../Images/other/CycLogo.png" id="logo" />

    <%-- 注册方式 --%>
    <div id="regMode">
        <ul>
            <li>
                <a href="#tab1" class="selecded">手机注册</a>
            </li>
            <li>
                <a href="#tab2">邮箱注册</a>
            </li>
        </ul>
    </div>
    <%-- 主要内容 --%>
    <div id="content">

        <label id="com">注册Cyc账号</label>

        <%-- 手机 --%>
        <div id="tab1">
            <ul>
                <li>
                    <label>手机号码</label>
                    <asp:TextBox ID="TextBox1" Text="只能是11位手机号码"
                        onblur="WMOnBlur(this,'只能是11位手机号码');" onfocus="WMOnfocus(this,'只能是11位手机号码');"
                        MaxLength="11" CssClass="inputFrame" runat="server" />
                </li>
                <li>
                    <label>密&nbsp;&nbsp;&nbsp;&nbsp;码</label>
                    <input type="text" maxlength="16"
                        value="字母，数字,最长16位"
                        onblur="PawWMOnBlur(this, '字母，数字,最长16位');"
                        onfocus="PawWMOnfocus(this,'字母，数字,最长16位');"
                        id="passwordFrame" class="inputFrame" runat="server" />

                    <%--显示密码强度--%>
                    <div id="PWIntensityDiv" class="PWIntensity setClose">
                        <div id="IntenContent" class="weak"></div>
                    </div>

                </li>
                <li>
                    <label>确认密码</label>
                    <asp:TextBox ID="TextBox3" TextMode="Password" MaxLength="16" CssClass="inputFrame pawFrame" runat="server" />
                </li>
                <li>
                    <span>验 证 码</span>
                    <asp:TextBox ID="TextBox4" CssClass="testCode" runat="server" />
                    <asp:Button ID="Button1" CssClass="GetTestCode" runat="server" Text="获取验证码" OnClick="Button1_Click" />
                </li>
                <li>
                    <input id="cb1" type="checkbox" runat="server" class="agreeCheck" />
                    <label for="cb1">同意《Cyc帐号服务条款》</label>
                </li>
            </ul>
            <asp:Button ID="Button3" CssClass="but" runat="server" Text="立即注册" OnClick="Button3_Click" />
        </div>

        <%--   邮箱注册 --%>
        <div id="tab2">
            <ul>
                <li>
                    <label>邮&nbsp;&nbsp;&nbsp;&nbsp;箱</label>
                    <asp:TextBox ID="TextBox5" TextMode="Email" CssClass="inputFrame" runat="server" />
                </li>
                <li>
                    <label>密&nbsp;&nbsp;&nbsp;&nbsp;码</label>
                    <input type="text" maxlength="16"
                        value="字母，数字,最长16位"
                        onblur="PawWMOnBlur(this, '字母，数字,最长16位');"
                        onfocus="PawWMOnfocus(this,'字母，数字,最长16位');"
                        id="password1" class="inputFrame" runat="server" />

                    <%--显示密码强度--%>
                    <%-- <div id="PWIntensityDiv" class="PWIntensity setClose">
                        <div id="IntenContent" class="weak"></div>
                    </div>--%>

                </li>
                <li>
                    <label>确认密码</label>
                    <asp:TextBox ID="TextBox7" MaxLength="16" TextMode="Password"
                        CssClass="inputFrame pawFrame" runat="server" />
                </li>
                <li id="testCodeRow">
                    <label>验 证 码</label>
                    <asp:TextBox ID="TextBox8" CssClass="testCode" runat="server" />
                    <img src="../Share/IdentifyingCode.aspx" class="randomCodeImg" alt="验证码" />
                    <img src="../Images/other/refresh.png" title="点击更改验证码" class="refresh" />
                </li>
                <li>
                    <input id="cb2" type="checkbox" runat="server" class="agreeCheck" />
                    <label for="cb2">同意《Cyc帐号服务条款》</label>
                </li>
            </ul>
            <asp:Button ID="Button2" CssClass="but" runat="server" Text="立即注册" OnClick="Button2_Click" />
        </div>

    </div>

    <%--调用选项卡方法--%>
    <script type="text/javascript">
        $("#regMode ul").idTabs();
    </script>

</asp:Content>

