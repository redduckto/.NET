using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace HaberTakip_WindowsForms
{
    public partial class Kategoriler : Form
    {
        MainForm mainForm;

        public Kategoriler(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.StartPosition = FormStartPosition.CenterParent; // Parent'ın ortasında açılacak form
        }

        private void kaydetButton_Click(object sender, EventArgs e)
        {
            this.Close();

            mainForm.startBackgroundWorker();
        }
    }
}
