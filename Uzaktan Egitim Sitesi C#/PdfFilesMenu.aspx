<%@ Page Title="Pdf Dosyaları" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="PdfFilesMenu.aspx.cs" Inherits="PdfFilesMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="İçerikListesi">
        <!-- "<a href" ile, PdfViewPage.aspx'e Pdf'nin ID'si gönderiliyor. -->
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <li>
                    <a href='<%# Eval("Id", "PdfViewPage.aspx?PDF={0}") %>' id="baslikLink" runat="server"><%# Eval("KonuBasliği") %></a>
                </li>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <asp:LoginView runat="server">
            <AnonymousTemplate>
                <p style="font-size: large;">
                    Sonraki başlıkları görmek için lütfen <a href="SignUp.aspx" runat="server">Üye Olun.</a>
                </p>
            </AnonymousTemplate>
        </asp:LoginView>
    </div>
</asp:Content>

