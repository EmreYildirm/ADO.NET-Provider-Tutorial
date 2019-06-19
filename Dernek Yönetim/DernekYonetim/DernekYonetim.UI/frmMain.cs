using DernekYonetim.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DernekYonetim.UI
{
    public partial class frmMain : Form
    {
        private UyeService uyeService;
        private ToplantiService toplantiService;
        private MaliHareketlerService maliHareketlerService;
        private YoneticiService yoneticiService;
        public frmMain()
        {
            InitializeComponent();
            uyeService = new UyeService();
            toplantiService = new ToplantiService();
            maliHareketlerService = new MaliHareketlerService();
            yoneticiService = new YoneticiService();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            FillDashBoard();
        }

        private void FillDashBoard()
        {
            lblAktifUye.Text = uyeService.AktifUyeSayisi().ToString();
            lblAktifYonetici.Text = yoneticiService.AktifYoneticiSayısı().ToString();
            lblBuAyToplananAidat.Text = maliHareketlerService.GuncelOdenmisAidatMiktar().ToString();
            lblBuAyUyeOlanlar.Text = uyeService.BuAykiUyeSayisi().ToString();
            lblGucelAidatSayi.Text = maliHareketlerService.GuncelOdenmisAidatSayisi().ToString();
            lblKasaBakiye.Text = maliHareketlerService.GuncelBakiye().ToString();
            lblKasadanCikan.Text = maliHareketlerService.ToplamCikanParaMiktar().ToString();
            lblPlanlananToplanti.Text = toplantiService.PlanlananToplantiSayisi().ToString();
            lblTamamlananToplanti.Text = toplantiService.TamamlananToplantiSayisi().ToString();
            lblToplamBağış.Text = maliHareketlerService.ToplamOdenmisBagisMiktar().ToString();
            lblTumZamanlarAidat.Text = maliHareketlerService.ToplamOdenmisAidatMiktar().ToString();
        }

        private void üyeİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUyeler uyeForm = new frmUyeler();
            uyeForm.Show();
        }
    }
}
