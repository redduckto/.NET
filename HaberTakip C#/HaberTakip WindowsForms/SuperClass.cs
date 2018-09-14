using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace HaberTakip_WindowsForms
{
    public abstract class SuperClass
    {
        private string uRL;
        private List<Haber> yüklenenHaberler;
        private List<Haber> kontrolHaberler;

        private HtmlAgilityPack.HtmlDocument document;
        private HtmlAgilityPack.HtmlDocument newDocument;

        private bool ilkYükleme;
        private bool xMLilkYükleme;

        private MainForm form;
        private Kategoriler kategoriForm;

        private string xmlBaşlığı;
        private string panelBaşlığı;

        private CheckBox checkBox;

        // Getter-Setter'lar
        public string URL
        {
            get
            {
                return uRL;
            }

            set
            {
                uRL = value;
            }
        }

        public List<Haber> YüklenenHaberler
        {
            get
            {
                return yüklenenHaberler;
            }

            set
            {
                yüklenenHaberler = value;
            }
        }

        public List<Haber> KontrolHaberler
        {
            get
            {
                return kontrolHaberler;
            }

            set
            {
                kontrolHaberler = value;
            }
        }

        public HtmlAgilityPack.HtmlDocument Document
        {
            get
            {
                return document;
            }

            set
            {
                document = value;
            }
        }

        public HtmlAgilityPack.HtmlDocument NewDocument
        {
            get
            {
                return newDocument;
            }

            set
            {
                newDocument = value;
            }
        }

        public bool IlkYükleme
        {
            get
            {
                return ilkYükleme;
            }

            set
            {
                ilkYükleme = value;
            }
        }

        public bool XMLilkYükleme
        {
            get
            {
                return xMLilkYükleme;
            }

            set
            {
                xMLilkYükleme = value;
            }
        }

        public MainForm Form
        {
            get
            {
                return form;
            }

            set
            {
                form = value;
            }
        }

        public Kategoriler KategoriForm
        {
            get
            {
                return kategoriForm;
            }

            set
            {
                kategoriForm = value;
            }
        }

        public string XmlBaşlığı
        {
            get
            {
                return xmlBaşlığı;
            }

            set
            {
                xmlBaşlığı = value;
            }
        }

        public string PanelBaşlığı
        {
            get
            {
                return panelBaşlığı;
            }

            set
            {
                panelBaşlığı = value;
            }
        }

        public CheckBox CheckBox
        {
            get
            {
                return checkBox;
            }

            set
            {
                checkBox = value;
            }
        }

        // Diğer metodlar
        public void monitorWebSite()
        {
            if (CheckBox.Checked && XMLilkYükleme == false)
            {
                try
                {
                    HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
                    Document = website.Load(URL);
                }
                catch (IOException)
                {

                }
                catch (WebException)
                {

                }

                YüklenenHaberler.Clear();
                KontrolHaberler.Clear();

                if (Document != null)
                {
                    sonDakikaListesiniAl(Document, YüklenenHaberler);
                }

                if (YüklenenHaberler.Count > Form.max)
                {
                    Form.max = YüklenenHaberler.Count;
                }

                if (yüklenenHaberler.Count > 0)
                {
                    XmlElement root = Form.xmlDoc.DocumentElement; // xml'in root'u alındı.
                    XmlElement kategori = Form.xmlDoc.CreateElement(XmlBaşlığı);
                    root.AppendChild(kategori); // root'a kategori eklendi.
                }
            }
        }

        public void timeTickMonitorWebSite()
        {
            if (CheckBox.Checked)
            {
                try
                {
                    HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
                    NewDocument = website.Load(URL);
                }
                catch (IOException)
                {

                }
                catch (WebException)
                {

                }

                KontrolHaberler.Clear();
                if (NewDocument != null)
                {
                    sonDakikaListesiniAl(NewDocument, KontrolHaberler);
                }

                karşılaştır(YüklenenHaberler, KontrolHaberler);
                eskiHaberleriTemizle(YüklenenHaberler, KontrolHaberler);
            }
        }

        public abstract void sonDakikaListesiniAl(HtmlAgilityPack.HtmlDocument doc, List<Haber> liste);

        public void eskiHaberleriTemizle(List<Haber> liste1, List<Haber> liste2)
        {
            List<string> eskiHaberLinkleri = new List<string>();
            for (int i = 0; i < liste1.Count; i++)
            {
                string link = liste1[i].HaberLinki;
                eskiHaberLinkleri.Add(link); // eski haber listesindeki bütün haber linkleri listesi oluşturuluyor
            }

            List<string> yeniHaberLinkleri = new List<string>();
            for (int i = 0; i < liste2.Count; i++)
            {
                string link = liste2[i].HaberLinki;
                yeniHaberLinkleri.Add(link); // yeni haber listesindeki bütün haber linkleri listesi oluşturuluyor
            }

            for (int i = 0; i < eskiHaberLinkleri.Count; i++)
            {
                string haberLinki = eskiHaberLinkleri[i];

                if (!yeniHaberLinkleri.Contains(haberLinki))
                {
                    Haber haber = liste1[i];

                    liste1.Remove(haber);
                }
            }
        }

        public void karşılaştır(List<Haber> liste1, List<Haber> liste2)
        {
            List<string> eskiHaberLinkleri = new List<string>();
            for (int i = 0; i < liste1.Count; i++)
            {
                string link = liste1[i].HaberLinki;
                eskiHaberLinkleri.Add(link); // eski haber listesindeki bütün haber linkleri listesi oluşturuluyor
            }

            List<string> yeniHaberLinkleri = new List<string>();
            for (int i = 0; i < liste2.Count; i++)
            {
                string link = liste2[i].HaberLinki;
                yeniHaberLinkleri.Add(link); // yeni haber listesindeki bütün haber linkleri listesi oluşturuluyor
            }

            for (int i = 0; i < yeniHaberLinkleri.Count; i++)
            {
                string haberLinki = yeniHaberLinkleri[i];

                if (!eskiHaberLinkleri.Contains(haberLinki))
                {
                    form.Cursor = Cursors.WaitCursor;
                    form.monitorButton.Enabled = false;
                    form.kategorilerButton.Enabled = false;

                    Haber haber2 = liste2[i];

                    haber2.paneleHaberEkle("Yeni Haber (" + PanelBaşlığı + ")");
                    haber2.XMLeHaberEkle(XmlBaşlığı);

                    liste1.Add(haber2);

                    form.Cursor = Cursors.Default;
                    form.monitorButton.Enabled = true;
                    form.kategorilerButton.Enabled = true;
                }
            }
        }

        public void yazdır(int sayaç)
        {
            if (CheckBox.Checked && sayaç < YüklenenHaberler.Count)
            {
                Haber haber = YüklenenHaberler[sayaç];
                if (IlkYükleme == false)
                {
                    haber.paneleHaberEkle(PanelBaşlığı);
                }

                if (XMLilkYükleme == false)
                {
                    // XML'e yazılan haberlerin tekrar XML'e yazılmaması için
                    XmlNode kategori = Form.xmlDoc.SelectSingleNode(@"//" + XmlBaşlığı); // kategori node'u alındı
                    if (kategori.ChildNodes.Count < YüklenenHaberler.Count)
                    {
                        haber.XMLeHaberEkle(XmlBaşlığı);
                    }
                }

                if (sayaç == 0)
                {
                    IlkYükleme = true;
                    XMLilkYükleme = true;
                }
            }
        }

        public void xmldenİlkYükleme()
        {
            XmlElement rootElement = Form.xmlDoc.DocumentElement;
            XmlNode kategori = Form.xmlDoc.SelectSingleNode(@"//" + XmlBaşlığı);
            if (kategori != null) // kategorinin node'u xml'de bulunuyorsa
            {
                if (kategori.HasChildNodes) // kategorinin child node'ları varsa
                {
                    XmlNodeList nodeList = kategori.ChildNodes;

                    for (int i = 0; i < nodeList.Count; i++)
                    {
                        XmlNode node = nodeList.Item(i);
                        XmlNodeList haberBilgileri = node.ChildNodes;

                        Haber haber = new Haber(Form);
                        YüklenenHaberler.Add(haber.nodedanHaberYarat(haberBilgileri));
                    }
                    CheckBox.Checked = true;
                    if (YüklenenHaberler.Count > Form.max)
                    {
                        Form.max = YüklenenHaberler.Count;
                    }
                }
            }
        }

        public void XMLBaşlıklarınıSil()
        {
            if (!CheckBox.Checked)
            {
                XmlElement root = Form.xmlDoc.DocumentElement; // xml'in root element'i alındı
                XmlNode kategori = Form.xmlDoc.SelectSingleNode(@"//" + XmlBaşlığı);

                if (kategori != null)
                {
                    root.RemoveChild(kategori); // kategoriye ait node siliniyor

                    // Aynı anda hem bir kategorinin checkbox'u işaretlenip, başka biri kaldırılırsa,
                    // "xml'i başka bir işlem kullanıyor" hatası veriyor. Ondan bu loop eklendi.
                    // Xml boşa çıkıp kaydedilene kadar deneyecek yani.
                    bool loop = true;
                    while (loop)
                    {
                        loop = false;
                        try
                        {
                            Form.xmlDoc.Save("HaberlerXML.xml");
                        }
                        catch (IOException)
                        {
                            loop = true;
                        }
                    }

                    XMLilkYükleme = false;
                }
            }
        }
    }
}
