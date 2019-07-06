<%@ Page Title="" Language="C#" MasterPageFile="~/Master/HomePageMaster.master" AutoEventWireup="true" CodeFile="CustomerFeedback.aspx.cs" Inherits="Home_CustomerFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入客户反馈CSS文件 --%>
    <link href="../CSS/CustomerFeedbackSite.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入更换验证码图片jQuery文件 --%>
    <script src="../jQuery/ChangeIdentifyCodeImgjQuery.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="customerFeedback">
        <ul>
            <li>
                <span>
                    <label>主&nbsp;&nbsp;&nbsp;&nbsp;题:</label>
                    <input type="text" id="subject" runat="server" />
                </span>
            </li>
            <li>
                <span>
                    <label id="noMangin">内&nbsp;&nbsp;&nbsp;&nbsp;容:</label>
                    <textarea runat="server" id="CustomerFeedbackContent" title="请将意见内容输入此区域"></textarea>
                </span>
            </li>
            <li>
                <span>
                    <label>联系方式:</label>
                    <input runat="server" type="text" id="tel" />
                </span>
            </li>
            <li>
                <span>
                    <label>验 证 码:</label>
                    <input type="text" id="testCode" runat="server" />
                    <img src="../Share/IdentifyingCode.aspx" title="单击更换验证码" class="randomCodeImg" alt="验证码" />
                </span>
            </li>
            <li>
                <span>
                    <input type="button" value="提交" onserverclick="subBut_Click" runat="server"  class="subBut"  />
                    <input type="reset" runat="server" class="subBut" value="重写"  />
                </span>
            </li>
        </ul>
    </div>
</asp:Content>

