<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="SelectOrderApp.aspx.cs" Inherits="Manager_SelectOrderApp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入查询自行车CSS文件 --%>
    <link href="../CSS/OrderManager.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="manager">
        <div id="opear">
            <%-- 文本输入框 --%>
            <input type="text" class="inputFrame" runat="server" id="text" />

            <asp:DropDownList ID="DropDownList1"
                CssClass="dropList" runat="server">
                <asp:ListItem>订单编号</asp:ListItem>
                <asp:ListItem>用户账号</asp:ListItem>
                <asp:ListItem>评价时间</asp:ListItem>
            </asp:DropDownList>

            <input type="button" class="but" onserverclick="select_ServerClick" runat="server" id="select" value="查询" />
        </div>

        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
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
                    <tr>
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

