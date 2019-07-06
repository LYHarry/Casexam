<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="SelectEmp.aspx.cs" Inherits="Manager_SelectEmp" %>

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
                <asp:ListItem>部门</asp:ListItem>
                <asp:ListItem>账号</asp:ListItem>
                <asp:ListItem>姓名</asp:ListItem>
                <asp:ListItem>性别</asp:ListItem>
                <asp:ListItem>家庭地址</asp:ListItem>
                <asp:ListItem>进公司年限</asp:ListItem>
                <asp:ListItem>进公司时间</asp:ListItem>
            </asp:DropDownList>

            <input type="button" class="but" onserverclick="select_ServerClick" runat="server" id="select" value="查询" />
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>员工帐号</td>
                        <td>姓名</td>
                        <td>性别</td>
                        <td>权限</td>
                        <td>身份证号</td>
                        <td>电话</td>
                        <td>邮箱</td>
                        <td>出生日期</td>
                        <td>地址</td>
                        <td>进公司时间</td>
                        <td>职位</td>
                        <td>部门</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("EmployeeAccount") %></td>
                        <td><%# Eval("EmployeeName") %></td>
                        <td><%# Eval("EmployeerSex") %></td>
                        <td><%# Eval("EmployeePower") %></td>
                        <td><%# Eval("EmployeeCertificate") %></td>
                        <td><%# Eval("EmployeeTel") %></td>
                        <td><%# Eval("EmployeeEmail") %></td>
                        <td><%# Convert.ToDateTime(Eval("EmployeeBirth")).ToString("yyyy-MM-dd") %></td>
                        <td><%# Eval("EmployeeAddress") %></td>
                        <td><%# Convert.ToDateTime( Eval("EmployeeSettime")).ToString("yyyy-MM-dd") %></td>
                        <td><%# Eval("EmployeePosition") %></td>
                        <td><%# Eval("EmployeeDepartment") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

