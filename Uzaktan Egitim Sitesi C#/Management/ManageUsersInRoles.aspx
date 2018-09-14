<%@ Page Title="Manage Users In Roles" Language="C#" MasterPageFile="~/MasterPages/Management.master" AutoEventWireup="true" CodeFile="ManageUsersInRoles.aspx.cs" Inherits="Management_ManageUsersInRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="RoleId,UserId" AllowPaging="True">
        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Previous" NextPageText="Next" LastPageText="Last" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="RoleId" HeaderText="RoleId" SortExpression="RoleId" Visible="false" />
            <asp:BoundField DataField="RoleName" HeaderText="RoleName" SortExpression="RoleName" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" Visible="false" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
        </Columns>
    </asp:GridView>

    <br />
    <br />

    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="125px">
        <Fields>
            <asp:TemplateField HeaderText="RoleName" SortExpression="RoleName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("RoleName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:DropDownList ID="roleNameDropDownList" runat="server" DataSourceID="RolesDataSource" DataTextField="RoleName" DataValueField="RoleName" SelectedValue='<%# Bind("RoleName") %>'></asp:DropDownList>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UserName" SortExpression="UserName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="userNameTextBox" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="userNameTextBox" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Kullanıcı Adı boş bırakılamaz."></asp:RequiredFieldValidator>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AspDotNetDB %>" InsertCommand="INSERT INTO aspnet_UsersInRoles(UserId, RoleId) SELECT aspnet_Users.UserId, aspnet_Roles.RoleId FROM aspnet_Users CROSS JOIN aspnet_Roles WHERE (aspnet_Users.UserName = @UserName) AND (aspnet_Roles.RoleName = @RoleName)" SelectCommand="SELECT aspnet_Roles.RoleId, aspnet_Roles.RoleName, aspnet_Users.UserId, aspnet_Users.UserName FROM aspnet_Roles INNER JOIN aspnet_UsersInRoles ON aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId INNER JOIN aspnet_Users ON aspnet_UsersInRoles.UserId = aspnet_Users.UserId" DeleteCommand="DELETE FROM aspnet_UsersInRoles WHERE UserId = @UserId AND RoleId = @RoleId">
        <InsertParameters>
            <asp:Parameter Name="UserName" />
            <asp:Parameter Name="RoleName" />
        </InsertParameters>
        <DeleteParameters>
            <asp:Parameter Name="RoleId" />
            <asp:Parameter Name="UserId" />
        </DeleteParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="RolesDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:AspDotNetDB %>" SelectCommand="SELECT [RoleId], [RoleName] FROM [vw_aspnet_Roles]"></asp:SqlDataSource>
</asp:Content>

