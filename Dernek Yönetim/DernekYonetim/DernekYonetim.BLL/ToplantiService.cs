using DernekYonetim.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL
{
    public class ToplantiService
    {
        ToplantiRepo toplantiRepo;
        ToplantiDetayRepo toplantiDetayRepo;
        public ToplantiService()
        {
            this.toplantiRepo = new ToplantiRepo();
            this.toplantiDetayRepo = new ToplantiDetayRepo();
        }

        public int PlanlananToplantiSayisi()
        {
            return toplantiRepo.GetAll().Where(x => x.ToplantiTarihi > DateTime.Now).Count();
        }

        public int TamamlananToplantiSayisi()
        {
            return toplantiRepo.GetAll().Where(x => x.ToplantiTarihi < DateTime.Now).Count();
        }
    }
}
