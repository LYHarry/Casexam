<%@ Page Title="" Language="C#" MasterPageFile="~/MusicMaster.master" AutoEventWireup="true"
    CodeFile="index.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div>
        <div class="songlist">
            <h4>
                <a href="#">最新歌曲</a></h4>
            <div>
                <asp:Repeater ID="rp_NewSongs" runat="server">
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
        <div class="songlist">
            <h4>
                <a href="#">热门歌曲</a></h4>
            <div class="list">
                <asp:Repeater ID="rp_HotSongs" runat="server">
                    <HeaderTemplate>
                        <table>
                            <tr>
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
                        <tr>
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
                                <%# ((DateTime)Eval("UploadTime")).ToShortDateString()%>
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
    </div>
</asp:Content>
