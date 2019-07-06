<%@ Page Title="" Language="C#" MasterPageFile="~/Master/InformationMaster.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Home_Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入支付页面CSS文件 --%>
    <link href="../CSS/PaymentSite.css" rel="stylesheet" />
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
    <div id="inputAccPaw">
        <ul>
            <li>
                <label>账户号:</label>
            </li>
            <li>
                <asp:TextBox ID="TextBox1" CssClass="inputFrame" runat="server"></asp:TextBox>
            </li>
            <li id="pawRow">
                <label>支付密码:</label>                
                <label id="forgetPaw"><a href="PhoneMode.aspx">忘记密码?</a></label>
            </li>
            <li>
                <asp:TextBox ID="TextBox2" TextMode="Password" CssClass="inputFrame" runat="server"></asp:TextBox>
            </li>
            <li>
                <label>验证码:</label>
            </li>
            <li>
                <asp:TextBox ID="TextBox3" CssClass="testCode" runat="server"></asp:TextBox>
                <input type="button" runat="server" onserverclick="Button1_Click" class="GetTestCode" id="codeBut" value="获取验证码" />
            </li>
            <li>
                <input type="button" runat="server" onserverclick="Unnamed_ServerClick" class="butCon" value="确认支付" />
            </li>
        </ul>
    </div>



</asp:Content>

