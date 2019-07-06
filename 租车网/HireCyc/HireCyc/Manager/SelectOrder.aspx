<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="SelectOrder.aspx.cs" Inherits="Manager_SelectOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入查询自行车CSS文件 --%>
    <link href="../CSS/OrderManager.css" rel="stylesheet" />
    <%-- 导入文本框水印js文件 --%>
    <script src="../jQuery/WaterMarkjs.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="manager">
        <div id="opear">
            <%-- 文本输入框 --%>
            <input type="text" class="inputFrame" runat="server" id="text" />

            <asp:Label ID="Label1" CssClass="label disShow" runat="server" Text="Label">起始时间</asp:Label>
            <asp:TextBox ID="TextBox3" CssClass="inputFrame disShow" Text="请选择"
                onblur="WMOnBlur(this,'请选择');" onfocus="WMOnfocus(this,'请选择');"
                runat="server"></asp:TextBox>

            <%--<asp:CalendarExtender ID="CalendarExtender1" 
                TargetControlID="TextBox3" Format="yyyy-MM-dd"
                runat="server"></asp:CalendarExtender>--%>

            <asp:Label ID="Label2" CssClass="label disShow" runat="server" Text="Label">结束时间</asp:Label>
            <asp:TextBox ID="TextBox4" CssClass="inputFrame disShow " Text="请选择"
                onblur="WMOnBlur(this,'请选择');" onfocus="WMOnfocus(this,'请选择');"
                runat="server"></asp:TextBox>


            <%--  <asp:CalendarExtender ID="CalendarExtender2"
                TargetControlID="TextBox4" Format="yyyy-MM-dd"
                 runat="server"></asp:CalendarExtender>--%>
            <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                AutoPostBack="true" CssClass="dropList" runat="server">
                <asp:ListItem>订单状态</asp:ListItem>
                <asp:ListItem>订单时间段</asp:ListItem>
            </asp:DropDownList>

            <input type="button" class="but" onserverclick="select_ServerClick" runat="server" id="select" value="查询" />
        </div>

        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>订单编号</td>
                        <td>用户帐号</td>
                        <td>租车数</td>
                        <td>订单创建时间</td>
                        <td>订单状态</td>
                        <td>租金</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
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

