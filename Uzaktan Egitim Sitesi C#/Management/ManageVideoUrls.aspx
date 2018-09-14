<%@ Page Title="Manage Video Urls" Language="C#" MasterPageFile="~/MasterPages/Management.master" AutoEventWireup="true" CodeFile="ManageVideoUrls.aspx.cs" Inherits="Management_ManageVideoUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DropDownList ID="DropDownList1" ToolTip="Düzenlemek istediğiniz Ana Başlığı seçiniz." runat="server" AutoPostBack="True" DataSourceID="EntityDataSource1" DataTextField="Baslik" DataValueField="Id">
    </asp:DropDownList>

    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=MyWebSiteDatabaseEntities" DefaultContainerName="MyWebSiteDatabaseEntities" EnableFlattening="False" EntitySetName="AnaBasliklars" Select="it.[Id], it.[Baslik]">
    </asp:EntityDataSource>

    <br />
    <!-- GridView'da Update yaparken, DetaisView'ın "requiredFieldValidator"ünün validation algılamaması için
        "ValidationGroup"ları "One" ve "Two" olarak ayrıldı. -->
    <!-- GridView'da Videolar'ın "Id" ve "AnaBaslikId" özelliklerinin edit'lenmemesi için
        "EditItemTemplate"leri silindi. -->
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Previous" NextPageText="Next" LastPageText="Last" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="Id">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="AnaBaslikId" SortExpression="AnaBaslikId">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("AnaBaslikId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VideoLink" SortExpression="VideoLink">
                <EditItemTemplate>
                    <asp:TextBox ValidationGroup="Two" CausesValidation="false" ID="TextBox2" runat="server" Text='<%# Bind("VideoLink") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("VideoLink") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VideoBasliği" SortExpression="VideoBasliği">
                <EditItemTemplate>
                    <asp:TextBox ValidationGroup="Two" CausesValidation="false" ID="TextBox3" runat="server" Text='<%# Bind("VideoBasliği") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("VideoBasliği") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <!-- "InsertParameters"ta, "AnaBaslikID" değeri, "ControlParameter" ile sayfadaki DropDownList'in "SelectedValue"su 
                olarak ayarlandı. Böylece seçili kategoriye ekleme yapılacak. Elle Ana Başlığın ID'sinin girilmesine gerek olmayacak. -->
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyWebSiteDatabase %>" DeleteCommand="DELETE FROM [VideoUrls] WHERE [Id] = @Id" InsertCommand="INSERT INTO [VideoUrls] ([AnaBaslikId], [VideoLink], [VideoBasliği]) VALUES (@AnaBaslikId, @VideoLink, @VideoBasliği)" SelectCommand="SELECT * FROM [VideoUrls] WHERE ([AnaBaslikId] = @AnaBaslikId)" UpdateCommand="UPDATE [VideoUrls] SET [VideoLink] = @VideoLink, [VideoBasliği] = @VideoBasliği WHERE [Id] = @Id">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:ControlParameter Name="AnaBaslikId" ControlID="DropDownList1" Type="Int32" PropertyName="SelectedValue" />
            <asp:Parameter Name="VideoLink" Type="String" />
            <asp:Parameter Name="VideoBasliği" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="AnaBaslikId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="VideoLink" Type="String" />
            <asp:Parameter Name="VideoBasliği" Type="String" />
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <br />

    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:TemplateField HeaderText="VideoLink" SortExpression="VideoLink">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VideoLink") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="videoLinkTextBox" ValidationGroup="One" runat="server" Text='<%# Bind("VideoLink") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="One" ID="RequiredFieldValidator1" runat="server" ControlToValidate="videoLinkTextBox" ErrorMessage="VideoLink alanı boş bırakılamaz." Display="Dynamic" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("VideoLink") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="VideoBasliği" SortExpression="VideoBasliği">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("VideoBasliği") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ValidationGroup="One" ID="videoBasliğiTextBox" runat="server" Text='<%# Bind("VideoBasliği") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="One" ID="RequiredFieldValidator2" runat="server" ControlToValidate="videoBasliğiTextBox" ErrorMessage="VideoBasliği alanı boş bırakılamaz." Display="Dynamic" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("VideoBasliği") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>

