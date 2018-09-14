<%@ Page Title="Şifremi Unuttum" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="ŞifremiUnuttum.aspx.cs" Inherits="ŞifremiUnuttum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:PasswordRecovery ID="PasswordRecovery1" CssClass="AccountControl" runat="server"
        AnswerLabelText="Cevap:" AnswerRequiredErrorMessage="Cevap gereklidir."
        GeneralFailureText="Şifrenizi kurtarma işleminizde bir hata oldu. Tekrar deneyiniz."
        OnSendingMail="PasswordRecovery1_SendingMail"
        QuestionFailureText="Cevabınız doğru değil. Tekrar deneyiniz."
        QuestionInstructionText="Şifrenizi kurtarmak için güvenlik sorunuzu cevaplayınız."
        QuestionLabelText="Güvenlik Sorusu:" QuestionTitleText="Kişilik Onayı"
        SubmitButtonText="Kaydet" SuccessText="Şifreniz başarıyla mail adresinize gönderildi."
        UserNameFailureText="Bilgilerinize ulaşamadık. Lütfen tekrar deneyiniz."
        UserNameInstructionText="Şifrenizi kurtarmak için kullanıcı adınızı giriniz."
        UserNameLabelText="Kullanıcı Adı:"
        UserNameRequiredErrorMessage="Kullanıcı Adı gereklidir."
        UserNameTitleText="Şifrenizi Mi Unuttunuz?">
        <SubmitButtonStyle CssClass="MyButton" />
        <MailDefinition From="algoakademi@gmail.com" Subject="AlgoAkademi Şifreniz" />
    </asp:PasswordRecovery>
</asp:Content>

