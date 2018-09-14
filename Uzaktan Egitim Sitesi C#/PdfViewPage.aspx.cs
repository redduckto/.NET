using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AspDotNet_Tutorials_Default : BasePage
{
    public string pdfUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["PDF"]))
        {
            int pdfId = Convert.ToInt32(Request.QueryString.Get("PDF"));

            using (MyWebSiteDatabaseEntities myEntity = new MyWebSiteDatabaseEntities())
            {
                var aramaSonucu = from pdf in myEntity.PdfFiles
                                  where pdf.Id == pdfId
                                  select pdf;                

                // Veritabanında, query ile gönderilen PDF Id'si bulunursa sayfa açılacak.
                if (aramaSonucu != null)
                {
                    // Bulunan item, pdfFile'a dönüştürülüyor.
                    PdfFile pdfFile = aramaSonucu.ToList().ElementAt(0);

                    // "localHost" text'i alınıyor.
                    string localHost = HttpContext.Current.Request.Url.Host;

                    // "port" numarası alınıyor.
                    string port = HttpContext.Current.Request.Url.Port.ToString();

                    // Url başındaki "~" işareti siliniyor.
                    string fileUrl = pdfFile.FileUrl.Substring(1);

                    pdfUrl = fileUrl;
                }
                // Aranan PDF Url veritabanında yoksa AnaSayfa'ya dönülecek.
                else
                {
                    Response.Redirect("PdfFilesMenu.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("PdfFilesMenu.aspx");
        }
    }
}