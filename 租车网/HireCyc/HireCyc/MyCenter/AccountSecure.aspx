<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MyCenterSetMaster.master" AutoEventWireup="true" CodeFile="AccountSecure.aspx.cs" Inherits="MyCenter_AccountSecure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 导入账户安全CSS文件 --%>
    <link href="../CSS/AccountSecureSite.css" rel="stylesheet" />

  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div id="SecureContent">

        <label class="tilteFont">安全中心</label>

        <ul>
            <li class="secureSort">登录密码</li>
            <li class="hintCon">互联网账号存在被盗风险，建议您定期更改密码以保护账户安全。</li>
            <li class="alterFont"><a href="../Account/PasswordRecoverMode.aspx">修改</a></li>
        </ul>

        <ul>
            <li class="secureSort">邮箱验证</li>
            <li class="hintCon">您验证的邮箱:<label><%= uf[0].UserEmail %></label></li>
            <li class="alterFont"><a href="AlterEmail.aspx">修改</a>
        </ul>

        <ul>
            <li class="secureSort">手机验证</li>
            <li class="hintCon">您验证的手机:<label><%= uf[0].UserTel %></label></li>
            <li class="alterFont"><a href="AlterPhone.aspx">修改</a></li>
        </ul>
        <ul>
            <li class="secureSort">支付密码</li>
            <li class="hintCon">安全程度:<span id="showPasStr">显示密码强度</span>
                <label>建议您设置更高强度的密码。</label>
            </li>
            <li class="alterFont"><a href="../Home/PhoneMode.aspx">修改</a></li>
        </ul>

        <div id="secureServerHint">
            <p class="tilteFont">安全服务提示</p>
            <p>
                1.确认您登录的是京东网址http://www.baidu.com，注意防范进入钓鱼网站，不要轻信
    各种即时通讯工具发送的商品或支付链接，谨防网购诈骗。
            </p>
            <p>2.建议您安装杀毒软件，并定期更新操作系统等软件补丁，确保账户及交易安全。</p>
        </div>
    </div>




</asp:Content>

