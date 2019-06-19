using DernekYonetim.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.UI.ViewModels
{
    class UyeDetayVM
    {
        public UyeDTO Uye { get; set; }
        public List<MaliHareketDTO> MaliHareketler { get; set; }
        public List<AidatDTO> GecikmisAidatlar { get; set; }
    }


}
