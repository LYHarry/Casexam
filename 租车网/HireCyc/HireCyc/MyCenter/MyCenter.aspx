<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MyCenterMaster.master" AutoEventWireup="true" CodeFile="MyCenter.aspx.cs" Inherits="MyCenter_MyCenter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入我的中心CSS文件 --%>
    <link href="../CSS/ConsumeRecordSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="middleCon">
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>订单表编号</th>
                        <th>租用车辆数</th>
                        <th>订单状态</th>
                        <th>实际总计租金</th>
                        <th>订单创建的时间</th>
                    </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <a href="OrderAppraise.aspx?id=<%# Eval("CycBorrowId") %>&&count=<%# Eval("CycBorrowCount") %>&&time=<%# Eval("CycBorrowSetTime") %>">
                        <tr>
                            <td><%# Eval("CycBorrowId") %></td>
                            <td><%# Eval("CycBorrowCount") %></td>
                            <td><%# Eval("CycBorrowStatus") %></td>
                            <td><%# Eval("CycBorrowRealMoney") %></td>
                            <td><%# Eval("CycBorrowSetTime") %></td>
                        </tr>
                    </a>
                </ItemTemplate>
            </asp:Repeater>           
        </table>

        <div id="butSty">
            <input type="button" value="首页" class="butInput" />
            <input type="button" value="上一页" class="butInput" />
            <a href="#">显示页数</a>
            <input type="button" value="下一页" class="butInput" />
            <input type="button" value="末页" class="butInput" />
        </div>
    </div>

</asp:Content>

