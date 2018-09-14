<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Banner.ascx.cs" Inherits="Controls_Banner" %>
<asp:Panel ID="verticalPanel" runat="server" >
    <a href="http://bilmuh.ege.edu.tr" target="_blank" runat="server" id="verticalLink">
        <asp:Image ID="Image1" runat="server" AlternateText="This is a sample banner." ImageUrl="~/Images/EULogo.png" CssClass="Banner" />
    </a>
</asp:Panel>
