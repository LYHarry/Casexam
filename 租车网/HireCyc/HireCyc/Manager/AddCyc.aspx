<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="AddCyc.aspx.cs" Inherits="Manager_AddCyc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入添加车辆信息CSS文件 --%>
    <link href="../CSS/AddCycTypeSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="manager">
        <div id="opear">
            <input type="button" class="but" runat="server" onserverclick="del_ServerClick" id="del" value="删除" />
            <input type="button" class="but" runat="server" onserverclick="select_ServerClick" id="select" value="查询" />
            <input type="button" class="but" runat="server" onserverclick="alter_ServerClick" id="alter" value="修改" />
            <input type="button" class="but" id="create" value="添加" />
        </div>
        <table>

            <tr>
                <td>车辆名称</td>
                <td>
                    <asp:TextBox ID="TextBox1" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>所属类型</td>
                <td>
                 <select runat="server" id="cycType" class="dropFrame">
                     <option>请选择</option>
                 </select>
                
                 </tr>
            <tr>
                <td>车价</td>
                <td>
                    <asp:TextBox ID="TextBox3" CssClass="inputFrame" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <input type="button" id="butSub" class="butsub" onserverclick="butSub_ServerClick" runat="server" value="保存" />
    </div>
</asp:Content>

