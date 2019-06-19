using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Entities
{
    public class Donem:EntityBase
    {
        public int Ay { get; set; }
        public int Yil { get; set; }
        public string Tanim { get; set; }

    }
}
