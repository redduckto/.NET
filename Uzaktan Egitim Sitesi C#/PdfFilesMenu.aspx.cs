using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

public partial class PdfFilesMenu : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string anaBaşlıkParametre = Request.QueryString.Get("AnaBaslik");

        // Sayfaya "AnaBaslik" parametresi gönderildiyse;
        if (anaBaşlıkParametre != null)
        {
            int anaBaşlıkId = Convert.ToInt32(Request.QueryString.Get("AnaBaslik"));

            using (MyWebSiteDatabaseEntities myEntities = new MyWebSiteDatabaseEntities())
            {
                /* Parametre olarak gelen "AnaBaslik"ın, veritabanında bulunup bulunmadığı
                 * kontrol ediliyor.
                 */
                var anaBaşlık = from konu in myEntities.AnaBasliklars
                                select konu.Id;

                if (anaBaşlık.Contains(anaBaşlıkId))
                {
                    var pdfDosyaları = from konu in myEntities.PdfFiles
                                       where konu.AnaBaslikId == anaBaşlıkId
                                       orderby konu.KonuBasliği ascending
                                       select konu;

                    List<PdfFile> pdfListesi = pdfDosyaları.ToList();
                    if (pdfVarMı(pdfListesi) == false)
                    {
                        return;
                    }
                    else
                    {
                        if (Request.IsAuthenticated) // "Logged in" olunduysa
                        {
                            ListView1.DataSource = pdfListesi;
                            ListView1.DataBind();
                        }
                        else // "Logged in" olunmadıysa
                        {
                            List<PdfFile> örnekPdfDosyaları = new List<PdfFile>();

                            // Tüm listedeki ilk 3 dosya bilgisi, örnek listeye atılıyor.
                            // Böylece anonim kullanıcılara sadece ilk 3 dosya gösterilecek.
                            // Tüm konuda 3'ten az dosya varsa, örnek olarak 1 dosya gösterilecek.
                            int örnekPdfSayısı = 3;
                            if (örnekPdfSayısı > pdfListesi.Count)
                            {
                                örnekPdfSayısı = 1;
                            }
                            for (int i = 0; i < örnekPdfSayısı; i++)
                            {
                                örnekPdfDosyaları.Add(pdfListesi.ElementAt(i));
                            }
                            ListView1.DataSource = örnekPdfDosyaları;
                            ListView1.DataBind();
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private bool pdfVarMı(List<PdfFile> pdfListesi)
    {
        // Hiç pdf bulunamazsa uyarı verilip anasayfaya dönülüyor  
        if (pdfListesi.Count == 0)
        {
            Response.Write("<script>alert('Bu başlıkta PDF dosyası bulunmamaktadır.'); window.location.href = 'Default.aspx';</script>");
            return false;
        }
        else
        {
            return true;
        }
    }
}
