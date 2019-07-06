<%@ Page Title="" Language="C#" MasterPageFile="~/MusicMaster.master" AutoEventWireup="true"
    CodeFile="Upload.aspx.cs" Inherits="User_Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="upload">
        <h4>
            歌曲上传</h4>
        <p>
            <label>
                歌曲名称:</label><asp:TextBox ID="tb_SongName" Width="120" runat="server"></asp:TextBox></p>
        <p>
            <label>
                演唱歌手:</label><asp:TextBox ID="tb_Singer" Width="120" runat="server"></asp:TextBox></p>
        <p>
            <label>
                歌曲风格:</label><asp:TextBox ID="tb_Category" Width="120" runat="server"></asp:TextBox></p>
        <p>
            <label>
                选择文件:</label><asp:FileUpload ID="fu_Upload" runat="server" /></p>
        <p>
            <asp:Button Text="上  传" runat="server" Width="80" ID="btn_Upload" OnClick="btn_Upload_Click" /></p>
    </div>
</asp:Content>
