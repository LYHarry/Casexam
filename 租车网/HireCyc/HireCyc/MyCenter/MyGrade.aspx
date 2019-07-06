<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MyCenterSetMaster.master" AutoEventWireup="true" CodeFile="MyGrade.aspx.cs" Inherits="MyCenter_MyGrade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入我的级别CSS文件 --%>
    <link href="../CSS/MyGradeSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="GradeContent">
        <div id="area1">
            <p>您的会员级别是：<label><%=grade %></label>（<a href="#">查看Cyc会员介绍</a>） </p>
            <p>会员级别有效期：2014.11.25 - 2015.11.25</p>
            <p>您目前的成长值为2157 ，再获得7843成长值即可升级到 金牌会员</p>
            <p>您在2015.11.25前，再获得843成长值（在银牌会员到期时）可将银牌会员延长一年</p>
            <p>获得成长值的办法:登录、购物、 评价、 晒单。 查看详情</p>
            <p><a href="#">查看我的成长值明细</a> </p>
        </div>

        <div id="area2">
            <p>银牌会员权利及优惠：</p>
            <p>1、享受自营商品（如何区分？）满59元免运费服务。具体参考配送服务收费标准；</p>
            <p>2、享受售后服务（退货、换货、维修）运费优惠（<a href="#">查看售后服务说明</a> ）；</p>
            <p>3、享受预约电话服务（<a href="#">我要预约</a> ）。</p>
            <p>4、每年生日时，可获得一份生日礼包。<a href="#">查看详情</a></p>
            <p>5、会员级别升级时，可获得一份升级礼包。<a href="#">查看详情</a></p>
        </div>

        <div id="area3">
            <p>会员级别变动记录：</p>
            <p>2014.11.25    升级为银牌会员</p>
        </div>


        <div id="area4">
            <p>会员级别图示：</p>
            <div id="showGradImg">
                <img src="../Images/other/memberGrade.png" />
                <hr id="hrStyle" />
                <table>
                    <tr>
                        <td class="tdWidth">注册会员</td>
                        <td>青铜会员</td>
                        <td>白银会员</td>
                        <td>白金会员</td>
                        <td class="tdWidth">黄金会员</td>
                    </tr>

                    <tr>
                        <td>注册即成为注册会员</td>
                        <td>成长值大于10</td>
                        <td>成长值大于200</td>
                        <td>成长值大于500</td>
                        <td>成长值大于100</td>
                    </tr>

                </table>
            </div>

        </div>
    </div>



</asp:Content>

