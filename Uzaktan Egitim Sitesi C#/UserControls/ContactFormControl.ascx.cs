using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; // Text dosyasını okumak için gerekli
using System.Net.Mail; // Mail göndermek için eklendi

public partial class Controls_ContactForm : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Server-Side Validation
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if(!string.IsNullOrEmpty(phoneHomeTextBox.Text) || !string.IsNullOrEmpty(phoneBussinessTextBox.Text))
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void sendButton_Click(object sender, EventArgs e)
    {
        bool valid = Page.IsValid;

        if (Page.IsValid)
        {
            string path = Server.MapPath("~/App_Data/ContactForm.txt");
            string mailBody = File.ReadAllText(path);

            /* Taslak .txt dosyasında "##" ile default bırakılan değerler, textBox'lara girilen
             * değerlerle değiştiriliyor.
             */
            mailBody = mailBody.Replace("##Name##", nameTextBox.Text);
            mailBody = mailBody.Replace("##Email##", emailAddressTextBox.Text);
            mailBody = mailBody.Replace("##HomePhone##", phoneHomeTextBox.Text);
            mailBody = mailBody.Replace("##BussinessPhone##", phoneBussinessTextBox.Text);
            mailBody = mailBody.Replace("##Comments##", commentsTextBox.Text);

            string toEmail = "algoakademi@gmail.com";
            string SMTPUser = "algoakademi@gmail.com", SMTPPassword = "algoakademimanager!";
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SMTPUser);
            mail.To.Add(toEmail);
            mail.Subject = "AlgoAkademi Üyeliğiniz Hakkında";
            mail.Body = mailBody;
            mail.Priority = MailPriority.Normal;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);
            client.EnableSsl = true;
            client.Send(mail);

            Message.Visible = true;
            FormTable.Visible = false;
            System.Threading.Thread.Sleep(5000); // 5 saniye boyunca işlemler duruyor (Sleep).
        }
    }
}