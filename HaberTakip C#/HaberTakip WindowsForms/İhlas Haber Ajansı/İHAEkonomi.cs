using System.Collections.Generic;
using HtmlAgilityPack;

namespace HaberTakip_WindowsForms
{
    class İHAEkonomi : SuperClass
    {
        public İHAEkonomi(MainForm form, Kategoriler kategoriForm)
        {
            URL = "http://www.iha.com.tr/ekonomi/";
            YüklenenHaberler = new List<Haber>();
            KontrolHaberler = new List<Haber>();
            this.Form = form;
            this.KategoriForm = kategoriForm;
            IlkYükleme = false;
            XMLilkYükleme = false;
            PanelBaşlığı = "İHA/Ekonomi";
            XmlBaşlığı = "İHAEkonomi";
            CheckBox = kategoriForm.ihaEkonomiCheckBox;
        }

        public override void sonDakikaListesiniAl(HtmlDocument doc, List<Haber> liste)
        {
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div [@class= 'slider type4']/ul/li/a");

            foreach (HtmlNode node in nodes)
            {
                Haber haber = new Haber(Form);

                string link = node.Attributes[@"href"].Value;
                haber.HaberLinki = "http://www.iha.com.tr" + link;

                string başlık = node.Attributes[@"title"].Value;
                haber.HaberBaşlığı = başlık;

                HtmlNode imgNode = node.SelectSingleNode("./img");

                string imgURL = imgNode.Attributes[@"src"].Value;
                haber.FotoLinki = imgURL;


                liste.Add(haber);
            }
        }
    }
}
