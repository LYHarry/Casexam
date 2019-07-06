<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="AddCycType.aspx.cs" Inherits="Manager_AddCycType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入添加车辆类型CSS文件 --%>
    <link href="../CSS/AddCycTypeSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="manager">
        <div id="opear">
            <input type="button" class="but" id="del" runat="server" onserverclick="del_ServerClick" value="删除" />
            <input type="button" class="but" id="select" runat="server" onserverclick="select_ServerClick" value="查询" />
            <input type="button" class="but" id="alter" runat="server" onserverclick="alter_ServerClick" value="修改" />
            <input type="button" class="but" id="create" value="添加" />
        </div>
        <table>
            <tr>
                <td>车辆类型名称</td>
                <td>
                    <asp:TextBox ID="TextBox7" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>库存</td>
                <td>
                    <asp:TextBox ID="TextBox1" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>押金</td>
                <td>
                    <asp:TextBox ID="TextBox2" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>租金_小时</td>
                <td>
                    <asp:TextBox ID="TextBox3" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>租金_天</td>
                <td>
                    <asp:TextBox ID="TextBox4" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>迟还的租金_小时</td>
                <td>
                    <asp:TextBox ID="TextBox5" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>迟还的租金_天</td>
                <td>
                    <asp:TextBox ID="TextBox6" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <input type="button" id="butSub" class="butsub" onserverclick="butSub_ServerClick" runat="server" value="保存" />
    </div>

</asp:Content>

