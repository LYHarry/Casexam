<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MyCenterSetMaster.master" AutoEventWireup="true" CodeFile="PersonData.aspx.cs" Inherits="MyCenter_PersonData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%-- 账户信息——个人信息CSS文件 --%>
    <link href="../CSS/PersonDataSite.css" rel="stylesheet" />
    <%-- 导入jQuery管理文件 --%>
    <script src="../jQuery/jquery-2.1.1.js"></script>
    <%-- 导入jQuery选项卡管理文件 --%>
    <script src="../jQuery/jquery.idTabs.min.js"></script>
    <%-- 导入更改天数javascript文件 --%>
    <script src="../jQuery/YMDListjavaScript.js"></script>
    <%-- 导入我国诚市列表jQuery文件 --%>
    <script src="../jQuery/city.min.js"></script>
    <%-- 导入选择诚市联动jQuery文件 --%>
    <script src="../jQuery/jquery.cityselect.js"></script>
    <%-- 导入文本框水印js文件 --%>
    <script src="../jQuery/WaterMarkjs.js"></script>
    <%-- 导入个人信息js文件 --%>
    <script src="../jQuery/UploadImgjs.js"></script>
    <%-- 导入上传图片js文件 --%>
    <script src="../jQuery/ajaxupload.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%-- 个人信息分类 --%>
    <div id="setMessage">
        <ul>
            <li>
                <a href="#tab1">基本信息</a>
            </li>
            <li>
                <a href="#tab2">头像照片</a>
            </li>
            <li>
                <a href="#tab3">更多个人信息</a>
            </li>
        </ul>
    </div>

    <%-- 主要内容 --%>
    <div id="content">

        <%-- 基本情况 --%>
        <div id="tab1">
            <ul>
                <li>
                    <label><b>*</b>姓&nbsp;&nbsp;&nbsp;&nbsp;名</label>
                    <asp:TextBox ID="TextBox9" CssClass="inputFrame" runat="server" />
                </li>
                <li>
                    <label><b>*</b>性&nbsp;&nbsp;&nbsp;&nbsp;别</label>
                    <asp:RadioButton ID="male" Checked="true" GroupName="sex" runat="server" />
                    <label>男</label>
                    <asp:RadioButton ID="female" GroupName="sex" runat="server" />
                    <label>女</label>
                </li>
                <li>
                    <label>昵&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;称</label>
                    <asp:TextBox ID="TextBox3" CssClass="inputFrame" runat="server" />
                </li>
                <li>
                    <label><b>*</b>电话号码</label>
                    <asp:TextBox ID="TextBox10" MaxLength="11" CssClass="inputFrame" runat="server" />
                </li>
                <li>
                    <label><b>*</b>身份证号</label>
                    <asp:TextBox ID="TextBox2" MaxLength="18" CssClass="inputFrame" runat="server" />
                </li>
                <li>
                    <label><b>*</b>电子邮箱&nbsp;</label>
                    <asp:TextBox ID="TextBox4" TextMode="Email" CssClass="inputFrame" runat="server" />
                </li>
                <li id="citySelectFrame">
                    <label id="cityFont"><b>*</b>所 在 地</label>
                    <div id="citySelect">
                        <select id="prov" onchange="GetProv(this)" class="dropList">
                        </select>
                        <select id="city" onchange="GetCity(this)" class="dropList">
                            <option>请选择</option>
                        </select>
                        <select id="dist" onchange="GetDist(this)" class="dropList">
                            <option>请选择</option>
                        </select>
                    </div>
                    <input type="hidden" id="GetAdd" name="GetAdd" />
                </li>
                <li>
                    <asp:TextBox ID="TextBox1" Text="详细地址"
                        onblur="WMOnBlur(this,'详细地址');" onfocus="WMOnfocus(this,'详细地址');"
                        CssClass="addressInput" runat="server" />
                </li>
            </ul>
            <asp:Button ID="Button2" OnClick="Button2_Click" CssClass="but" runat="server" Text="提交" />
        </div>

        <%--   个人头像 --%>
        <div id="tab2">
            <span class="span" id="uploadBut">
                <img src="../Images/other/uploadIco.png" />
                <label>选择您要上传的头像</label>
            </span>
            <%-- 显示上传图片 --%>
            <div id="showImgArea">
                <img src="#" id="perImg" />
            </div>

            <label class="font">推荐头像</label>
            <div id="examImg">
                <ul>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/1.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/2.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/3.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/4.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/5.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/6.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/7.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/8.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/9.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/10.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/11.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/12.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/13.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/14.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/15.jpg" /></a> </li>
                    <li>
                        <a>
                            <img src="http://i.jd.com/defaultImgs/16.jpg" /></a> </li>
                </ul>
            </div>
            <div id="rightSample">
                <ul>
                    <li class="font">效果预览</li>
                    <li>你上传的图片会自动生成2种尺寸，请注意小尺寸的头像是否清晰</li>
                    <li>
                        <div id="SampleHun">
                            <img src="#" id="SampHun" />
                        </div>
                        <label>100*100像素</label>
                    </li>
                    <li>
                        <div id="SampleFif">
                            <img src="#" id="SampFif" />
                        </div>
                        <label>50*50像素</label>
                    </li>
                </ul>
            </div>
            <asp:Button ID="Button1" CssClass="but" runat="server" Text="保存" />
        </div>

        <%-- 更多个人信息 --%>
        <div id="tab3">
            <ul>
                <li>
                    <label>出生年月</label>
                    <select id="YYYY" class="dropList" onchange="YYYYMM(this.value)">
                        <option value="">年</option>
                    </select>
                    <select id="MM" class="dropList" onchange="MMDD(this.value)">
                        <option value="">月</option>
                    </select>
                    <select id="DD" class="dropList">
                        <option value="">日</option>
                    </select>
                </li>
                <li>
                    <label>教育程度</label>
                    <asp:DropDownList ID="DropDownList12" CssClass="dropList" runat="server">
                        <asp:ListItem>大专</asp:ListItem>
                        <asp:ListItem>本科</asp:ListItem>
                        <asp:ListItem>研究生</asp:ListItem>
                        <asp:ListItem>博士</asp:ListItem>
                        <asp:ListItem>其他</asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li>
                    <label>所在行业</label>
                    <asp:DropDownList ID="DropDownList13" CssClass="dropList" runat="server">
                        <asp:ListItem>计算机</asp:ListItem>
                        <asp:ListItem>教育</asp:ListItem>
                        <asp:ListItem>科学</asp:ListItem>
                        <asp:ListItem>其他</asp:ListItem>
                    </asp:DropDownList>
                </li>
            </ul>
            <asp:Button ID="Button3" OnClick="Button3_Click" CssClass="but" runat="server" Text="保存" />
        </div>
    </div>

    <%-- 调用选项卡方法 --%>
    <script type="text/javascript">
        jQuery("#setMessage ul").idTabs();
    </script>



</asp:Content>

