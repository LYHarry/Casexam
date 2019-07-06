<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="CycTypeManager.aspx.cs" Inherits="Manager_CycTypeManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入车辆类型管理CSS文件 --%>
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
            <input type="button" class="but" onclick="DelData('cycType')" id="del" value="删除" />
            <input type="button" class="but" id="select" value="查询" />
            <input type="button" class="but" id="alter" value="修改" />
            <input type="button" class="but" id="create" onserverclick="create_ServerClick" runat="server" value="添加" />
        </div>
        
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td id="checkWid">&nbsp;</td>
                        <td>车辆类型名称</td>
                        <td>库存</td>
                        <td>押金</td>
                        <td>租金_小时</td>
                        <td>租金_天</td>
                        <td>迟还的租金_小时</td>
                        <td>迟还的租金_天</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="<%# Eval("CycTypeName") %>">
                        <td>
                            <input type="checkbox" name="listCheck" id="<%# Eval("CycTypeName") %>1" onclick='selectRow("<%#Eval("CycTypeName")%>    ")' /></td>
                        <td><%# Eval("CycTypeName") %></td>
                        <td><%# Eval("CycTypeStock") %></td>
                        <td><%# Eval("CycTypeHire") %></td>
                        <td><%# Eval("CycTypeLagHrMoney") %></td>
                        <td><%# Eval("CycTypeLagDayMoney") %></td>
                        <td><%# Eval("CycTypeLateHrMoney") %></td>
                        <td><%# Eval("CycTypeLateDayMoney") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>

