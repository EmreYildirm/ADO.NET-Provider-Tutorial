using DernekYonetim.BLL;
using DernekYonetim.BLL.DTOs;
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
    public partial class frmAidatOde : Form
    {
        public event EventHandler DonemAidatiOdendi;
        private AidatDTO aidatDTO;
        private MaliHareketlerService _maliService;
        public frmAidatOde(AidatDTO aidat)
        {
            InitializeComponent();
            aidatDTO = aidat;
            _maliService = new MaliHareketlerService();
        }

        private void frmAidatOde_Load(object sender, EventArgs e)
        {
            lblDonem.Text = aidatDTO.Donem.Tanim;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            aidatDTO.MaliHareket = new MaliHareketDTO() {
                Miktar = nmrMiktar.Value
            };
            _maliService.AidatOde(aidatDTO);
            this.DialogResult = DialogResult.OK;
            if (DonemAidatiOdendi != null)
                DonemAidatiOdendi(this, new EventArgs());
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
