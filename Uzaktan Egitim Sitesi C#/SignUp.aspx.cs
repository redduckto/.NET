using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail; // Mail göndermek için eklendi.
using System.IO;

public partial class SignUp : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void CreateUserWizard1_CreatedUser1(object sender, EventArgs e)
    {
        CreateUserWizard createUserWizard = (CreateUserWizard)LoginView1.FindControl("CreateUserWizard1");
        CreateUserWizardStep createUserStep = (CreateUserWizardStep)createUserWizard.FindControl("CreateUserWizardStep1");
        CheckBox mailCheckBox = (CheckBox)createUserStep.ContentTemplateContainer.FindControl("mailCheckBox");        

        if (mailCheckBox.Checked)
        {
            TextBox userNameTextBox = (TextBox)createUserStep.ContentTemplateContainer.FindControl("UserName");
            TextBox passwordTextBox = (TextBox)createUserStep.ContentTemplateContainer.FindControl("Password");
            TextBox emailTextBox = (TextBox)createUserStep.ContentTemplateContainer.FindControl("Email");
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;
            string email = emailTextBox.Text;

            string path = Server.MapPath("~/App_Data/SignUpConfirmation.txt");
            string body = File.ReadAllText(path);

            body = body.Replace("<%UserName%>", userName);
            body = body.Replace("<%Password%>", password);

            string toEmail = email;
            string SMTPUser = "algoakademi@gmail.com", SMTPPassword = "algoakademimanager!";
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(SMTPUser);
            mail.To.Add(toEmail);
            mail.Subject = "AlgoAkademi Üyeliğiniz Hakkında";
            mail.Body = body;
            mail.Priority = MailPriority.Normal;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential(SMTPUser, SMTPPassword);
            client.EnableSsl = true;
            client.Send(mail);
        }
    }
}