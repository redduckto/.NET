namespace HaberTakip_WindowsForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.monitorTimer = new System.Windows.Forms.Timer(this.components);
            this.monitorButton = new System.Windows.Forms.Button();
            this.haberPanel = new System.Windows.Forms.Panel();
            this.kategorilerButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.myProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // monitorTimer
            // 
            this.monitorTimer.Interval = 10000;
            this.monitorTimer.Tick += new System.EventHandler(this.monitorTimer_Tick);
            // 
            // monitorButton
            // 
            this.monitorButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.monitorButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.monitorButton.Location = new System.Drawing.Point(526, 12);
            this.monitorButton.Name = "monitorButton";
            this.monitorButton.Size = new System.Drawing.Size(75, 23);
            this.monitorButton.TabIndex = 1;
            this.monitorButton.Text = "YENİLE";
            this.monitorButton.UseVisualStyleBackColor = false;
            this.monitorButton.Click += new System.EventHandler(this.monitorButton_Click);
            // 
            // haberPanel
            // 
            this.haberPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.haberPanel.AutoScroll = true;
            this.haberPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.haberPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.haberPanel.Location = new System.Drawing.Point(12, 41);
            this.haberPanel.Name = "haberPanel";
            this.haberPanel.Size = new System.Drawing.Size(589, 368);
            this.haberPanel.TabIndex = 8;
            // 
            // kategorilerButton
            // 
            this.kategorilerButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.kategorilerButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.kategorilerButton.Location = new System.Drawing.Point(12, 12);
            this.kategorilerButton.Name = "kategorilerButton";
            this.kategorilerButton.Size = new System.Drawing.Size(91, 23);
            this.kategorilerButton.TabIndex = 9;
            this.kategorilerButton.Text = "KATEGORİLER";
            this.kategorilerButton.UseVisualStyleBackColor = false;
            this.kategorilerButton.Click += new System.EventHandler(this.kategorilerButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // myProgressBar
            // 
            this.myProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.myProgressBar.Location = new System.Drawing.Point(110, 12);
            this.myProgressBar.Name = "myProgressBar";
            this.myProgressBar.Size = new System.Drawing.Size(410, 23);
            this.myProgressBar.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(613, 422);
            this.Controls.Add(this.myProgressBar);
            this.Controls.Add(this.kategorilerButton);
            this.Controls.Add(this.haberPanel);
            this.Controls.Add(this.monitorButton);
            this.Name = "MainForm";
            this.Text = "HaberTakip";
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel haberPanel;
        public System.Windows.Forms.Button monitorButton;
        public System.Windows.Forms.Timer monitorTimer;
        public System.ComponentModel.BackgroundWorker backgroundWorker;
        public System.Windows.Forms.Button kategorilerButton;
        public System.Windows.Forms.ProgressBar myProgressBar;
    }
}

