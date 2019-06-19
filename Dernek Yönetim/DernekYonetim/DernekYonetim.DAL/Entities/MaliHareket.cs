using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Entities
{
    public class MaliHareket:EntityBase
    {
        public int KisiId { get; set; }
        public int TipId { get; set; }
        public decimal Miktar { get; set; }
    }
}
