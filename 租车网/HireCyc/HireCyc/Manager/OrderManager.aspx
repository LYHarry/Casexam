<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="OrderManager.aspx.cs" Inherits="Manager_OrderManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入订单管理CSS文件 --%>
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
            <input type="button" class="but" onclick="DelDataId('order')" id="del" value="删除" />
            <input type="button" class="but" id="select" runat="server" onserverclick="select_ServerClick" value="查询" />
            <input type="button" class="but" id="alter" value="修改" />
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td id="checkWid">&nbsp;</td>
                        <td>订单编号</td>
                        <td>用户帐号</td>
                        <td>租车数</td>
                        <td>订单创建时间</td>
                        <td>订单状态</td>
                        <td>租金</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id='<%# Eval("CycBorrowId") %>'>
                        <td>
                            <input type="checkbox" id="<%# Eval("CycBorrowId") %>1" onclick='selectRow("<%#Eval("CycBorrowId")%>    ")' /></td>
                        <td><%# Eval("CycBorrowId") %></td>
                        <td><%# Eval("CycBorrowBowCode") %></td>
                        <td><%# Eval("CycBorrowCount") %></td>
                        <td><%# Convert.ToDateTime( Eval("CycBorrowSetTime")).ToString("yyyy-MM-dd") %></td>
                        <td><%# Eval("CycBorrowStatus") %></td>
                        <td><%# Eval("CycBorrowRealMoney") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>

</asp:Content>

