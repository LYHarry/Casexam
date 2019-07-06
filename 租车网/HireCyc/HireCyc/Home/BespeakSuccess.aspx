<%@ Page Title="" Language="C#" MasterPageFile="~/Master/InformationMaster.master" AutoEventWireup="true" CodeFile="BespeakSuccess.aspx.cs" Inherits="Home_BespeakSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入预约成功CSS文件 --%>
    <link href="../CSS/BespeakSuccessSite.css" rel="stylesheet" />
    <%-- 导入倒记时，跳转另一页面javascript文件 --%>
    <script src="../jQuery/TimeGoPagejavaScript.js"></script>
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

    <div id="content">
        <p>预约成功</p>
        <p>请准时取车，谢谢！</p>
        <p>取车注意事项：</p>
        <p>1、必须本人取车。</p>
        <p>2、取车时需带上身份证等有效证件。</p>
        <p>3、取车时需带上押金。</p>
        <p>
            <label id="time"></label>
            秒后回到主页<a href="QuestionList.aspx">现在就去</a>
        </p>

    </div>

</asp:Content>

