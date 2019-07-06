<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="CycDamManager.aspx.cs" Inherits="Manager_CycDamManager" %>

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
            <input type="button" class="but" onclick="DelDataId('cycDam')" id="del" value="删除" />
            <input type="button" class="but" runat="server" onserverclick="select_ServerClick" id="select" value="查询" />
            <input type="button" class="but" id="alter" value="修改" />
            <input type="button" class="but" runat="server" onserverclick="create_ServerClick"  id="create" value="添加" />
        </div>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td id="checkWid">&nbsp;</td>
                        <td>情况编号</td>
                        <td>车辆类型名称</td>
                        <td>车辆毁坏情况</td>
                        <td>罚金</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr id='<%# Eval("CycDamageId") %>'>
                        <td>
                            <input type="checkbox" id="<%# Eval("CycDamageId") %>1" onclick='selectRow("<%#Eval("CycDamageId")%>    ")' /></td>
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

