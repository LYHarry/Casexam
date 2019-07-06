<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HomePageMaster.master" AutoEventWireup="true" CodeFile="QuestionList.aspx.cs" Inherits="Home_QuestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入常见问题集合CSS文件 --%>
    <link href="../CSS/QuestionListSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div id="wareCon">
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <th>车辆类型</th>
                        <th>租金（小时）</th>
                        <th>租金（天）</th>
                        <th>迟还罚金（小时）</th>
                        <th>迟还罚金（天）</th>
                        <th>押金</th>
                    </tr>

                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("CycTypeName") %></td>
                        <td><%#Eval("CycTypeLagHrMoney") %></td>
                        <td><%#Eval("CycTypeLagDayMoney") %></td>
                        <td><%#Eval("CycTypeLateHrMoney") %></td>
                        <td><%#Eval("CycTypeLateDayMoney") %></td>
                        <td><%#Eval("CycTypeHire") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <div id="payModeCon">
        <span>预定车辆流程:</span><br />
        <span>选择车辆类型</span><span>-></span>
        <span>点击"预定车辆"</span><span>-></span>
        <span>填写订单信息</span><span>-></span>
        <span>提交订单</span><span>-></span>
        <span>选择支付方式</span><span>-></span>
        <span>支付订金</span><span>-></span>
        <span>预定成功</span><span>-></span>
        <span>带证件取车</span>
    </div>

    <div id="GetCycNote">
        <ul>
            <li>取车注意事项：</li>
            <li>1、必须本人取车。</li>
            <li>2、取车时需带上身份证等有效证件。</li>
            <li>3、取车时需带上押金。</li>
        </ul>
    </div>

    <div id="questionCon">
        <ul>
            <li><a href="HireProcedure.aspx">1、租凭流程</a> </li>
            <li><a href="PayForStandard.aspx">2、毁坏车辆赔偿标准</a> </li>
            <li><a href="safeTenet.aspx">3、骑车安全守则</a> </li>
            <li><a href="ServerAssumpsit.aspx">4、服务公约</a> </li>
            <li><a href="AboutUs.aspx">5、关于我们</a> </li>
        </ul>
    </div>
</asp:Content>


