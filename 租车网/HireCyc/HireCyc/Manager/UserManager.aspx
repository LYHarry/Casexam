<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="UserManager.aspx.cs" Inherits="Manager_UserManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入用户管理CSS文件 --%>
    <link href="../CSS/OrderManager.css" rel="stylesheet" />
    <%-- 导入选择显示信息javascript文件 --%>
    <script src="../jQuery/SelectShowConjavascript.js"></script>
    <%-- 导入一般处理类 --%>
    <script src="../jQuery/ajax.js"></script>
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="manager">
        <div id="opear">
            <input type="checkbox" id="check" onclick="selectAll()" />
            <input type="button" class="but" onclick="DelData('user')" id="del" value="删除" />
            <input type="button" class="but" runat="server" onserverclick="select_ServerClick" id="select" value="查询" />
            <input type="button" class="but" id="alter" value="修改" />
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td id="checkWid">&nbsp;</td>
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
                    <tr id="<%# Eval("UserAccount") %>">
                        <td>
                            <input type="checkbox" id="<%# Eval("UserAccount") %>1" onclick='selectRow("<%# Eval("UserAccount") %>    ")' /></td>
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

