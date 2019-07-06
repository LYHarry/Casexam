<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="SelectFeedback.aspx.cs" Inherits="Manager_SelectFeedback" %>

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
                <asp:ListItem>主题</asp:ListItem>
                <asp:ListItem>反馈时间</asp:ListItem>
            </asp:DropDownList>

            <input type="button" class="but" onserverclick="select_ServerClick" runat="server" id="select" value="查询" />
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>反馈表编号</td>
                        <td>主题</td>
                        <td>反馈内容</td>
                        <td>反馈人联系方式</td>
                        <td>反馈时间</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("FeedbackId") %></td>
                        <td><%# Eval("FeedbackTheme") %></td>
                        <td><%# Eval("FeedbackContent") %></td>
                        <td><%# Eval("FeedbackTel") %></td>
                        <td><%# Convert.ToDateTime( Eval("FeedbackTime")).ToString("yyyy-MM-dd") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>

