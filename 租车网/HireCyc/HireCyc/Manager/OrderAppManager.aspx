<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="OrderAppManager.aspx.cs" Inherits="Manager_OrderAppManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入自行车管理CSS文件 --%>
    <link href="../CSS/OrderManager.css" rel="stylesheet" />
    <%-- 导入选择显示数据javascript文件 --%>
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
            <input type="button" class="but" onclick="DelDataId('orderApp')" id="del" value="删除" />
            <input type="button" class="but" runat="server" onserverclick="select_ServerClick" id="select" value="查询" />
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td id="checkWid">&nbsp;</td>
                        <td>评价表编号</td>
                        <td>订单编号</td>
                        <td>商品评分</td>
                        <td>商品评价内容</td>
                        <td>员工评分</td>
                        <td>员工评价内容</td>
                        <td>评价时间</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id='<%# Eval("OrderappraiseBowId") %>'>
                        <td>
                            <input type="checkbox" id="<%# Eval("OrderappraiseBowId") %>1" onclick='selectRow("<%#Eval("OrderappraiseBowId")%>    ")' /></td>
                        <td><%# Eval("OrderappraiseId") %></td>
                        <td><%# Eval("OrderappraiseBowId") %></td>
                        <td><%# Eval("OrderappraiseCycPf") %></td>
                        <td><%# Eval("OrderappraiseCycContent") %></td>
                        <td><%# Eval("OrderappraiseEmpPf") %></td>
                        <td><%# Eval("OrderappraiseEmpCont") %></td>
                         <td><%# Convert.ToDateTime( Eval("OrderappraiseSetTime")).ToString("yyyy-MM-dd") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

