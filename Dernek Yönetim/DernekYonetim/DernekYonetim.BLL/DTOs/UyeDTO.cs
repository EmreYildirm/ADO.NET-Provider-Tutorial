using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL.DTOs
{
    public class UyeDTO : KisiDTO
    {
        public int UyeId { get; set; }
        public DateTime UyelikBaslangicTarihi { get; set; }
        public Nullable<DateTime> UyelikBitisTarihi { get; set; }
        public bool AktifMi { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.Ad, this.Soyad);
        }
    }
}
