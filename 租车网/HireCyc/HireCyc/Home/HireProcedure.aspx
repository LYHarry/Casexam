<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HomePageMaster.master" AutoEventWireup="true" CodeFile="HireProcedure.aspx.cs" Inherits="Home_HireProcedure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入公用CSS文件 --%>
    <link href="../CSS/commonSite.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="ContentP">
        <p class="titleCen">自行车租用、还车流程</p>
        <hr class="hrStyle" />
        <p>
            本流程在杭州公共自行车各租用服务点智能系统故障及应急情况下启用。
        </p>
        <p>
            一、租车 
        </p>
        <p>
            1、租车者应认真填写《杭州公共自行车应急租车凭证》（一式三联）（包括租车人
            真实姓名、有效证件号、自行车编号、租车地点、租车时间、填表人姓名等），请认真
            阅读《杭州公共自行车服务公约》，交服务人员后，服务人员请租车者出示身份证等相关
            有效证件，进行核对。 
        </p>
        <p>
            2、核对无误后，收取租车者300元现金作为租车信用保证金。
        </p>
        <p>
            3、由工作人员取出凭证对应车号的自行车，与租车者一起查验车况，包括车身、车架、刹车
            等部件安全性能，并确认车况完好。 
        </p>
        <p>
            4、查验完毕后，租车者应在租车凭证上签字确认，并将顾客联交给租车者，并告其妥善
            保管，并作为还车凭证。 
        </p>
        <p>
            5、服务人员应告知租车者，本服务点名称、营业时间，提供必要的服务须知和资料。
        </p>
        <p>
            二、还车 
        </p>
        <p>
            按照“通租通还”的方式，租车者可在任一有服务人员值守的租用服务点归还车辆。
        </p>
        <p>
            1、租车者凭《杭州公共自行车应急租车凭证》顾客联，归还车辆。 
        </p>
        <p>
            2、办理还车手续前，服务人员应收缴《杭州公共自行车应急租车凭证》顾客联，对其
            身份进行认真核对，检查所归还自行车是否损坏，当无误时，在租车凭证上填写还车时间，
            计算超时资费。 
        </p>
        <p>
            3、收取超时资费，出具与超时费相等额的租车费专用发票，退还信用保证金。 
        </p>
        <p class="bottomDistance">
            4、租车者如将租车凭证遗失，应凭本人身份证，经核对无误后，办理还车结算手续。
        </p>
    </div>
</asp:Content>

