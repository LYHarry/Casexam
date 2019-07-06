<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MyCenterSetMaster.master" AutoEventWireup="true" CodeFile="ConsumeRecord.aspx.cs" Inherits="MyCenter_ConsumeRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入消费记录CSS文件 --%>
    <link href="../CSS/ConsumeRecordSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="topCon">
        
        <label>近期实际消费金额:</label>¥<%= sumMoney.ToString("f2") %><label></label>
        <a href="MyGrade.aspx">查看您的会员级别</a>
    </div>
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
                    <a href="OrderAppraise.aspx?id="+<%# Eval("CycBorrowId") %>+"&count="+<%# Eval("CycBorrowCount") %>+"&time="+<%# Eval("CycBorrowSetTime") %>+"" >
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



    <div id="fotCon">
        <p>特别说明</p>
        <p>交易记录中不包括使用优惠券、礼品卡、手机红包支付或退款至礼品卡、优惠券、手机红包的金额。</p>
        <p>系统仅显示您两年之内的余额明细，更早的余额明细不再显示。</p>
    </div>


</asp:Content>

