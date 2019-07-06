<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HomePageMaster.master" AutoEventWireup="true" CodeFile="PayForStandard.aspx.cs" Inherits="Home_PayForStandard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入赔偿标准CSS文件 --%>
    <link href="../CSS/ParForStandardSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="ContentP">
        <p>自行车损坏、遗失赔偿标准</p>
        <hr class="hrStyle" />
        <p>自行车部件损坏维修收费标准</p>
        <table>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <tr>
                        <td>车辆类型</td>
                        <td>部  件</td>
                        <td>收费标准</td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("CycDamageCycType") %></td>
                        <td><%#Eval("CycDamageSituation") %></td>
                        <td><%#Eval("CycDamageMoney") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>



        <p class="fontDistance">自行车整车遗失赔偿标准</p>
        <table>
            <tr>
                <td>使用年限</td>
                <td>按原价折算赔偿标准</td>
            </tr>
            <tr>
                <td>一年（含）内</td>
                <td>90％</td>
            </tr>
            <tr>
                <td>一年以上至二年（含）内</td>
                <td>80％</td>
            </tr>
            <tr>
                <td>二年以上至三年（含）内</td>
                <td>70％</td>
            </tr>
            <tr>
                <td>三年以上</td>
                <td>60％</td>
            </tr>
        </table>
        <p class="remark">注：本赔偿标准未明确的事项，由双方另行协商解决</p>
    </div>
</asp:Content>

