<%@ Page Title="SignUp" Language="C#" MasterPageFile="~/MasterPages/FrontEnd.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" CssClass="AccountControl"
                AnswerLabelText="Cevap:"
                AnswerRequiredErrorMessage="Güvenlik sorusu gereklidir."
                CancelButtonText="İptal" CancelDestinationPageUrl="Login.aspx"
                CompleteSuccessText="Üyeliğiniz başarıyla oluşturuldu."
                ConfirmPasswordCompareErrorMessage="Şifreler uyuşmamakta."
                ConfirmPasswordLabelText="Şifre (tekrar):"
                ConfirmPasswordRequiredErrorMessage="Şifrenizi tekrar yazınız."
                ContinueButtonText="Devam" ContinueDestinationPageUrl="Login.aspx"
                CreateUserButtonText="Kaydet"
                DuplicateEmailErrorMessage="Kayıtlı bir e-mail adresi girdiniz. Lütfen başka bir e-mail adresi giriniz."
                DuplicateUserNameErrorMessage="Bu kullanıcı adı zaten kullanımda."
                EmailRegularExpressionErrorMessage="Bu e-mail adresi zaten kullanımda. Lütfen başka bir e-mail adresi giriniz."
                EmailRequiredErrorMessage="E-mail adresi giriniz."
                FinishCompleteButtonText="Sonlandır" FinishPreviousButtonText="Önceki"
                InvalidAnswerErrorMessage="Lütfen başka bir güvenlik cevabı giriniz."
                InvalidEmailErrorMessage="Lütfen geçerli bir e-mail adresi giriniz."
                InvalidPasswordErrorMessage="Minimum şifre uzunluğu: {0}. Gerekli özel karakter sayısı minimum: {1}."
                InvalidQuestionErrorMessage="Lütfen başka bir güvenlik sorusu giriniz." PasswordLabelText="Şifre:"
                PasswordRegularExpressionErrorMessage="Lütfen başka bir şifre giriniz."
                PasswordRequiredErrorMessage="Şifre gereklidir."
                QuestionLabelText="Güvenlik Sorusu:"
                QuestionRequiredErrorMessage="Güvenlik sorusu gereklidir."
                StartNextButtonText="Sonraki" StepNextButtonText="Sonraki"
                StepPreviousButtonText="Önceki"
                UnknownErrorMessage="Üyeliğiniz oluşturulamadı. Lütfen tekrar deneyin."
                UserNameLabelText="Kullanıcı Adı:"
                UserNameRequiredErrorMessage="Kullanıcı adı gereklidir." ToolTip="Yeni hesap oluşturun." OnCreatedUser="CreateUserWizard1_CreatedUser1">
                <ErrorMessageStyle CssClass="ErrorMessage" />
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="Yeni Hesap Oluşturun">
                        <ContentTemplate>
                            <table style="font-size: 100%;">
                                <tr>
                                    <td align="center" colspan="2">Yeni Hesap Oluşturun</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Kullanıcı Adı:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Kullanıcı adı gereklidir." ToolTip="Kullanıcı adı gereklidir." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Şifre:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Şifre gereklidir." ToolTip="Şifre gereklidir." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Şifre (tekrar):</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Şifrenizi tekrar yazınız." ToolTip="Şifrenizi tekrar yazınız." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Email" runat="server" ControlToValidate="Email" CausesValidation="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="E-mail adresi giriniz." ToolTip="E-mail adresi giriniz." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">&nbsp;
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Geçerli bir e-mail adresi giriniz." ValidationGroup="CreateUserWizard1" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Email" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Güvenlik Sorusu:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ErrorMessage="Güvenlik sorusu gereklidir." ToolTip="Güvenlik sorusu gereklidir." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Cevap:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ErrorMessage="Güvenlik sorusu gereklidir." ToolTip="Güvenlik sorusu gereklidir." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="Şifreler uyuşmamakta." ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="ErrorMessage" colspan="2" style="color: Red;">
                                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" class="ErrorMessage" colspan="2" style="color:darkslategray;">
                                        <asp:CheckBox ID="mailCheckBox" runat="server" Text="Mail ile bilgilendirme istiyorum." />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td align="center" colspan="2">Hoşgeldiniz!</td>
                                </tr>
                                <tr>
                                    <td>Üyeliğiniz başarıyla oluşturuldu.</td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue" Text="Devam" ValidationGroup="CreateUserWizard1" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <h3>Zaten giriş yaptınız.</h3>
            <p class="LargeFont">
                <a href="Default.aspx" runat="server">Buradan</a> AnaSayfa'ya dönebilirsiniz.
            </p>
        </LoggedInTemplate>
    </asp:LoginView>

</asp:Content>

