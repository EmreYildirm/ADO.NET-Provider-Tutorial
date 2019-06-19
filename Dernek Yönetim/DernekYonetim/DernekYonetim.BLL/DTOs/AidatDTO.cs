using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL.DTOs
{
    public class AidatDTO
    {
        public KisiDTO Kisi { get; set; }
        public DonemDTO Donem { get; set; }
        public MaliHareketDTO MaliHareket { get; set; }

        public override string ToString()
        {
            return this.Donem.Tanim;
        }
    }
}
