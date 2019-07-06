<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="PowerManager.aspx.cs" Inherits="Manager_PowerManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入权限管理CSS文件 --%>
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
            <input type="button" class="but" onclick="DelData('power')" id="del" value="删除" />
            <input type="button" class="but" id="alter" value="修改" />
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td id="checkWid">&nbsp;</td>
                        <td>权限名称</td>
                        <td>系统设置权限</td>
                        <td>用户管理权限</td>
                        <td>车辆管理权限</td>
                        <td>员工管理权限</td>
                        <td>订单管理权限</td>
                        <td>用户查询权限</td>
                        <td>车辆查询权限</td>
                        <td>员工查询权限</td>
                        <td>订单查询权限</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="<%# Eval("AdmSetName") %>">
                        <td>
                            <input type="checkbox" id="<%# Eval("AdmSetName") %>1" onclick='selectRow("<%# Eval("AdmSetName") %>    ")' /></td>
                        <td><%# Eval("AdmSetName") %></td>
                        <td><%# Eval("AdmSetSystemManage") %></td>
                        <td><%# Eval("AdmSetBorrowerManage") %></td>
                        <td><%# Eval("AdmSetCycManage") %></td>
                        <td><%# Eval("AdmSetEmpManage") %></td>
                        <td><%# Eval("AdmSetBowManage") %></td>
                        <td><%# Eval("AdmSetBorrowerLook") %></td>
                        <td><%# Eval("AdmSetCycLook") %></td>
                        <td><%# Eval("AdmSetEmpLook") %></td>
                        <td><%# Eval("AdmSetBowLook") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>


</asp:Content>

