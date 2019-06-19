using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Entities
{
    public class Aidat:EntityBase
    {
        public int DonemId { get; set; }
        public int KisiId { get; set; }
        public int HareketId { get; set; }
    }
}
