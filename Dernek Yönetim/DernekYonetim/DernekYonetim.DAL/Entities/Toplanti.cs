using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Entities
{
    public class Toplanti:EntityBase
    {
        public DateTime ToplantiTarihi { get; set; }
        public string Konu { get; set; }
    }
}
