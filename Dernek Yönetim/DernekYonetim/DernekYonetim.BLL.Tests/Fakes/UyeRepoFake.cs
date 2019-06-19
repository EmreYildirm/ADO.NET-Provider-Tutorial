using DernekYonetim.DAL.Entities;
using DernekYonetim.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL.Tests.Fakes
{
    internal class UyeRepoFake : IRepo<Uye>
    {
        List<Uye> uyeler = new List<Uye>();

        public UyeRepoFake()
        {
            Uye uye1 = new Uye()
            {
                Id = 1,
                AktifMi = true,
                UyelikBaslangicTarihi = new DateTime(1991,1,1),
                UyelikBitisTarihi = null,
                KisiId = 1,
            };
            Uye uye2 = new Uye()
            {
                Id = 2,
                AktifMi = true,
                UyelikBaslangicTarihi = new DateTime(1993,2, 12),
                UyelikBitisTarihi = null,
                KisiId = 2,
            };
            Uye uye3 = new Uye()
            {
                Id = 3,
                AktifMi = true,
                UyelikBaslangicTarihi = DateTime.Now,
                UyelikBitisTarihi = null,
                KisiId = 3,
            };
            Uye uye4 = new Uye()
            {
                Id = 4,
                AktifMi = false,
                UyelikBaslangicTarihi = new DateTime(1990, 3, 5),
                UyelikBitisTarihi = new DateTime(2011, 1, 1),
                KisiId = 5,
            };
            uyeler.Add(uye1);
            uyeler.Add(uye2);
            uyeler.Add(uye3);
            uyeler.Add(uye4);
        }

        public int Add(Uye item)
        {
            item.Id = uyeler.Count() + 1;
            uyeler.Add(item);
            return item.Id;
        }

        public List<Uye> GetAll()
        {
            return uyeler;
        }

        public Uye GetById(int Id)
        {
            return uyeler.SingleOrDefault(x => x.Id == Id);
        }

        public void Remove(Uye item)
        {
            uyeler.Remove(item);
        }

        public Uye Update(Uye item)
        {
            var degisecekitem = uyeler.SingleOrDefault(x => x.Id == item.Id);
            degisecekitem.KisiId = item.KisiId;
            degisecekitem.UyelikBaslangicTarihi = item.UyelikBaslangicTarihi;
            degisecekitem.UyelikBitisTarihi = item.UyelikBitisTarihi;
            degisecekitem.AktifMi = item.AktifMi;

            return degisecekitem;
        }
    }
}
