using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VideoViewPage : BasePage
{
    public string videoUrl;

    protected void Page_Load(object sender, EventArgs e)
    {
        // "VideoLinksMenu.aspx"in gönderdiği "Video" parametresi alınıyor.
        if (!string.IsNullOrEmpty(Request.QueryString["Video"]))
        {
            int requestedVideoId = Convert.ToInt32(Request.QueryString.Get("Video"));
            using (MyWebSiteDatabaseEntities myEntity = new MyWebSiteDatabaseEntities())
            {
                var myVideo = from video in myEntity.VideoUrls
                              where video.Id == requestedVideoId
                              select video.VideoLink;

                // Aranan video veritabanında bulunmuşsa sayfa açılacak.
                if (myVideo != null)
                {
                    /* Query'den 1 adet video dönecek. Fakat query sonucu, birden çok veri 
                     * olarak algılanıyor. Bunu "ToList()" ile listeye çevirip ilk elemanını
                     * alınca istenen videoya ulaşılmış oluyor.
                     */
                    videoUrl = myVideo.ToList().ElementAt(0);
                }
                // Aranan video veritabanında bulunamazsa AnaSayfa'ya dönülecek.
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
}