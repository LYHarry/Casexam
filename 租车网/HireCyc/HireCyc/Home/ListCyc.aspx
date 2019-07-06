<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HomePageMaster.master" AutoEventWireup="true" CodeFile="ListCyc.aspx.cs" Inherits="Home_ListCyc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入车辆列表CSS文件 --%>
    <link href="../CSS/ListCycSite.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入车辆列表jQuery文件 --%>
    <script src="../jQuery/Commonjs.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel runat="server" ID="panel">
    </asp:Panel>

    <%-- 购物蓝区域 --%>
    <div id="shopCart">
        <table id="aiko">
            <tr>
                <td>车辆类型</td>
                <td>车辆名称</td>
                <td>数量</td>
                <td>删除</td>
            </tr>
            <tr id="shopvalue">
                <td><%= Session["cycTypeName"] %></td>
                <td><%= Session["cycName"] %></td>
                <td><%= Session["Cycnum"] %></td>
                <td><a href="#" runat="server" onserverclick="Unnamed_ServerClick">删除</a></td>
            </tr>
        </table>
    </div>

    <%-- 购物蓝提交按钮区域 --%>
    <div id="shopBut">
        <label><%= Session["cycTypeName"] %></label>
        <label><%= Session["Cycnum"] %></label>
        <input type="button" id="subBut" class="subBut" runat="server" onserverclick="subBut_ServerClick" value="去预定" />
    </div>
</asp:Content>