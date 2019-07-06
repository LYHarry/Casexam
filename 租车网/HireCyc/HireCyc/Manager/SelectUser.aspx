<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="SelectUser.aspx.cs" Inherits="Manager_SelectUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入查询自行车CSS文件 --%>
    <link href="../CSS/OrderManager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="manager">
        <div id="opear">
            <%-- 文本输入框 --%>
            <input type="text" class="inputFrame" runat="server" id="text" />

            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" CssClass="dropList" runat="server">
                <asp:ListItem>账号</asp:ListItem>
                <asp:ListItem>姓名</asp:ListItem>
                <asp:ListItem>性别</asp:ListItem>
                <asp:ListItem>家庭地址</asp:ListItem>
                <asp:ListItem>注册时间</asp:ListItem>
            </asp:DropDownList>

            <input type="button" class="but" onserverclick="select_ServerClick" runat="server" id="select" value="查询" />
        </div>

        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>用户帐号</td>
                        <td>姓名</td>
                        <td>性别</td>
                        <td>身份证号</td>
                        <td>电话</td>
                        <td>邮箱</td>
                        <td>昵称</td>
                        <td>地址</td>
                        <td>注册时间</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("UserAccount") %></td>
                        <td><%# Eval("UserName") %></td>
                        <td><%# Eval("UserSex") %></td>
                        <td><%# Eval("UserCertificate") %></td>
                        <td><%# Eval("UserTel") %></td>
                        <td><%# Eval("UserEmail") %></td>
                        <td><%# Eval("UserNickName") %></td>
                        <td><%# Eval("UserAddress") %></td>
                        <td><%# Convert.ToDateTime( Eval("UserSetting")).ToString("yyyy-MM-dd") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>

