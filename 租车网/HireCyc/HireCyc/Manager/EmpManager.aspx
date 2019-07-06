<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="EmpManager.aspx.cs" Inherits="Manager_EmpManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入员工管理CSS文件 --%>
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
            <input type="button" class="but" onclick="DelData('Emp')" id="del" value="删除" />
            <input type="button" class="but" id="select" runat="server" onserverclick="select_ServerClick" value="查询" />
            <input type="button" class="but" id="alter" value="修改" />
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td id="checkWid">&nbsp;</td>
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
                    <tr id="<%# Eval("EmployeeAccount") %>">
                        <td>
                            <input type="checkbox" id="<%# Eval("EmployeeAccount") %>1" onclick='selectRow("<%#Eval("EmployeeAccount")%>    ")' /></td>
                        <td><%# Eval("EmployeeAccount") %></td>
                        <td><%# Eval("EmployeeName") %></td>
                        <td><%# Eval("EmployeerSex") %></td>
                        <td><%# Eval("EmployeePower") %></td>
                        <td><%# Eval("EmployeeCertificate") %></td>
                        <td><%# Eval("EmployeeTel") %></td>
                        <td><%# Eval("EmployeeEmail") %></td>
                        <td><%# Convert.ToDateTime( Eval("EmployeeBirth")).ToString("yyyy-MM-dd") %></td>
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

