<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/MasterPages/Management.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Management_ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="UserId" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" />
        <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" ReadOnly="True" SortExpression="ApplicationId" />
        <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" />
        <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
        <asp:BoundField DataField="LoweredUserName" HeaderText="LoweredUserName" ReadOnly="True" SortExpression="LoweredUserName" />
        <asp:BoundField DataField="MobileAlias" HeaderText="MobileAlias" SortExpression="MobileAlias" />
        <asp:CheckBoxField DataField="IsAnonymous" HeaderText="IsAnonymous" SortExpression="IsAnonymous" />
        <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" SortExpression="LastActivityDate" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AspDotNetDB %>" DeleteCommand="DELETE FROM aspnet_Users WHERE (UserId = @UserId)" SelectCommand="SELECT * FROM [vw_aspnet_Users]">
    <DeleteParameters>
        <asp:Parameter Name="UserId" />
    </DeleteParameters>
</asp:SqlDataSource>

</asp:Content>

