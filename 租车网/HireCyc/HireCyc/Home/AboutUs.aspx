<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HomePageMaster.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Home_AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入关于我们CSS文件 --%>
    <link href="../CSS/AboutUsSite.css" rel="stylesheet" />
    <%-- 调用百度地图接口 --%>
    <script type="text/javascript" src="http://api.map.baidu.com/api?key=&v=1.1&services=true"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="ContentP">
        <p>
            常州华邦自行车智能控制系统有限公司是专业设计、生产、安装公共自行车成套设备和
           系统的外商独资企业，公司位于常州国家高新技术开发区机电工业园区。通过几年来的
           探索和发展，尤其是通过与国内院校科研机构的产、学、研合作，不仅研发了具有国内
           技术领先的公共自行车智能控制系统及成套设备并获得三项国家专利，实现了公共自行车
           租赁项目在运行、管理中的智能控制和管理。同时培育了一支具有较高素质的研发、生产
           和安装团队。为更好地适应不同城市、不同区域以及政府、市民的不同需求奠定了良好的基础。
        </p>
        <p>
            常州龙人公共自行车科技有限公司于2008年中国北京奥运会,代表常州市人民政府向北京奥组委
          捐赠800辆公共自行车.
        </p>
        <p>
            公司先后在北京、上海、武汉、常州、南京、大连等城市投入和运营的公共自行车租赁项目，
          受到了各级政府的高度重视，社会各界的高度关注，广大受益市民的高度认可。尤其是在
          武汉地区投运的公共自行车免费租赁项目，中央领导作了重要批示:“这条消息真让人高兴!
          科学管理、方便群众，为市民多办实事，武汉地区要表扬!”
        </p>
        <p>
            公司本着“以人为本、以民为先”的理念和“绿色出行、配套公交、造福百姓”的宗旨，
           配合国内外大中城市加快推进城市公共自行车租赁项目，实施“绿色慢行公交”工程作出
           积极的贡献!
        </p>
        <p>
            热忱欢迎有意向开发城市公共自行车租赁项目的政府、单位以及社会各界的投资者前来洽谈，
          包括成套工程项目、设备采购项目等等。我公司将以真诚、热情、周到的服务成为您值得
          信赖的合作伙伴。
        </p>
        <%-- 联系方式 --%>
        <table>
            <tr>
                <td class="tdWidth">公司名称</td>
                <td>永安公共自行车系统股份有限公司</td>
            </tr>
            <tr>
                <td>联 系 人</td>
                <td>冯彬/刘逸浩/万琳琳</td>
            </tr>
            <tr>
                <td>联系电话</td>
                <td>18227101677/18227100351/18227101697</td>
            </tr>
            <tr>
                <td>招聘热线</td>
                <td>18227101650</td>
            </tr>
            <tr>
                <td>公司网址</td>
                <td>www.baidu.com </td>
            </tr>
            <tr>
                <td>公司地址</td>
                <td>四川工程职业技术学院6舍328</td>
            </tr>
            <tr>
                <td>邮&nbsp;&nbsp;&nbsp;&nbsp;编</td>
                <td>618000</td>
            </tr>
        </table>

        <p>公交:1路、28路、5路</p>

        <%-- 显示地图 --%>
        <div class="MapContainer" id="MapContent"></div>

    </div>

    <%-- 导入显示地图的javascript文件 --%>
    <script src="../jQuery/MapjavaScript.js"></script>

</asp:Content>

