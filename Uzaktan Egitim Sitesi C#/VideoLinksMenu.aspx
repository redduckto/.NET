<%@ Page Title="Video Menusu" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="VideoLinksMenu.aspx.cs" Inherits="VideoLinksMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="İçerikListesi">
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <li>
                    <a href='<%# Eval("Id", "VideoViewPage.aspx?Video={0}") %>' id="videoLink" runat="server"><%# Eval("VideoBasliği") %></a>
                </li>
            </ItemTemplate>
        </asp:ListView>
        <br />
        <asp:LoginView runat="server">
            <AnonymousTemplate>
                <p class="UyarıText">
                    Sonraki videoları görmek için lütfen <a href="SignUp.aspx" runat="server">Üye Olun.</a>
                </p>
            </AnonymousTemplate>
        </asp:LoginView>
    </div>
</asp:Content>

