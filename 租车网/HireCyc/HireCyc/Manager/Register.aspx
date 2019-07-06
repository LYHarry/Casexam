<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Manager_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>员工注册</title>
    <%-- 导入员工注册CSS文件 --%>
    <link href="../CSS/ManagerRegisterSite.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入我国诚市列表jQuery文件 --%>
    <script src="../jQuery/city.min.js"></script>
    <%-- 导入选择诚市联动jQuery文件 --%>
    <script src="../jQuery/jquery.cityselect.js"></script>
    <%-- 导入文本框水印js文件 --%>
    <script src="../jQuery/WaterMarkjs.js"></script>
    <%-- 获取地址js文件 --%>
    <script src="../jQuery/Commonjs.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="topCon">
            <img src="../Images/other/ManagerLogo.png" />

            <div id="encoded">
                <a href="#">简体中文</a>
                <span>|</span>
                <a href="#">繁體中文</a>
                <span>|</span>
                <a href="#">English</a>
            </div>
        </div>

        <div id="middleCon">
            <div id="leftCon">
                <span>完善信息</span>

                <div id="fontCon">
                    <span>联系方式</span>
                    <ul>
                        <li>Contact：刘万李冯</li>
                        <li>Tel:18227100351</li>
                        <li>Email:919793260@qq.com</li>
                        <li>Address:四川德阳工院</li>
                    </ul>
                </div>

            </div>

            <div id="rightCon">

                <div id="showImg">
                    <img src="../Images/other/13031Q55113-9.jpg" />
                </div>
                <div id="content">
                    <span id="tilte">申请账号</span>

                    <div id="inputCon">
                        <ul>
                            <li>
                                <label>姓&nbsp;&nbsp;&nbsp;&nbsp;名</label>
                                <asp:TextBox ID="TextBox9" CssClass="inputFrame" runat="server" />
                            </li>
                            <li>
                                <label>密&nbsp;&nbsp;&nbsp;&nbsp;码</label>
                                <asp:TextBox ID="TextBox3" Text="字母，数字,最长16位"
                                    onblur="PawWMOnBlur(this, '字母，数字,最长16位');"
                                    onfocus="PawWMOnfocus(this,'字母，数字,最长16位');"
                                    MaxLength="16" CssClass="inputFrame grayCol" runat="server" />
                            </li>
                            <li>
                                <label>确认密码</label>
                                <asp:TextBox ID="TextBox5" TextMode="Password" MaxLength="16" CssClass="inputFrame" runat="server" />
                            </li>
                            <li>
                                <label>性&nbsp;&nbsp;&nbsp;&nbsp;别</label>
                                <asp:RadioButton ID="male" Checked="true" GroupName="sex" runat="server" />
                                <label>男</label>
                                <asp:RadioButton ID="female" GroupName="sex" runat="server" />
                                <label>女</label>
                            </li>
                            <li>
                                <label>电话号码</label>
                                <asp:TextBox ID="TextBox10" Text="只能是11位手机号码"
                                    onblur="WMOnBlur(this,'只能是11位手机号码');" onfocus="WMOnfocus(this,'只能是11位手机号码');"
                                    MaxLength="11" CssClass="inputFrame grayCol" runat="server" />
                            </li>
                            <li>
                                <label>出生日期</label>
                                <asp:DropDownList runat="server" CssClass="dropList" AutoPostBack="true" ID="year" OnSelectedIndexChanged="year_SelectedIndexChanged">
                                    <asp:ListItem>年</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList runat="server" CssClass="dropList" AutoPostBack="true" ID="month" OnSelectedIndexChanged="month_SelectedIndexChanged">
                                    <asp:ListItem>月</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList runat="server" CssClass="dropList" AutoPostBack="true" ID="day">
                                    <asp:ListItem>日</asp:ListItem>
                                </asp:DropDownList>
                            </li>
                            <li>
                                <label>身份证号</label>
                                <asp:TextBox ID="TextBox2" MaxLength="18" CssClass="inputFrame" runat="server" />
                            </li>
                            <li>
                                <label>电子邮箱</label>
                                <asp:TextBox ID="TextBox4" TextMode="Email" CssClass="inputFrame" runat="server" />
                            </li>
                            <li>
                                <label id="cityFont">家庭住址</label>
                                <div id="citySelect">
                                    <select id="prov" onchange="GetProv(this)" class="dropList">
                                    </select>
                                    <select id="city" onchange="GetCity(this)" class="dropList">
                                        <option>请选择</option>
                                    </select>
                                    <select id="dist" onchange="GetDist(this)" class="dropList">
                                        <option>请选择</option>
                                    </select>
                                </div>
                                <input type="hidden" id="GetAdd" name="GetAdd" />
                            </li>
                            <li>
                                <asp:TextBox ID="TextBox1" CssClass="addressInput" runat="server" Text="详细地址"
                                    onblur="WMOnBlur(this,'详细地址');" onfocus="WMOnfocus(this,'详细地址');" />
                            </li>
                            <li>
                                <asp:CheckBox ID="CheckBox1" CssClass="agreeCheck" runat="server" />
                                <label for="CheckBox1">我已阅读并同意相关服务条款和隐私政策</label>
                            </li>
                        </ul>
                        <asp:Button ID="Button2" OnClick="Button2_Click" CssClass="but" runat="server" Text="立即注册" />
                    </div>
                </div>
            </div>
        </div>

        <div id="footCon">
            <p>Copyright &copy;2014-2020 HireCyc, All Rights Reserved.</p>
        </div>


    </form>
</body>
</html>
