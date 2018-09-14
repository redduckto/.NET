<%@ Page Title="Pdf Görüntüleyici" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="PdfViewPage.aspx.cs" Inherits="AspDotNet_Tutorials_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <embed src="<%= pdfUrl %>" class="PdfViewer" />

    <div id="CommentSection">
        <UserControl:CommentViewer runat="server" ID="CommentViewer" />
    </div>

</asp:Content>

