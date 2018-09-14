<%@ Page Title="Manage PDF Files" Language="C#" MasterPageFile="~/MasterPages/Management.master" AutoEventWireup="true" CodeFile="ManagePdfFiles.aspx.cs" Inherits="Management_ManagePdfFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Panel ID="Panel1" runat="server" GroupingText="Ana Başlık Seçiniz">
        <asp:DropDownList ID="DropDownList1" ToolTip="Düzenlemek istediğiniz Ana Başlığı seçiniz." runat="server" AutoPostBack="True" DataSourceID="EntityDataSource1" DataTextField="Baslik" DataValueField="Id">
        </asp:DropDownList>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=MyWebSiteDatabaseEntities" DefaultContainerName="MyWebSiteDatabaseEntities" EnableFlattening="False" EntitySetName="AnaBasliklars" Select="it.[Id], it.[Baslik]">
        </asp:EntityDataSource>

        <br />

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting" >
            <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="First" PreviousPageText="Previous" NextPageText="Next" LastPageText="Last" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CausesValidation="false" />
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
                <asp:TemplateField HeaderText="FileUrl" SortExpression="FileUrl">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("FileUrl") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="KonuBasliği" SortExpression="KonuBasliği">
                    <EditItemTemplate>
                        <asp:TextBox CausesValidation="false" ID="TextBox1" runat="server" Text='<%# Bind("KonuBasliği") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("KonuBasliği") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <!-- "InsertParameters"ta, "AnaBaslikID" değeri, "ControlParameter" ile sayfadaki DropDownList'in "SelectedValue"su 
                olarak ayarlandı. Böylece seçili kategoriye ekleme yapılacak. Elle Ana Başlığın ID'sinin girilmesine gerek olmayacak. -->
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyWebSiteDatabase %>" DeleteCommand="DELETE FROM [PdfFiles] WHERE [Id] = @Id" InsertCommand="INSERT INTO [PdfFiles] ([AnaBaslikId], [FileUrl], [KonuBasliği]) VALUES (@AnaBaslikId, @FileUrl, @KonuBasliği)" OnInserting="SqlDataSource1_Inserting" SelectCommand="SELECT * FROM [PdfFiles] WHERE ([AnaBaslikId] = @AnaBaslikId)" UpdateCommand="UPDATE [PdfFiles] SET [KonuBasliği] = @KonuBasliği WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AnaBaslikId" PropertyName="SelectedValue" Type="Int32" />
                <asp:Parameter Name="FileUrl" Type="String" />
                <asp:Parameter Name="KonuBasliği" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AnaBaslikId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Id" Type="Int32" />
                <asp:Parameter Name="KonuBasliği" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </asp:Panel>

    <br />

    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" DefaultMode="Insert" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:TemplateField HeaderText="FileUrl" SortExpression="FileUrl">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FileUrl") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:FileUpload ID="pdfFileUpload" runat="server" AllowMultiple="false" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="pdfFileUpload" ErrorMessage="FileUrl alanı boş bırakılamaz." Display="Dynamic" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("FileUrl") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="KonuBasliği" SortExpression="KonuBasliği">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("KonuBasliği") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="konuBasliğiTextBox" runat="server" Text='<%# Bind("KonuBasliği") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="konuBasliğiTextBox" ErrorMessage="KonuBasliği alanı boş bırakılamaz." Display="Dynamic" />
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("KonuBasliği") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>

