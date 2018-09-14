using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace HaberTakip_WindowsForms
{
    public class Haber
    {
        private string haberBaşlığı;
        private string haberLinki;
        private string fotoLinki;
        private MainForm form;

        // Getter-Setter'lar
        public string HaberBaşlığı
        {
            get
            {
                return haberBaşlığı;
            }

            set
            {
                haberBaşlığı = value;
            }
        }

        public string HaberLinki
        {
            get
            {
                return haberLinki;
            }

            set
            {
                haberLinki = value;
            }
        }

        public string FotoLinki
        {
            get
            {
                return fotoLinki;
            }

            set
            {
                fotoLinki = value;
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
        
        // Diğer metordlar
        public Haber(MainForm form)
        {
            this.form = form;
        }

        public void paneleHaberEkle(string haberKategorisi)
        {
            Image haberFoto = null; // Try'dan Exception gelirse diye initialize edildi Image
            try
            {
                WebRequest request = WebRequest.Create(FotoLinki);
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                haberFoto = Image.FromStream(stream);
            }
            catch (Exception)
            {
                return; // internet bağlantısı yoksa panel boş bırakılacak yeni yüklemelerde
            }            

            // Bir önceki haberin üstüne boşluk konulup yeni haber yazdırılıyor
            Label boşluk = new Label();
            boşluk.Text = "";
            boşluk.Dock = DockStyle.Top;
            if (Form.haberPanel.InvokeRequired)
            {
                Form.haberPanel.Invoke(new MethodInvoker(delegate
                {
                    Form.haberPanel.Controls.Add(boşluk);
                }));
            }
            else
            {
                Form.haberPanel.Controls.Add(boşluk);
            }

            PictureBox foto = new PictureBox();
            // Fotoğrafların boyutu otomatik olarak haber panelinin boyutuna göre oranlanıyor.
            // 0,526 = fotoğrafın gerçek boyutları arasındak oran (height/width)
            foto.Size = new Size(Form.haberPanel.Width - 20, Convert.ToInt32(0.526 * (Form.haberPanel.Width - 20)));
            foto.SizeMode = PictureBoxSizeMode.StretchImage;
            foto.Image = haberFoto;
            foto.Dock = DockStyle.Top;
            foto.Cursor = Cursors.Hand;
            if (Form.haberPanel.InvokeRequired)
            {
                Form.haberPanel.Invoke(new MethodInvoker(delegate
                {
                    Form.haberPanel.Controls.Add(foto);
                }));
            }
            else
            {
                Form.haberPanel.Controls.Add(foto);
            }

            Label başlık = new Label();
            başlık.Text = haberKategorisi + ": " + WebUtility.HtmlDecode(HaberBaşlığı); // Türkçe karakterlerin vs yazdırılabilmesi için "decode" yapılıyor.
            başlık.Font = new Font(başlık.Font, FontStyle.Bold);
            başlık.Dock = DockStyle.Top;
            if (Form.haberPanel.InvokeRequired)
            {
                Form.haberPanel.Invoke(new MethodInvoker(delegate
                {
                    Form.haberPanel.Controls.Add(başlık);
                }));
            }
            else
            {
                Form.haberPanel.Controls.Add(başlık);
            }

            // PictureBox'a tıklanınca siteye yönlendirmesi sağlanıyor
            foto.MouseClick += new MouseEventHandler((o, a) =>
            {
                try
                {
                    System.Diagnostics.Process.Start(HaberLinki);
                }
                catch (UriFormatException)
                {

                }
                catch (IOException)
                {

                }
            });
        }

        public Haber nodedanHaberYarat(XmlNodeList childNodes)
        {   // Node'un 0-1-2. child'ları alınıyor.
            HaberBaşlığı = childNodes.Item(0).InnerText;
            HaberLinki = childNodes.Item(1).InnerText;
            FotoLinki = childNodes.Item(2).InnerText;

            return this;
        }

        public void XMLeHaberEkle(string haberKategorisi)
        {
            XmlNode kategori = Form.xmlDoc.SelectSingleNode(@"//" + haberKategorisi); // Kategori node'u alındı
            XmlElement haberNode = Form.xmlDoc.CreateElement("HABER"); // Kategori içine konulacak HABER node'u oluşturuldu
            XmlElement haberBaşlıkNode = Form.xmlDoc.CreateElement("Başlık");
            haberBaşlıkNode.InnerText = WebUtility.HtmlDecode(HaberBaşlığı); // Türkçe karakterlerin vs yazdırılabilmesi için "decode" yapılıyor.
            XmlElement haberLinkNode = Form.xmlDoc.CreateElement("Link");
            haberLinkNode.InnerText = HaberLinki;
            XmlElement fotoLinkNode = Form.xmlDoc.CreateElement("FotoLink");
            fotoLinkNode.InnerText = FotoLinki;

            haberNode.AppendChild(haberBaşlıkNode);
            haberNode.AppendChild(haberLinkNode);
            haberNode.AppendChild(fotoLinkNode);

            // Sıranın bozulmaması için yeni node en başa ekleniyor.
            kategori.InsertBefore(haberNode, kategori.FirstChild); // Haberin node'u xml'e eklendi.

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
        }
    }
}