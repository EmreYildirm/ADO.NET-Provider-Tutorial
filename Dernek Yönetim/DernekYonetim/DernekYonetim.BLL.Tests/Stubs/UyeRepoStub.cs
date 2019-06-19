using DernekYonetim.DAL.Entities;
using DernekYonetim.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.BLL.Tests.Stubs
{
    internal class UyeRepoStub : IRepo<Uye>
    {
        public int Add(Uye item)
        {
            throw new NotImplementedException();
        }

        public List<Uye> GetAll()
        {
            List<Uye> uyeListesi = new List<Uye>();
            Uye uye1 = new Uye();
            Uye uye2 = new Uye();
            Uye uye3 = new Uye();
            Uye uye4 = new Uye();
            Uye uye5 = new Uye();
            uye1.AktifMi = true;
            uye2.AktifMi = true;
            uye3.AktifMi = true;
            uye1.UyelikBaslangicTarihi = DateTime.Now;
            uye2.UyelikBaslangicTarihi = DateTime.Now;
            uyeListesi.Add(uye1);
            uyeListesi.Add(uye2);
            uyeListesi.Add(uye3);
            uyeListesi.Add(uye4);
            uyeListesi.Add(uye5);
            return uyeListesi;
        }

        public Uye GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Uye item)
        {
            throw new NotImplementedException();
        }

        public Uye Update(Uye item)
        {
            throw new NotImplementedException();
        }
    }
}
