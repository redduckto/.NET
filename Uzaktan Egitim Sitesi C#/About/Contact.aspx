<%@ Page Title="Contact" Language="C#" MasterPageFile="~/MasterPages/Frontend.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="About_Contact" %>

<%-- Please email to me@mywebsite.com for copyright. --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UserControl:ContactControl runat="server" ID="ContactControl" />
</asp:Content>

