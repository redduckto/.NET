<%@ Page Title="Video Görüntüleyici" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="VideoViewPage.aspx.cs" Inherits="VideoViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <iframe id="VideoWindow" src='<%= videoUrl %>' frameborder="0" allowfullscreen="true"></iframe>

    <div id="CommentSection">
        <UserControl:CommentViewer runat="server" ID="CommentViewer" />
    </div>

</asp:Content>

