using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using(MyWebSiteDatabaseEntities myEntity = new MyWebSiteDatabaseEntities())
        {
            var pdfSonuçları = from pdf in myEntity.PdfFiles
                               orderby pdf.Id descending
                               select pdf;

            List<PdfFile> pdfListesi = new List<PdfFile>();

            for(int i = 0; i < 5; i++)
            {
                pdfListesi.Add(pdfSonuçları.ToList().ElementAt(i));
            }

            pdfRepeater.DataSource = pdfListesi;
            pdfRepeater.DataBind();

            var videoSonuçları = from video in myEntity.VideoUrls
                                 orderby video.Id descending
                                 select video;

            List<VideoUrl> videoListesi = new List<VideoUrl>();

            for(int i=0; i < 5; i++)
            {
                videoListesi.Add(videoSonuçları.ToList().ElementAt(i));
            }

            videoRepeater.DataSource = videoListesi;
            videoRepeater.DataBind(); 
        }
    }
}