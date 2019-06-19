using DernekYonetim.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL
{
    public class YoneticiService
    {
        private YoneticiRepo yoneticiRepo;
        private UnvanRepo unvanRepo;
        private KisiRepo kisiRepo;

        public YoneticiService()
        {
            kisiRepo = new KisiRepo();
            unvanRepo = new UnvanRepo();
            yoneticiRepo = new YoneticiRepo();
        }
        public int AktifYoneticiSayısı()
        {
            return yoneticiRepo.GetAll().Where(yon => yon.BitisTarihi == null).Count();
        }
    }
}
