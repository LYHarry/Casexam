<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" ValidateRequest="false" Inherits="全国地址.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>得到全国地址</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--    开始配置HTML标签<br />
            <asp:TextBox TextMode="MultiLine" runat="server" Width="400" Height="100" ID="txt_startReg"></asp:TextBox>
            <br />
            结束配置HTML标签<br />
            <asp:TextBox TextMode="MultiLine" runat="server" Width="400" Height="100" ID="txt_endReg"></asp:TextBox>
            <br />--%>
            <asp:Button runat="server" Text="开始配置" OnClick="Unnamed_Click" />
        </div>
    </form>
</body>
</html>
