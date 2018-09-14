using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_CommentViewer : System.Web.UI.UserControl
{
    List<VideoYorumlari> videoYorumList;
    List<PdfYorumları> pdfYorumList;

    protected void Page_Load(object sender, EventArgs e)
    {
        videoYorumList = new List<VideoYorumlari>();
        pdfYorumList = new List<PdfYorumları>();

        // "VideoViewPage" sayfası açılırsa, yani parametre olarak "Video" gelmişse;
        if (!string.IsNullOrEmpty(Request.QueryString["Video"]))
        {
            // "VideoLinksMenu.aspx"in gönderdiği "Video" parametresi alınıyor.
            string parametre = Request.QueryString.Get("Video");
            int requestedVideoId = Convert.ToInt32(parametre);

            using (MyWebSiteDatabaseEntities myEntity = new MyWebSiteDatabaseEntities())
            {
                // sayfaya kullanıcı yorumları ekleniyor.
                var yorumlar = from yorum in myEntity.VideoYorumlaris
                               where yorum.VideoId == requestedVideoId
                               orderby yorum.Tarih descending
                               select yorum;

                videoYorumList = yorumlar.ToList();

                if (videoYorumList.Count > 0)
                {
                    Repeater1.DataSource = yorumlar.ToList();
                    Repeater1.DataBind();

                    commentDeleteButtonVisible(Repeater1);

                    uyarıLabel.Visible = false;
                }
                else
                {
                    // Yorum bulunamazsa "Repeater1" görünmez yapılıp uyarıLabel gösteriliyor.
                    Repeater1.Visible = false;
                    uyarıLabel.Visible = true;
                }
            }
        }
        // "PdfViewPage" sayfası açılırsa, yani parametre olarak "PDF" gelmişse;
        else if (!string.IsNullOrEmpty(Request.QueryString["PDF"]))
        {
            int pdfId = Convert.ToInt32(Request.QueryString.Get("PDF"));

            using (MyWebSiteDatabaseEntities myEntity = new MyWebSiteDatabaseEntities())
            {
                // sayfaya kullanıcı yorumları ekleniyor.
                var yorumlar = from yorum in myEntity.PdfYorumları
                               where yorum.PdfId == pdfId
                               orderby yorum.Tarih descending
                               select yorum;

                pdfYorumList = yorumlar.ToList();

                if (pdfYorumList.Count > 0)
                {
                    Repeater1.DataSource = yorumlar.ToList();
                    Repeater1.DataBind();

                    commentDeleteButtonVisible(Repeater1);

                    Repeater1.Visible = true;
                    uyarıLabel.Visible = false;
                }
                else
                {
                    // Yorum bulunamazsa "Repeater1" görünmez yapılıp uyarıLabel gösteriliyor.
                    Repeater1.Visible = false;
                    uyarıLabel.Visible = true;
                }
            }
        }
    }

    private void commentDeleteButtonVisible(Repeater repeater)
    {
        if (Roles.IsUserInRole("Managers"))
        {
            // User, "Managers" rolündeyse tüm rollerin "deleteButton"u "visible" yapılıyor.
            for (int i = 0; i < repeater.Items.Count; i++)
            {
                Button deleteButton = (Button)repeater.Items[i].FindControl("deleteButton");
                deleteButton.Visible = true;
            }
        }
        else
        {
            // Yorumlardan kullanıcıya ait olanların "deleteButton"u "visible" yapılıyor.
            if (Membership.GetUser() != null)
            {
                string userName = Membership.GetUser().UserName;
                {
                    for (int i = 0; i < repeater.Items.Count; i++)
                    {
                        Literal userNameLiteral = (Literal)repeater.Items[i].FindControl("userNameLiteral");
                        if (userName == userNameLiteral.Text)
                        {
                            Button deleteButton = (Button)repeater.Items[i].FindControl("deleteButton");
                            deleteButton.Visible = true;
                        }
                    }
                }
            }
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int yorumId = Convert.ToInt32(e.CommandArgument);

            using (MyWebSiteDatabaseEntities myEntity = new MyWebSiteDatabaseEntities())
            {
                // Repeater'daki item'lar "VideoYorumlari" ise;
                if (videoYorumList.Count > 0)
                {
                    for (int i = 0; i < videoYorumList.Count; i++)
                    {
                        // Item listeden silinip, liste repeater'a bağlanıyor dataSource olarak
                        if (videoYorumList[i].Id == yorumId)
                        {
                            videoYorumList.RemoveAt(i);
                            Repeater1.DataSource = videoYorumList;
                            Repeater1.DataBind();
                        }
                    }

                    // Yeniden "deleteButton"un "Visible" özelliği ayarlanıyor.
                    commentDeleteButtonVisible(Repeater1);

                    // Item, database'ten siliniyor
                    var aramaSonucu = from yorum in myEntity.VideoYorumlaris
                                      where yorum.Id == yorumId
                                      select yorum;

                    VideoYorumlari arananYorum = aramaSonucu.ToList().ElementAt(0);
                    myEntity.VideoYorumlaris.Remove(arananYorum);
                    myEntity.SaveChanges();
                }

                // Repeater'daki item'lar "PdfYorumları" ise;
                if (pdfYorumList.Count > 0)
                {
                    for (int i = 0; i < pdfYorumList.Count; i++)
                    {
                        // Item listeden silinip, liste repeater'a bağlanıyor dataSource olarak
                        if (pdfYorumList[i].Id == yorumId)
                        {
                            pdfYorumList.RemoveAt(i);
                            Repeater1.DataSource = pdfYorumList;
                            Repeater1.DataBind();
                        }
                    }

                    // Yeniden "deleteButton"un "Visible" özelliği ayarlanıyor.
                    commentDeleteButtonVisible(Repeater1);

                    // Item, database'ten siliniyor
                    var aramaSonucu = from yorum in myEntity.PdfYorumları
                                      where yorum.Id == yorumId
                                      select yorum;

                    PdfYorumları arananYorum = aramaSonucu.ToList().ElementAt(0);
                    myEntity.PdfYorumları.Remove(arananYorum);
                    myEntity.SaveChanges();
                }
            }
        }
    }

    protected void SaveButton_Click(Object Src, EventArgs E)
    {
        // Linkte "Video" id numarası gönderildiyse
        if (!string.IsNullOrEmpty(Request.QueryString["Video"]))
        {
            int videoId = Convert.ToInt32(Request.QueryString.Get("Video"));
            string userName = Membership.GetUser().ToString();

            VideoYorumlari yeniYorum = new VideoYorumlari();
            yeniYorum.VideoId = videoId;
            yeniYorum.UserName = userName;
            yeniYorum.Tarih = DateTime.Now.ToString();
            TextBox yorumTextBox = (TextBox)LoginView1.FindControl("yorumTextBox");

            // "TrimStart" ile text'in başında boş kısım varsa kesiliyor.
            if (!string.IsNullOrEmpty(yorumTextBox.Text.TrimStart()))
            {
                yeniYorum.Yorum = yorumTextBox.Text;

                using (var myEntity = new MyWebSiteDatabaseEntities())
                {
                    myEntity.VideoYorumlaris.Add(yeniYorum);
                    myEntity.SaveChanges();
                }

                // Yorum gönderildikten sonra textbox'ın içi siliniyor.
                yorumTextBox.Text = "";

                // Yeni liste, repeater'a bağlanıyor. Yeni yorum en başa ekleniyor.
                Repeater repeater = (Repeater)UpdatePanel1.FindControl("Repeater1");
                videoYorumList.Insert(0, yeniYorum);
                repeater.DataSource = videoYorumList;
                repeater.DataBind();

                repeater.Visible = true;
                uyarıLabel.Visible = false;
            }
        }

        // Linkte "PDF" url'si gönderildiyse
        else if (!string.IsNullOrEmpty(Request.QueryString["PDF"]))
        {
            int requestedPdfId = Convert.ToInt32(Request.QueryString.Get("PDF"));
            string userName = Membership.GetUser().ToString();

            PdfYorumları yeniYorum = new PdfYorumları();
            yeniYorum.PdfId = requestedPdfId;
            yeniYorum.UserName = userName;
            yeniYorum.Tarih = DateTime.Now.ToString();
            TextBox yorumTextBox = (TextBox)LoginView1.FindControl("yorumTextBox");

            // "TrimStart" ile text'in başında boş kısım varsa kesiliyor.
            if (!string.IsNullOrEmpty(yorumTextBox.Text.TrimStart()))
            {
                yeniYorum.Yorum = yorumTextBox.Text;

                using (var myEntity = new MyWebSiteDatabaseEntities())
                {
                    myEntity.PdfYorumları.Add(yeniYorum);
                    myEntity.SaveChanges();
                }
            }

            // Yorum gönderildikten sonra textbox'ın içi siliniyor.
            yorumTextBox.Text = "";

            // Yeni liste, repeater'a bağlanıyor. Yeni yorum en başa ekleniyor.
            Repeater repeater = (Repeater)UpdatePanel1.FindControl("Repeater1");
            pdfYorumList.Insert(0, yeniYorum);
            repeater.DataSource = pdfYorumList;
            repeater.DataBind();

            repeater.Visible = true;
            uyarıLabel.Visible = false;
        }

        // "deleteButton"ların "visible" özellikleri ayarlanıyor.
        commentDeleteButtonVisible(Repeater1);
    }
}

