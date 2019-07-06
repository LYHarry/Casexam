<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterSuccess.aspx.cs" Inherits="Manager_RegisterSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>注册成功</title>
    <%-- 导入管理员注册CSS文件 --%>
    <link href="../CSS/ManagerRegisterSite.css" rel="stylesheet" />
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
                    <span id="tilte">注册成功</span>

                    <div id="showCon">
                        <h1>欢迎您加入我们公司!</h1>
                        <p>根据您所填信息，我们将您安排如下:</p>

                        <div id="con">
                            <p>
                                所属部门:
                                <label><%= list[0].EmployeeDepartment %></label>
                            </p>
                            <p>
                                职位:
                                <label><%= list[0].EmployeePosition %></label>
                            </p>
                            <p>
                                所属权限:
                                <label><%= list[0].EmployeePower %></label>
                            </p>
                            <p>您的账号为:<label id="acc"><%= acc %></label></p>
                        </div>
                        <a href="ManagerLogin.aspx">去登录</a>

                        <p id="mana">安全提示:</p>
                        <p>
                            &nbsp;&nbsp;&nbsp;&nbsp;每个员工的账号都是唯一，并且员工账号绑定了你
                            的所有信息,所以请妥善保管您的账号!                       
                        </p>
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
