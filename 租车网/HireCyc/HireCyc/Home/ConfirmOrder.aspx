<%@ Page Title="" Language="C#" MasterPageFile="~/Master/InformationMaster.master" AutoEventWireup="true" CodeFile="ConfirmOrder.aspx.cs" Inherits="Home_ConfirmOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入提交订单CSS文件 --%>
    <link href="../CSS/ConfirmOrderSite.css" rel="stylesheet" />
    <%-- 导入文本框水印js文件 --%>
    <script src="../jQuery/WaterMarkjs.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager EnableScriptGlobalization="true" ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>

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
    <div id="showOrder">
        <span>
            <img src="<%= Session["cycPath"].ToString() %>" /></span>

        <table>
            <tr>
                <td>自行车类型</td>
                <td><%= cycTypeName %></td>
            </tr>
            <tr>
                <td>租金（小时）</td>
                <td>¥<%= ct.CycTypeLagHrMoney %></td>
            </tr>
            <tr>
                <td>租金（天）</td>
                <td>¥<%= ct.CycTypeLagDayMoney %></td>
            </tr>
            <tr>
                <td>迟还押金（小时）</td>
                <td>¥<%= ct.CycTypeLateHrMoney %></td>
            </tr>
            <tr>
                <td>迟还押金（天）</td>
                <td>¥<%= ct.CycTypeLateDayMoney %></td>
            </tr>
            <tr>
                <td>押金</td>
                <td>¥<%= ct.CycTypeHire %></td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%-- 租用辆数 --%>
                <div id="numInputArea">
                    <input runat="server" onserverclick="minus_ServerClick" type="button" title="减少租车数辆" id="minus" value="-" />
                    <input runat="server" type="text" id="textNum" class="numInput" value="1" />
                    <input runat="server" onserverclick="plus_ServerClick" type="button" title="增加租车数辆" id="plus" value="+" />
                    <span>
                        <label>库存</label>
                        <b>(</b>
                        <label runat="server" id="stock"><%= ct.CycTypeStock %></label>
                        <b>)</b>
                    </span>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <div id="listCom">
        <ul>
            <li>
                <label>取车时间:</label>
                <asp:TextBox ID="TextBox3" CssClass="inputFrame" Text="请选择" runat="server"></asp:TextBox>
                <select runat="server" id="hour1" class="hour">
                    <option>请选择</option>
                </select>

                <label>时</label>
                <select runat="server" id="minute1" class="minute">
                    <option>请选择</option>
                </select>

                <label>分</label>
                <asp:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server"
                    TargetControlID="TextBox3">
                </asp:CalendarExtender>
            </li>
            <li>
                <label>还车时间:</label>
                <asp:TextBox ID="TextBox4" CssClass="inputFrame" runat="server" Text="请选择"></asp:TextBox>
                <select runat="server" id="hour2" class="hour">
                    <option>请选择</option>
                </select>
                <label>时</label>
                <asp:DropDownList ID="minute2" runat="server"
                    CssClass="minute" AutoPostBack="true" OnSelectedIndexChanged="minute2_SelectedIndexChanged">
                    <asp:ListItem>请选择</asp:ListItem>
                </asp:DropDownList>
                <label>分</label>
                <asp:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" runat="server"
                    TargetControlID="TextBox4">
                </asp:CalendarExtender>
            </li>
            <li>
                <asp:TextBox ID="TextBox1" Text="有事您说话"
                    onblur="WMOnBlur(this,'有事您说话');" onfocus="WMOnfocus(this,'有事您说话');"
                    runat="server" CssClass="inputFrame writeInputFrame" />
            </li>
            <li id="money">
                <label>应付金额:</label>
                <div class="moneyFont">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <label runat="server" id="moneyFont">0.00</label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="minus" EventName="ServerClick" />
                            <asp:AsyncPostBackTrigger ControlID="minute2"  EventName="SelectedIndexChanged"/>
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </li>
        </ul>
    </div>

    <input type="button" runat="server" onserverclick="Unnamed_ServerClick" class="butCon" value="提交订单" />
</asp:Content>

