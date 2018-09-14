<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login1" CssClass="AccountControl" DestinationPageUrl="~/Default.aspx" runat="server" CreateUserText="Üyelik oluşturun." CreateUserUrl="~/SignUp.aspx" FailureText="Giriş denemesi başarısız oldu. Lütfen tekrar deneyin." LoginButtonText="Giriş" PasswordLabelText="Şifre:" PasswordRequiredErrorMessage="Şifrenizi giriniz." RememberMeText="Beni hatırla" TitleText="Giriş" UserNameLabelText="Kullanıcı Adı:" UserNameRequiredErrorMessage="Kullanıcı adınızı giriniz." VisibleWhenLoggedIn="False" PasswordRecoveryText="Şifremi Unuttum" PasswordRecoveryUrl="~/ŞifremiUnuttum.aspx">
            </asp:Login>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h3>Zaten giriş yaptınız.</h3>
            <p class="LargeFont">
                <a href="Default.aspx" runat="server">Buradan</a> AnaSayfa'ya dönebilirsiniz.
            </p>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>

