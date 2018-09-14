using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace HaberTakip_WindowsForms
{
    public partial class MainForm : Form
    {
        public int taramaAralığı = 300000; // sitelerdeki yeni haberlerin taranma aralığı

        Kategoriler kategoriForm;

        public List<SuperClass> haberListe;

        DHAYurt dhaYurt;
        DHAPolitika dhaPolitika;
        DHASpor dhaSpor;
        DHADünya dhaDünya;
        DHAEkonomi dhaEkonomi;
        DHAMagazin dhaMagazin;

        İHAGündem ihaGündem;
        İHAPolitika ihaPolitika;
        İHASpor ihaSpor;
        İHADünya ihaDünya;
        İHAEkonomi ihaEkonomi;

        AATürkiye aaTürkiye;
        AADünya aaDünya;
        AAEkonomi aaEkonomi;
        AASpor aaSpor;
        AAKültürSanat aaKültürSanat;

        public int max;

        public XmlDocument xmlDoc;

        public int percentage;

        public MainForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen; // Form, ekranın ortasında açılacak

            this.MouseWheel += new MouseEventHandler(haberPanel_MouseWheel);

            myProgressBar.Visible = false;

            kategoriForm = new Kategoriler(this);

            haberListe = new List<SuperClass>();

            dhaYurt = new DHAYurt(this, kategoriForm);
            haberListe.Add(dhaYurt);
            dhaPolitika = new DHAPolitika(this, kategoriForm);
            haberListe.Add(dhaPolitika);
            dhaSpor = new DHASpor(this, kategoriForm);
            haberListe.Add(dhaSpor);
            dhaDünya = new DHADünya(this, kategoriForm);
            haberListe.Add(dhaDünya);
            dhaEkonomi = new DHAEkonomi(this, kategoriForm);
            haberListe.Add(dhaEkonomi);
            dhaMagazin = new DHAMagazin(this, kategoriForm);
            haberListe.Add(dhaMagazin);          

            ihaGündem = new İHAGündem(this, kategoriForm);
            haberListe.Add(ihaGündem);
            ihaPolitika = new İHAPolitika(this, kategoriForm);
            haberListe.Add(ihaPolitika);
            ihaSpor = new İHASpor(this, kategoriForm);
            haberListe.Add(ihaSpor);
            ihaDünya = new İHADünya(this, kategoriForm);
            haberListe.Add(ihaDünya);
            ihaEkonomi = new İHAEkonomi(this, kategoriForm);
            haberListe.Add(ihaEkonomi);

            aaTürkiye = new AATürkiye(this, kategoriForm);
            haberListe.Add(aaTürkiye);
            aaDünya = new AADünya(this, kategoriForm);
            haberListe.Add(aaDünya);
            aaEkonomi = new AAEkonomi(this, kategoriForm);
            haberListe.Add(aaEkonomi);
            aaSpor = new AASpor(this, kategoriForm);
            haberListe.Add(aaSpor);
            aaKültürSanat = new AAKültürSanat(this, kategoriForm);
            haberListe.Add(aaKültürSanat);

            // XML dosyasının yüklenmesi
            xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load("HaberlerXML.xml");
            }
            catch (FileNotFoundException) // xml dosyası bulunamazsa, dosya yeniden oluşturulacak
            {
                new XDocument(
                    new XElement("HABERLER") // RootNode (DocumentElement) oluşturuldu
                )
                .Save("HaberlerXML.xml");
                xmlDoc.Load("HaberlerXML.xml");
            }

            xmlDosyasınıOku();
        }

        private void xmlDosyasınıOku()
        {
            foreach (SuperClass haberler in haberListe)
            {
                haberler.xmldenİlkYükleme();
            }

            startBackgroundWorker();

            if (xmlDoc.DocumentElement.HasChildNodes)
            {   // Root'un child'ı varsa (yani kategori yüklenmişse) timer çalışacak
                // Haber yüklenirse diye, programın açılmasından itibaren karşılaştırma timer'ı da çalışacak.
                monitorTimer.Interval = taramaAralığı;
                monitorTimer.Start();
            }
        }

        private void monitorButton_Click(object sender, EventArgs e)
        {
            foreach (SuperClass haberler in haberListe)
            {
                haberler.timeTickMonitorWebSite();
            }
        }

        private void kategorilerButton_Click(object sender, EventArgs e)
        {
            kategoriForm.ShowDialog(this);
        }

        private void monitorTimer_Tick(object sender, EventArgs e)
        {
            foreach (SuperClass haberler in haberListe)
            {
                haberler.timeTickMonitorWebSite();
            }
        }

        public void startBackgroundWorker()
        {
            Cursor = Cursors.WaitCursor;

            haberPanel.Enabled = false;
            kategorilerButton.Enabled = false;
            monitorButton.Enabled = false;
            myProgressBar.Visible = true;

            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            max = -1;

            foreach (SuperClass haberler in haberListe)
            {
                haberler.monitorWebSite();
                haberler.XMLBaşlıklarınıSil();
            }

            // Haberleri Yazdır        
            haberleriYazdır();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (max > -1)
            {
                monitorTimer.Interval = taramaAralığı;
                monitorTimer.Start();
            }

            Cursor = Cursors.Default;

            haberPanel.Enabled = true;
            kategorilerButton.Enabled = true;
            monitorButton.Enabled = true;
            myProgressBar.Visible = false;

            myProgressBar.Value = 0;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            myProgressBar.Value = e.ProgressPercentage;
        }

        public void haberleriYazdır()
        {
            for (int i = max; i > -1; i--)
            {
                if (max > 0)
                {
                    percentage = (max - i) * 100 / max;
                    backgroundWorker.ReportProgress(percentage);
                }

                foreach (SuperClass haberler in haberListe)
                {
                    haberler.yazdır(i);
                }
            }
        }

        private void haberPanel_MouseWheel(object sender, MouseEventArgs e)
        {   // mousewheel'ın panel'i etkilemesi için, panel'e focus yapıldı
            haberPanel.Focus();
        }
    }
}

