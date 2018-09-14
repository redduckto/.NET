<%@ Page Title="Anasayfa" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="İçerikListesi">
        <h2 style="margin-top: 0px;">HOŞGELDİNİZ!</h2>
        <div class="AnaSayfaİçeriği">
            <h3>En son eklenen PDF'ler:</h3>
            <asp:Repeater ID="pdfRepeater" runat="server">
                <ItemTemplate>
                    <a href='<%# Eval("Id", "PdfViewPage.aspx?PDF={0}") %>' id="baslikLink" runat="server"><%# Eval("KonuBasliği") %></a>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="AnaSayfaİçeriği">
            <h3>En son eklenen videolar:</h3>
            <asp:Repeater ID="videoRepeater" runat="server">
                <ItemTemplate>
                    <a href='<%# Eval("Id", "VideoViewPage.aspx?Video={0}") %>' id="videoLink" runat="server"><%# Eval("VideoBasliği") %></a>
                    <br />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
