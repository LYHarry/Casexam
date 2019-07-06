<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="FeedbackManager.aspx.cs" Inherits="Manager_FeedbackManager" %>

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
            <input type="button" class="but" onclick="DelDataId('feed')" id="del" value="删除" />
            <input type="button" class="but" id="select" runat="server" onserverclick="select_ServerClick" value="查询" />
            <input type="button" class="but" id="alter" value="修改" />
        </div>

        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td id="checkWid">&nbsp;</td>
                        <td>反馈表编号</td>
                        <td>主题</td>
                        <td>反馈内容</td>
                        <td>反馈人联系方式</td>
                        <td>反馈时间</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id="<%# Eval("FeedbackId") %>">
                        <td>
                            <input type="checkbox" name="listCheck" id="<%# Eval("FeedbackId") %>1" onclick='selectRow("<%#Eval("FeedbackId")%>    ")' /></td>
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

