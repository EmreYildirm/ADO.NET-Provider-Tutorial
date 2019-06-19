namespace DernekYonetim.UI
{
    partial class frmUyeler
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
            this.lstUyeler = new System.Windows.Forms.ListBox();
            this.ctxUyeList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpUyeDetay = new System.Windows.Forms.GroupBox();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.chkPasif = new System.Windows.Forms.CheckBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdMaliHareket = new System.Windows.Forms.DataGridView();
            this.lstOdenmemisAidat = new System.Windows.Forms.ListBox();
            this.ctxAidatListe = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ödeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxUyeList.SuspendLayout();
            this.grpUyeDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaliHareket)).BeginInit();
            this.ctxAidatListe.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUyeler
            // 
            this.lstUyeler.ContextMenuStrip = this.ctxUyeList;
            this.lstUyeler.FormattingEnabled = true;
            this.lstUyeler.Location = new System.Drawing.Point(13, 35);
            this.lstUyeler.Name = "lstUyeler";
            this.lstUyeler.Size = new System.Drawing.Size(176, 407);
            this.lstUyeler.TabIndex = 0;
            this.lstUyeler.SelectedIndexChanged += new System.EventHandler(this.lstUyeler_SelectedIndexChanged);
            // 
            // ctxUyeList
            // 
            this.ctxUyeList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.düzenleToolStripMenuItem});
            this.ctxUyeList.Name = "ctxUyeList";
            this.ctxUyeList.Size = new System.Drawing.Size(117, 26);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            this.düzenleToolStripMenuItem.Click += new System.EventHandler(this.düzenleToolStripMenuItem_Click);
            // 
            // grpUyeDetay
            // 
            this.grpUyeDetay.Controls.Add(this.dtpBitis);
            this.grpUyeDetay.Controls.Add(this.dtpBaslangic);
            this.grpUyeDetay.Controls.Add(this.txtEMail);
            this.grpUyeDetay.Controls.Add(this.txtTelefon);
            this.grpUyeDetay.Controls.Add(this.txtSoyad);
            this.grpUyeDetay.Controls.Add(this.txtAd);
            this.grpUyeDetay.Controls.Add(this.chkPasif);
            this.grpUyeDetay.Controls.Add(this.btnKaydet);
            this.grpUyeDetay.Controls.Add(this.label7);
            this.grpUyeDetay.Controls.Add(this.label6);
            this.grpUyeDetay.Controls.Add(this.label5);
            this.grpUyeDetay.Controls.Add(this.label4);
            this.grpUyeDetay.Controls.Add(this.label3);
            this.grpUyeDetay.Controls.Add(this.label2);
            this.grpUyeDetay.Controls.Add(this.label1);
            this.grpUyeDetay.Location = new System.Drawing.Point(222, 35);
            this.grpUyeDetay.Name = "grpUyeDetay";
            this.grpUyeDetay.Size = new System.Drawing.Size(228, 260);
            this.grpUyeDetay.TabIndex = 1;
            this.grpUyeDetay.TabStop = false;
            this.grpUyeDetay.Text = "Uye Detayları";
            // 
            // dtpBitis
            // 
            this.dtpBitis.Enabled = false;
            this.dtpBitis.Location = new System.Drawing.Point(90, 177);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(112, 20);
            this.dtpBitis.TabIndex = 11;
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Enabled = false;
            this.dtpBaslangic.Location = new System.Drawing.Point(90, 149);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(112, 20);
            this.dtpBaslangic.TabIndex = 11;
            // 
            // txtEMail
            // 
            this.txtEMail.Enabled = false;
            this.txtEMail.Location = new System.Drawing.Point(90, 118);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(112, 20);
            this.txtEMail.TabIndex = 10;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Enabled = false;
            this.txtTelefon.Location = new System.Drawing.Point(90, 85);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(112, 20);
            this.txtTelefon.TabIndex = 9;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Enabled = false;
            this.txtSoyad.Location = new System.Drawing.Point(90, 49);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(112, 20);
            this.txtSoyad.TabIndex = 8;
            // 
            // txtAd
            // 
            this.txtAd.Enabled = false;
            this.txtAd.Location = new System.Drawing.Point(90, 22);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(112, 20);
            this.txtAd.TabIndex = 7;
            // 
            // chkPasif
            // 
            this.chkPasif.AutoSize = true;
            this.chkPasif.Location = new System.Drawing.Point(90, 215);
            this.chkPasif.Name = "chkPasif";
            this.chkPasif.Size = new System.Drawing.Size(49, 17);
            this.chkPasif.TabIndex = 6;
            this.chkPasif.Text = "Pasif";
            this.chkPasif.UseVisualStyleBackColor = true;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Enabled = false;
            this.btnKaydet.Location = new System.Drawing.Point(69, 231);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 5;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Uyelik Durumu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Bitiş";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Başlangıç";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "EMail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Soyad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad";
            // 
            // grdMaliHareket
            // 
            this.grdMaliHareket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMaliHareket.Location = new System.Drawing.Point(222, 301);
            this.grdMaliHareket.Name = "grdMaliHareket";
            this.grdMaliHareket.Size = new System.Drawing.Size(533, 141);
            this.grdMaliHareket.TabIndex = 2;
            // 
            // lstOdenmemisAidat
            // 
            this.lstOdenmemisAidat.ContextMenuStrip = this.ctxAidatListe;
            this.lstOdenmemisAidat.FormattingEnabled = true;
            this.lstOdenmemisAidat.Location = new System.Drawing.Point(553, 35);
            this.lstOdenmemisAidat.Name = "lstOdenmemisAidat";
            this.lstOdenmemisAidat.Size = new System.Drawing.Size(190, 251);
            this.lstOdenmemisAidat.TabIndex = 3;
            // 
            // ctxAidatListe
            // 
            this.ctxAidatListe.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ödeToolStripMenuItem});
            this.ctxAidatListe.Name = "ctxAidatListe";
            this.ctxAidatListe.Size = new System.Drawing.Size(97, 26);
            // 
            // ödeToolStripMenuItem
            // 
            this.ödeToolStripMenuItem.Name = "ödeToolStripMenuItem";
            this.ödeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ödeToolStripMenuItem.Text = "Öde";
            this.ödeToolStripMenuItem.Click += new System.EventHandler(this.ödeToolStripMenuItem_Click);
            // 
            // frmUyeler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstOdenmemisAidat);
            this.Controls.Add(this.grdMaliHareket);
            this.Controls.Add(this.grpUyeDetay);
            this.Controls.Add(this.lstUyeler);
            this.Name = "frmUyeler";
            this.Text = "frmUyeler";
            this.Load += new System.EventHandler(this.frmUyeler_Load);
            this.ctxUyeList.ResumeLayout(false);
            this.grpUyeDetay.ResumeLayout(false);
            this.grpUyeDetay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaliHareket)).EndInit();
            this.ctxAidatListe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstUyeler;
        private System.Windows.Forms.GroupBox grpUyeDetay;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdMaliHareket;
        private System.Windows.Forms.ListBox lstOdenmemisAidat;
        private System.Windows.Forms.CheckBox chkPasif;
        private System.Windows.Forms.ContextMenuStrip ctxUyeList;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxAidatListe;
        private System.Windows.Forms.ToolStripMenuItem ödeToolStripMenuItem;
    }
}