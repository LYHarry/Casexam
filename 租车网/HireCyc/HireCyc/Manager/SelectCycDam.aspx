<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="SelectCycDam.aspx.cs" Inherits="Manager_SelectCycDam" %>

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
                <asp:ListItem>车辆类型</asp:ListItem>
                <asp:ListItem>毁坏情况</asp:ListItem>
            </asp:DropDownList>

            <input type="button" class="but" onserverclick="select_ServerClick" runat="server" id="select" value="查询" />
        </div>

        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>情况编号</td>
                        <td>车辆类型名称</td>
                        <td>车辆毁坏情况</td>
                        <td>罚金</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("CycDamageId") %></td>
                        <td><%# Eval("CycDamageCycType") %></td>
                        <td><%# Eval("CycDamageSituation") %></td>
                        <td><%# Eval("CycDamageMoney") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>


</asp:Content>

