using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL.DTOs
{
    public class DonemDTO
    {
        public int DonemId { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }
        public string Tanim { get; set; }
    }
}
