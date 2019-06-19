using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Entities
{
    public class Uye:EntityBase
    {
        public int KisiId { get; set; }
        public DateTime UyelikBaslangicTarihi { get; set; }
        public Nullable<DateTime> UyelikBitisTarihi { get; set; }
        public bool AktifMi { get; set; }
    }
}
