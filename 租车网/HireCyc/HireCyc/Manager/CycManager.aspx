<%@ Page Title="" Language="C#" MasterPageFile="~/Master/ManagerMaster.master" AutoEventWireup="true" CodeFile="CycManager.aspx.cs" Inherits="Manager_CycManager" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

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
            <input type="button" class="but" onclick="DelData('cyc')" id="del" value="删除" />
            <input type="button" class="but" runat="server" onserverclick="select_ServerClick" id="select" value="查询" />
            <input type="button" class="but" id="alter" value="修改" />
            <input type="button" class="but" runat="server" onserverclick="create_ServerClick" id="create" value="添加" />
        </div>

        <asp:GridView ID="GridView1" CssClass="GridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="车辆名称" HeaderText="车辆名称" SortExpression="车辆名称" />
                <asp:BoundField DataField="车辆类型" HeaderText="车辆类型" SortExpression="车辆类型" />
                <asp:BoundField DataField="租用次数" HeaderText="租用次数" SortExpression="租用次数" />
                <asp:BoundField DataField="购车时间" HeaderText="购车时间" SortExpression="购车时间" />
                <asp:BoundField DataField="修理次数" HeaderText="修理次数" SortExpression="修理次数" />
                <asp:BoundField DataField="购买价格" HeaderText="购买价格" SortExpression="购买价格" />
            </Columns>
        </asp:GridView>

        <webdiyer:AspNetPager ID="AspNetPager2" runat="server"
            FirstPageText="首页" LastPageText="尾页"
            NextPageText="下一页" PageSize="10"
            PrevPageText="上一页" OnPageChanged="AspNetPager2_PageChanged"
            ShowPageIndexBox="Auto"
            CssClass="paginator" CurrentPageButtonClass="cpb" AlwaysShow="True"
            CustomInfoSectionWidth="" PageIndexBoxType="DropDownList" UrlPaging="True" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>

    </div>

</asp:Content>

