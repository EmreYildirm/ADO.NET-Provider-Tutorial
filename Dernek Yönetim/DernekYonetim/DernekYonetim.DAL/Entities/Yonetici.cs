using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Entities
{
    public class Yonetici:EntityBase
    {
        public int KisiId { get; set; }
        public int UnvanId { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
    }
}
