<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactFormControl.ascx.cs" Inherits="Controls_ContactForm" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<!-- Client-Side Validation -->
<script type="text/javascript">
    function ValidatePhoneNumbers(source, args) {
        var phoneHome = document.getElementById('<%=phoneHomeTextBox.ClientID%>');
        var phoneBussiness = document.getElementById('<%=phoneBussinessTextBox.ClientID%>');
        if (phoneHome.value != '' || phoneBussiness.value != '') {
            args.IsValid = true;
        }
        else {
            args.IsValid = false;
        }
    }
</script>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<!-- Tüm tabloyu, form gönderildikten sonra gizlemek için table'a runat ve id eklendi 
    ve tüm table'ın altına "label" eklendi. -->
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table class="auto-style1" runat="server" id="FormTable">
            <tr>
                <td colspan="3">Lütfen gerekli bilgileri yazıp yorumunuzu gönderin.</td>
            </tr>
            <tr>
                <td>İsim:</td>
                <td>
                    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nameTextBox" CssClass="ErrorMessage" ErrorMessage="İsminizi yazınız.">* İsminizi yazınız.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="emailAddressTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="emailAddressTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="E-mail adresinizi giriniz.">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="emailAddressTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Geçerli bir e-mail adresi giriniz." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Email (Tekrar):</td>
                <td>
                    <asp:TextBox ID="confirmEmailAddressTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="confirmEmailAddressTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="E-mail adresinizi tekrar yazınız.">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="emailAddressTextBox" ControlToValidate="confirmEmailAddressTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="E-mail adresleri uyuşmamakta.">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>Ev Telefonu:</td>
                <td>
                    <asp:TextBox ID="phoneHomeTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidatePhoneNumbers" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Ev veya iş telefonunuzu yazınız." OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>İş Telefonu:</td>
                <td>
                    <asp:TextBox ID="phoneBussinessTextBox" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Yorum:</td>
                <td>
                    <asp:TextBox ID="commentsTextBox" runat="server" Height="160px" TextMode="MultiLine" Width="264px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="commentsTextBox" CssClass="ErrorMessage" Display="Dynamic" ErrorMessage="Yorumunuzu yazınız.">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="sendButton" runat="server" Text="Gönder" OnClick="sendButton_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Lütfen gerekli düzeltmeleri yaptıktan sonra Gönder tuşuna basınız." ShowMessageBox="True" ShowSummary="False" />
                </td>
            </tr>
        </table>
        <asp:Label ID="Message" runat="server" Text="Mesajınız gönderildi!" Visible="false" />
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
    <ProgressTemplate>
        <div class="PleaseWait">
            Lütfen bekleyin...
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
