using System.Collections.Generic;
using HtmlAgilityPack;

namespace HaberTakip_WindowsForms
{
    class AATürkiye : SuperClass
    {
        public AATürkiye(MainForm form, Kategoriler kategoriForm)
        {
            URL = "http://aa.com.tr/tr/turkiye";
            YüklenenHaberler = new List<Haber>();
            KontrolHaberler = new List<Haber>();
            this.Form = form;
            this.KategoriForm = kategoriForm;
            IlkYükleme = false;
            XMLilkYükleme = false;
            PanelBaşlığı = "AA/Türkiye";
            XmlBaşlığı = "AATürkiye";
            CheckBox = kategoriForm.aaTürkiyeCheckBox;
        }

        public override void sonDakikaListesiniAl(HtmlDocument doc, List<Haber> liste)
        {
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//article [@class='linkbox large cat-2']/a");

            foreach (HtmlNode node in nodes)
            {
                Haber haber = new Haber(Form);

                string link = node.Attributes[@"href"].Value;                

                haber.HaberLinki = "http://aa.com.tr" + link;
                HtmlNode imgNode = node.SelectSingleNode("./img");

                string imgURL = imgNode.Attributes[@"src"].Value;
                haber.FotoLinki = imgURL;

                string başlık = imgNode.Attributes[@"alt"].Value;
                haber.HaberBaşlığı = başlık;
                liste.Add(haber);
            }
        }
    }
}
