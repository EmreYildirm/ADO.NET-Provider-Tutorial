using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL.DTOs
{
    public class KisiDTO
    {
        public int KisiId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string EMail { get; set; }
    }
}
