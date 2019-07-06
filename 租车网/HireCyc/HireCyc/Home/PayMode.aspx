<%@ Page Title="" Language="C#" MasterPageFile="~/Master/InformationMaster.master" AutoEventWireup="true" CodeFile="PayMode.aspx.cs" Inherits="Home_PayMode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入支付方式CSS文件 --%>
    <link href="../CSS/PayModeSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <%-- logo --%>
        <img src="../Images/other/CycLogo.png" id="CycLogo" />

        <%-- 预定步骤 --%>
        <div id="reparSept">
            <span id="septOne">1 提交订单</span>
            <span id="septSecond">2 选择支付方式</span>
            <span id="septThird">3 预定成功</span>
        </div>
    </div>

    <div id="showOrderCon">
        <table>
            <thead>
                <tr>
                    <th>车辆类型</th>
                    <th>租用辆数</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th><%= Session["cycTypeName"] %></th>
                    <th><%= Session["Cycnum"] %></th>
                </tr>
            </tbody>
        </table>
        <div id="showTatal">
            <label>订金</label><br />
            <label>¥<%= Session["money"] %></label>
        </div>
    </div>

    <label id="payMode">选择支付方式</label>

    <ul id="selectPayMode">
        <li class="title">第三方账户支付</li>
        <li>
            <input type="radio" runat="server" checked="true" name="paymode" id="pay1" />
            <label>
                <img src="../Images/other/pay1.jpg" /></label>
        </li>

        <li class="title">银行网银支付</li>
        <li>
            <input type="radio" runat="server" name="paymode" id="bank1" />
            <label>
                <img src="../Images/other/bank1.jpg" />
            </label>
            <input type="radio" runat="server" name="paymode" id="bank2" />
            <label>
                <img src="../Images/other/bank2.jpg" />
            </label>
            <input type="radio" runat="server" name="paymode" id="bank3" />
            <label>
                <img src="../Images/other/bank3.jpg" />
            </label>

            <input type="radio" runat="server" name="paymode" id="bank4" />
            <label>
                <img src="../Images/other/bank4.jpg" />
            </label>
        </li>


        <li class="title">取车交易</li>
        <li>
            <input type="radio" runat="server" name="paymode" id="money" />
            <label for="money">现金支付</label>
        </li>
    </ul>

    <input type="button" class="butCon" runat="server" onserverclick="Unnamed_ServerClick" value="立即支付" />

</asp:Content>

