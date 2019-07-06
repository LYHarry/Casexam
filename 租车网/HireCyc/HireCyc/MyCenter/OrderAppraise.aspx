<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MyCenterActivityMaster.master" AutoEventWireup="true" CodeFile="OrderAppraise.aspx.cs" Inherits="MyCenter_OrderAppraise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入评价订单CSS文件 --%>
    <link href="../CSS/OrderAppraiseSite.css" rel="stylesheet" />
    <%-- 导入星星评分javascript文件 --%>
    <script src="../jQuery/StarScroejavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="wareApp">
        <label id="title">商品评价</label>

        <table id="showOrderCon">
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>车辆类型</th>
                        <td>车辆名称</td>
                        <th>租用辆数</th>
                        <th>租用时间</th>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("CycRentCycType")  %></td>
                        <td><%# Eval("CycRentCycName")   %></td>
                        <td><%= count  %></td>
                        <td><%= time  %></td>
                    </tr>
                </ItemTemplate>

            </asp:Repeater>
        </table>
        <%-- 商品评价 --%>
        <div class="scoreInput">
            <label class="fontScor">评&nbsp;&nbsp;&nbsp;&nbsp;分:</label>
            <div class="star" id="star1">
                <ul>
                    <li>☆</li>
                    <li>☆</li>
                    <li>☆</li>
                    <li>☆</li>
                    <li>☆</li>
                </ul>
                <input type="hidden" id="hid2" name="hid2" />
            </div>
        </div>
        <div class="multInput">
            <label>使用心得:</label>
            <asp:TextBox ID="TextBox1" CssClass="inputFrame" ToolTip="商品是否给力？快分享您的使用心得吧~" TextMode="MultiLine" runat="server"></asp:TextBox>
        </div>
    </div>

    <%-- 工作人员评价 --%>
    <div id="EmpServerApp">
        <label>满意度评价</label>

        <div class="scoreInput">
            <label class="fontScor">评&nbsp;&nbsp;&nbsp;&nbsp;分:</label>
            <div class="star" id="star2">
                <ul>
                    <li>☆</li>
                    <li>☆</li>
                    <li>☆</li>
                    <li>☆</li>
                    <li>☆</li>
                </ul>
                <input type="hidden" id="hid1" name="hid1" />
            </div>
        </div>
        <div class="multInput">
            <label>评价内容:</label>
            <asp:TextBox ID="TextBox2" CssClass="inputFrame" ToolTip="工作人员态度是否合理？" TextMode="MultiLine" runat="server"></asp:TextBox>
        </div>
    </div>

    <input type="button" runat="server" onserverclick="Unnamed_ServerClick" class="butCon" value="提交评价" />



    <div id="AppCont">
        <p>评价说明</p>
        <p>请您根据本次交易，给予真实、客观、仔细地评价。您的评价将是其他会员的参考，也将影响卖家的信用。</p>
        <p>
            累积信用计分规则： 中评不计分，但会影响卖家的好评率，请慎重给予。 每个自然月中，
    相同买家和卖家之间的信用评价计分不超过6分。 评价后30天内，您有一次机会删除给对方的
    中评或差评，或者修改成好评。
        </p>
        <p>
            动态店铺评分计分规则： 店铺评分是匿名的。 每个自然月中，相同买家和卖家之间的店铺评分计
    分次数不超过3次。 店铺评分成功后无法修改。
        </p>
    </div>


</asp:Content>

