using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Entities
{
    public class ToplantiDetay:EntityBase
    {
        public string Konu { get; set; }
        public string Notlar { get; set; }
    }
}
