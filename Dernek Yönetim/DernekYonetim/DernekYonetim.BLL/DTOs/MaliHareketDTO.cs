using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL.DTOs
{
    public class MaliHareketDTO
    {
        public int MaliHareketId { get; set; }
        public HareketTipDTO Tip { get; set; }
        public decimal Miktar { get; set; }
    }
}
