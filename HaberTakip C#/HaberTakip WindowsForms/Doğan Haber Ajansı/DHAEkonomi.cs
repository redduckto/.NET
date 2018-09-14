using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace HaberTakip_WindowsForms
{
    class DHAEkonomi : SuperClass
    {
        public DHAEkonomi(MainForm form, Kategoriler kategoriForm)
        {
            URL = "http://www.dha.com.tr/ekonomi/";
            YüklenenHaberler = new List<Haber>();
            KontrolHaberler = new List<Haber>();
            this.Form = form;
            this.KategoriForm = kategoriForm;
            IlkYükleme = false;
            XMLilkYükleme = false;
            PanelBaşlığı = "DHA/Ekonomi";
            XmlBaşlığı = "DHAEkonomi";
            CheckBox = kategoriForm.dhaEkonomiCheckBox;
        }


        public override void sonDakikaListesiniAl(HtmlDocument doc, List<Haber> liste)
        {
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[@class = 'sollar spor']/div/a");
            
            foreach (HtmlNode node in nodes)
            {
                HtmlNode divNode = node.ParentNode;
                string divClass = ""; // Class'ı tutmayan parent'a sahip olanları almasın diye bu yapılıyor.
                try
                {
                    divClass = divNode.Attributes[@"class"].Value; // Class attribute'u yoksa null gelecek. Ondan exception yakalanıyor denenip.
                }catch(NullReferenceException)
                {
                    continue;
                }
                if (divClass == "kutu " || divClass == "kutu sag")
                {
                    Haber haber = new Haber(Form);

                    string link = node.Attributes[@"href"].Value;
                    Console.Out.WriteLine(link);
                    haber.HaberLinki = link;
                    HtmlNode imgNode = node.SelectSingleNode("./img");

                    string imgURL = imgNode.Attributes[@"src"].Value;
                    haber.FotoLinki = imgURL;

                    HtmlNode spanNode = node.SelectSingleNode("./span");
                    haber.HaberBaşlığı = spanNode.InnerText;
                    liste.Add(haber);
                }
            }            
        }
    }
}
