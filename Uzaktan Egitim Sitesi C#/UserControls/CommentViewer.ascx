<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CommentViewer.ascx.cs" Inherits="UserControl_CommentViewer" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div id="CommentSection">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- CommentAdder -->
            <asp:LoginView ID="LoginView1" runat="server">
                <LoggedInTemplate>
                    <div id="CommentText">
                        <asp:Label ID="Label1" runat="server" Text="Yorum yazınız."></asp:Label>
                        <br />
                        <asp:TextBox ID="yorumTextBox" CssClass="YorumTextBox" runat="server" TextMode="MultiLine" ToolTip="Yorum yazınız." ViewStateMode="Disabled"></asp:TextBox>
                        <br />
                        <asp:Button ID="SaveButton" UseSubmitBehavior="false" Text="Save" OnClick="SaveButton_Click" runat="server" />
                    </div>
                </LoggedInTemplate>
                <AnonymousTemplate>
                    <p class="UyarıText">
                        Yorum yapmak için lütfen <a href="~/SignUp.aspx" runat="server">Üye Olun.</a>
                    </p>
                </AnonymousTemplate>
            </asp:LoginView>

            <!-- CommentViewer -->
            <div id="ViewComments">
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                    <ItemTemplate>
                        <h3>
                            <asp:Literal ID="userNameLiteral" Text='<%# Eval("UserName") %>' runat="server"></asp:Literal>
                        </h3>
                        <p>
                            <asp:Literal ID="yorumLiteral" Text='<%# Eval("Yorum") %>' runat="server"></asp:Literal>
                        </p>
                        <p id="yorumTarihi">
                            <asp:Literal ID="tarihLiteral" Text='<%# Eval("Tarih") %>' runat="server"></asp:Literal>
                        </p>
                        <asp:Button ID="deleteButton" UseSubmitBehavior="false" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("Id") %>' Visible="false" />
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="uyarıLabel" runat="server" Text="Hiç yorum bulunamadı." CssClass="UyarıText"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
