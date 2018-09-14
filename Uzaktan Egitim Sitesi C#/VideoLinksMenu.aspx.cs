using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VideoLinksMenu : BasePage
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
                    var videolar = from konu in myEntities.VideoUrls
                                        where konu.AnaBaslikId == anaBaşlıkId
                                        orderby konu.VideoBasliği ascending
                                        select konu;
                    List<VideoUrl> videoListesi = videolar.ToList();

                    if (videoVarMı(videoListesi) == false)
                    {
                        return;
                    }
                    else
                    {
                        if (Request.IsAuthenticated) // "Logged in" olunduysa
                        {
                            ListView1.DataSource = videoListesi;
                            ListView1.DataBind();
                        }
                        else // "Logged in" olunmadıysa
                        {
                            List<VideoUrl> örnekVideoLinkleri = new List<VideoUrl>();
                            // Tüm listedeki ilk 3 dosya bilgisi, örnek listeye atılıyor.
                            // Böylece anonim kullanıcılara sadece ilk 3 dosya gösterilecek.
                            // Tüm konuda 3'ten az dosya varsa, örnek olarak 1 dosya gösterilecek.
                            int örnekVideoSayısı = 3;
                            if (örnekVideoSayısı > videoListesi.Count)
                            {
                                örnekVideoSayısı = 1;
                            }
                            for (int i = 0; i < örnekVideoSayısı; i++)
                            {
                                örnekVideoLinkleri.Add(videoListesi.ElementAt(i));
                            }
                            ListView1.DataSource = örnekVideoLinkleri;
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

    private bool videoVarMı(List<VideoUrl> videoListesi)
    {
        if(videoListesi.Count == 0)
        {
            Response.Write("<script>alert('Bu başlıkta video bulunmamaktadır.'); window.location.href = 'Default.aspx';</script>");
            return false;
        }
        else
        {
            return true;
        }
    }
}