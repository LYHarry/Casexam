<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerLogin.aspx.cs" Inherits="Manager_ManagerLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>后台登录</title>
    <%-- 导入自行车租赁系统后台登录CSS文件 --%>
    <link href="../CSS/ManagerLoginSite.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="login_area">
            <div id="import_area">
                <div>
                    <label>用户名：</label>
                    <input type="text" runat="server" id="name">
                </div>

                <div>
                    <label>密&nbsp;&nbsp;码：</label>
                    <input type="password" maxlength="16" runat="server" id="pwd">
                </div>

                <div id="btn_area">
                    <input type="button" id="login_sub" onserverclick="login_sub_ServerClick" runat="server" value="登  录">
                    <input type="reset" id="login_ret" runat="server" value="重 置">
                </div>
            </div>
        </div>
    </form>
</body>
</html>