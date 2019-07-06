<%@ Page Title="" Language="C#" MasterPageFile="~/MusicMaster.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="allsonglist">
        <h4>
            <a href="#">歌曲列表</a></h4>
        <div>
            <asp:Repeater ID="rp_SongsList" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr class="colheight">
                            <td>
                                歌曲名
                            </td>
                            <td>
                                歌手
                            </td>
                            <td>
                                风格
                            </td>
                            <td>
                                上传时间
                            </td>
                            <td>
                                点击次数
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="colheight">
                        <td>
                            <a href='Play.aspx?id=<%#Eval("ID")%>'>
                                <%# Eval("SongName") %></a>
                        </td>
                        <td>
                            <%# Eval("Singer") %>
                        </td>
                        <td>
                            <%# Eval("Category") %>
                        </td>
                        <td>
                            <%#((DateTime)Eval("UploadTime")) .ToShortDateString()%>
                        </td>
                        <td>
                            <%# Eval("ClickCount") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
