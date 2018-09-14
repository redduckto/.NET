<%@ Page Title="Şifre değiştir" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="PasswordChange.aspx.cs" Inherits="PasswordChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="PasswordChanger">
        <asp:ChangePassword CssClass="AccountControl" ID="ChangePassword1" CancelDestinationPageUrl="~/Default.aspx"
            runat="server" CancelButtonText="İptal" ChangePasswordButtonText="Kaydet"
            ChangePasswordTitleText="Şifrenizi Değiştirin"
            ConfirmNewPasswordLabelText="Yeni Şifre (Tekrar):"
            ConfirmPasswordCompareErrorMessage="Yeni şifreleriniz uyuşmamaktadır."
            ConfirmPasswordRequiredErrorMessage="Yeni şifrenizi tekrar yazınız."
            NewPasswordRegularExpressionErrorMessage="Lütfen başka bir şifre yazınız."
            NewPasswordRequiredErrorMessage="Yeni şifre giriniz."
            PasswordLabelText="Şifre: " PasswordRequiredErrorMessage="Şifrenizi giriniz"
            SuccessText="Şifreniz başarıyla değiştirildi!." SuccessTitleText=""
            UserNameLabelText="Kullanıcı Adı:"
            UserNameRequiredErrorMessage="Kullanıcı adınızı giriniz."
            CancelButtonStyle-CssClass="MyButton" ChangePasswordButtonStyle-CssClass="MyButton" NewPasswordLabelText="Yeni Şifre:"
            ContinueButtonStyle-CssClass="MyButton" ContinueDestinationPageUrl="~/Default.aspx">
        </asp:ChangePassword>
    </div>
</asp:Content>

