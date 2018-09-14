<%@ Page Title="Manage Roles" Language="C#" MasterPageFile="~/MasterPages/Management.master" AutoEventWireup="true" CodeFile="ManageRoles.aspx.cs" Inherits="Management_ManageRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- "RoleId"nin "DataKeyName" olarak kullanılabilmesi için gridView'a "BoundField" olarak eklenmesi gerekiyor.
                Ama "Visible" özelliği "false" yapılarak tabloda saklanabiliyor.
                "Delete" işlemi sırasında bu "RoleId" sahası kullanılıyor SQLDataSource'un "DeleteCommand"inde yazıldığı gibi. -->
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="RoleId" AllowPaging="True">
        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Previous" NextPageText="Next" LastPageText="Last" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="RoleName" HeaderText="RoleName" SortExpression="RoleName" />
            <asp:BoundField DataField="LoweredRoleName" HeaderText="LoweredRoleName" SortExpression="LoweredRoleName" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="RoleId" HeaderText="RoleId" SortExpression="RoleId" Visible="false" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" SortExpression="ApplicationId" InsertVisible="False" ReadOnly="True" />
            <asp:TemplateField HeaderText="RoleName" SortExpression="RoleName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("RoleName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="roleNameTextBox" runat="server" Text='<%# Bind("RoleName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="roleNameTextBox" ErrorMessage="RoleName alanı boş bırakılamaz." Display="Dynamic" CssClass="ErrorMessage" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("RoleName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LoweredRoleName" SortExpression="LoweredRoleName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("LoweredRoleName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="loweredRoleNameTextBox" runat="server" Text='<%# Bind("LoweredRoleName") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="loweredRoleNameTextBox" ErrorMessage="LoweredRoleName alanı boş bırakılamaz." Display="Dynamic" CssClass="ErrorMessage" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("LoweredRoleName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <!-- "InsertParamaters"da "ApplicationId" sabit olduğundan DefaultValue'su belirtilip, insert sırasında
                gizleniyor. -->
    <!-- Insert işleminde, "RoleId" otomatik olarak oluşturulduğu için "InsertCommand" ve "InsertParameters" arasında
                "RoleId" yazılmıyor. -->
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AspDotNetDB %>" DeleteCommand="DELETE FROM [aspnet_Roles] WHERE @RoleId = [RoleId] " InsertCommand="INSERT INTO aspnet_Roles(ApplicationId, RoleName, LoweredRoleName, Description) VALUES (@ApplicationId, @RoleName, @LoweredRoleName, @Description)" SelectCommand="SELECT RoleName, LoweredRoleName, Description, RoleId FROM aspnet_Roles">
        <DeleteParameters>
            <asp:Parameter Name="RoleId" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="ApplicationId" DefaultValue="a486a7f1-0002-4800-9bd4-1f77c34eadf9" />
            <asp:Parameter Name="RoleName" />
            <asp:Parameter Name="LoweredRoleName" />
            <asp:Parameter Name="Description" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

