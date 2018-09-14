using System.Collections.Generic;
using HtmlAgilityPack;

namespace HaberTakip_WindowsForms
{
    public class DHAPolitika : SuperClass
    {
        public DHAPolitika(MainForm form, Kategoriler kategoriForm)
        {
            URL = "http://www.dha.com.tr/politika/";
            YüklenenHaberler = new List<Haber>();
            KontrolHaberler = new List<Haber>();
            this.Form = form;
            this.KategoriForm = kategoriForm;
            IlkYükleme = false;
            XMLilkYükleme = false;
            PanelBaşlığı = "DHA/Politika";
            XmlBaşlığı = "DHAPolitika";
            CheckBox = kategoriForm.dhaPolitikaCheckBox;
        }

        public override void sonDakikaListesiniAl(HtmlDocument doc, List<Haber> liste)
        {
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div [@class = 'mansetresim']/a");

            foreach (HtmlNode node in nodes)
            {
                Haber haber = new Haber(Form);

                string link = node.Attributes[@"href"].Value;

                haber.HaberLinki = link;
                HtmlNode imgNode = node.SelectSingleNode("./img");

                string imgURL = imgNode.Attributes[@"src"].Value;
                haber.FotoLinki = imgURL;

                haber.HaberBaşlığı = "";
                liste.Add(haber);
            }
        }
    }
}